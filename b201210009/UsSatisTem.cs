using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace b201210009
{
    public partial class UsSatisTem : UserControl
    {
        public UsSatisTem()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=fikayadb0; user ID=postgres; password=5858040");

        private void ara_Click(object sender, EventArgs e)
        {
            Ara ara = new Ara();
            ara.bunifuTextBox1.PlaceholderText = "Satış Temsilcisi Adı";
            ara.ShowDialog();

            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("SELECT * FROM \"SatisTemTablosu\" WHERE \"Adı\" LIKE '%" + ara.bunifuTextBox1.Text + "%'", baglanti);
            if (ara.bunifuTextBox1.Text != "")
            {
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut1);
                DataSet ds = new DataSet();
                da.Fill(ds);
                bunifuDataGridView1.DataSource = ds.Tables[0];
            }
            baglanti.Close();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "SELECT * FROM \"SatisTemTablosu\";";
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet dataSet = new DataSet();
            npgsqlDataAdapter.Fill(dataSet);
            bunifuDataGridView1.DataSource = dataSet.Tables[0];
            baglanti.Close();
        }

        private void duzenle_Click(object sender, EventArgs e)
        {
            DuzenleSatisTem duzenleSatisTem = new DuzenleSatisTem();
            duzenleSatisTem.ShowDialog();

            baglanti.Open();

            if (duzenleSatisTem.bunifuTextBox1.Text != "")
            {
                NpgsqlCommand komut1 = new NpgsqlCommand("UPDATE \"SatisTemsilcisi\" SET satistemsilcisikodu = @p2 , ad = @p3 , soyad = @p4 WHERE satistemsilcisikodu = @p1", baglanti);
                komut1.Parameters.AddWithValue("@p1", Convert.ToInt32(duzenleSatisTem.bunifuTextBox1.Text));
                komut1.Parameters.AddWithValue("@p2", Convert.ToInt32(duzenleSatisTem.bunifuTextBox2.Text));
                komut1.Parameters.AddWithValue("@p3", duzenleSatisTem.bunifuTextBox3.Text);
                komut1.Parameters.AddWithValue("@p4", duzenleSatisTem.bunifuTextBox4.Text);
                komut1.ExecuteNonQuery();

            }

            baglanti.Close();
        }
    }
}

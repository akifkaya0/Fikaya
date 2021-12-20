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
    public partial class UsCari : UserControl
    {
        public UsCari()
        {
            InitializeComponent();
        }
        bool sol;
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=fikayadb0; user ID=postgres; password=5858040");
        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            sol = true;
            baglanti.Open();
            string sorgu = "SELECT * FROM \"MusteriTablosu\";";
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet dataSet = new DataSet();
            npgsqlDataAdapter.Fill(dataSet);
            bunifuDataGridView1.DataSource = dataSet.Tables[0];
            baglanti.Close();
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            sol = false;
            baglanti.Open();
            string sorgu = "SELECT * FROM \"SirketTablosu\";";
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet dataSet = new DataSet();
            npgsqlDataAdapter.Fill(dataSet);
            bunifuDataGridView1.DataSource = dataSet.Tables[0];
            baglanti.Close();
        }

        private void ara_Click(object sender, EventArgs e)
        {
            Ara ara = new Ara();
            if (sol)
            {
                ara.bunifuTextBox1.PlaceholderText = "Müşteri Kodu";
            }
            else
            {
                ara.bunifuTextBox1.PlaceholderText = "Şirket Kodu";
            }
            ara.ShowDialog();

            baglanti.Open();

           
            if (sol)
            {
                NpgsqlCommand komut1 = new NpgsqlCommand("SELECT * FROM \"MusteriTablosu\" WHERE \"Kodu\" = @p1", baglanti);
                if (ara.bunifuTextBox1.Text != "")
                {
                    komut1.Parameters.AddWithValue("@p1", Convert.ToInt32(ara.bunifuTextBox1.Text));
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut1);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    bunifuDataGridView1.DataSource = ds.Tables[0];
                }
                baglanti.Close();
            }
            else
            {
                NpgsqlCommand komut1 = new NpgsqlCommand("SELECT * FROM \"SirketTablosu\" WHERE \"Kodu\" = @p1", baglanti);
                if (ara.bunifuTextBox1.Text != "")
                {
                    komut1.Parameters.AddWithValue("@p1", Convert.ToInt32(ara.bunifuTextBox1.Text));
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut1);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    bunifuDataGridView1.DataSource = ds.Tables[0];
                }
                baglanti.Close();
            }
        }

        private void ekle_Click(object sender, EventArgs e)
        {
            if(sol)
            {
                
            }
            else
            {
                EkleSirket ekleSirket = new EkleSirket();


                baglanti.Open();
                ekleSirket.ShowDialog();

                NpgsqlCommand komut1 = new NpgsqlCommand("INSERT INTO \"TedarikciSirket\" (sirketkodu , sirketunvani) VALUES (@p1 , @p2);", baglanti);
                if (ekleSirket.bunifuTextBox1.Text != "" || ekleSirket.bunifuTextBox2.Text != "")
                {
                    komut1.Parameters.AddWithValue("@p1", Convert.ToInt32(ekleSirket.bunifuTextBox1.Text));
                    komut1.Parameters.AddWithValue("@p2", ekleSirket.bunifuTextBox2.Text);
                    komut1.ExecuteNonQuery();
                }
                baglanti.Close();
            }
        }
    }
}

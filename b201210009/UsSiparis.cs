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
    public partial class UsSiparis : UserControl
    {
        public UsSiparis()
        {
            InitializeComponent();
        }
        bool sol;
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=fikayadb0; user ID=postgres; password=5858040");
        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            sol = true;
            baglanti.Open();
            string sorgu = "SELECT * FROM \"SatinAlmaSipTablosu\";";
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
            string sorgu = "SELECT * FROM \"SatisSipTablosu\";";
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet dataSet = new DataSet();
            npgsqlDataAdapter.Fill(dataSet);
            bunifuDataGridView1.DataSource = dataSet.Tables[0];
            baglanti.Close();
        }

        private void ara_Click(object sender, EventArgs e)
        {
            Ara ara = new Ara();
            ara.bunifuTextBox1.PlaceholderText = "Sipariş Tarihi";
            ara.ShowDialog();

            baglanti.Open();
            if(sol)
            {
                NpgsqlCommand komut1 = new NpgsqlCommand("SELECT * FROM \"SatinAlmaSipTablosu\" WHERE \"Tarih\" = @p1", baglanti);
                if (ara.bunifuTextBox1.Text != "")
                {
                    komut1.Parameters.AddWithValue("@p1", Convert.ToDateTime(ara.bunifuTextBox1.Text));
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut1);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    bunifuDataGridView1.DataSource = ds.Tables[0];
                }
                baglanti.Close();
            }
            else
            {
                NpgsqlCommand komut1 = new NpgsqlCommand("SELECT * FROM \"SatisSipTablosu\" WHERE \"Tarih\" = @p1", baglanti);
                if (ara.bunifuTextBox1.Text != "")
                {
                    komut1.Parameters.AddWithValue("@p1", Convert.ToDateTime(ara.bunifuTextBox1.Text));
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut1);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    bunifuDataGridView1.DataSource = ds.Tables[0];
                }
                baglanti.Close();
            }
            
        }

        private void sil_Click(object sender, EventArgs e)
        {
            
        }
    }
}

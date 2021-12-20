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
    public partial class UsStok : UserControl
    {
        public UsStok()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=fikayadb0; user ID=postgres; password=5858040");

        private void ara_Click(object sender, EventArgs e)
        {
            Ara ara = new Ara();
            ara.bunifuTextBox1.PlaceholderText = "Ürün Kodu";
            ara.ShowDialog();

            baglanti.Open();

            NpgsqlCommand komut1 = new NpgsqlCommand("SELECT * FROM \"StokTablosu\" WHERE \"Ürün Kodu\" = @p1", baglanti);
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

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "SELECT * FROM \"StokTablosu\";";
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet dataSet = new DataSet();
            npgsqlDataAdapter.Fill(dataSet);
            bunifuDataGridView1.DataSource = dataSet.Tables[0];
            baglanti.Close();
        }

        private void ekle_Click(object sender, EventArgs e)
        {
            EkleStok ekleStok = new EkleStok();
            baglanti.Open();

            NpgsqlDataAdapter da = new NpgsqlDataAdapter("SELECT * FROM \"TedarikciSirket\"" , baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ekleStok.bunifuDropdown2.DisplayMember = "sirketunvani";
            ekleStok.bunifuDropdown2.ValueMember = "sirketkodu";
            ekleStok.bunifuDropdown2.DataSource = dt;
            ekleStok.ShowDialog();

            NpgsqlCommand komut1 = new NpgsqlCommand("INSERT INTO \"Urun\" (urunkodu , urunaciklamasi , malzemebirimi , tedarikcisirketkodu) VALUES (@p1 , @p2 , @p3 , @p4);", baglanti);
            if (ekleStok.bunifuTextBox1.Text != "" || ekleStok.bunifuTextBox2.Text != "")
            {
                komut1.Parameters.AddWithValue("@p1", Convert.ToInt32(ekleStok.bunifuTextBox1.Text));
                komut1.Parameters.AddWithValue("@p2", ekleStok.bunifuTextBox2.Text);
                komut1.Parameters.AddWithValue("@p3", ekleStok.bunifuDropdown1.SelectedItem);
                komut1.Parameters.AddWithValue("@p4", ekleStok.bunifuDropdown2.SelectedValue);
                komut1.ExecuteNonQuery();
            }
            baglanti.Close();
        }
    }
}

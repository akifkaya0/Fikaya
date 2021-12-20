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
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        AnaForm anaForm = new AnaForm();
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=fikayadb0; user ID=postgres; password=5858040");
        private void bunifuButton22_Click(object sender, EventArgs e)
        {

                baglanti.Open();

                NpgsqlCommand komut1 = new NpgsqlCommand("select * from \"Kullanici\" WHERE \"kullaniciAdi\" = @p1 AND \"sifre\" = @p2" , baglanti);

                komut1.Parameters.AddWithValue("@p1" , bunifuTextBox1.Text.Trim());
                komut1.Parameters.AddWithValue("@p2", bunifuTextBox2.Text.Trim());

                NpgsqlDataReader dr = komut1.ExecuteReader();
                if(dr.Read())
                {
                    anaForm.ShowDialog();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Giriş Bilgileri Hatalı !");
                }

                dr.Close();
                baglanti.Close();
        }
    }
}

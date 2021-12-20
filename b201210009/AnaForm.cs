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
    public partial class AnaForm : Form
    {

        UsStok stok = new UsStok
        {
            Dock = DockStyle.Fill
        };
        UsSiparis siparis = new UsSiparis
        {
            Dock = DockStyle.Fill
        };
        UsFatura fatura = new UsFatura
        {
            Dock = DockStyle.Fill
        };
        UsKasa kasa = new UsKasa
        {
            Dock = DockStyle.Fill
        };
        UsBanka banka = new UsBanka()
        {
            Dock = DockStyle.Fill
        };
        UsSatisTem satisTem = new UsSatisTem()
        {
            Dock = DockStyle.Fill
        };
        UsCari cariHesap = new UsCari()
        {
            Dock = DockStyle.Fill
        };
        public AnaForm()
        {
            InitializeComponent();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            bunifuPanel2.Controls.Clear();
            bunifuPanel2.Controls.Add(stok);
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            bunifuPanel2.Controls.Clear();
            bunifuPanel2.Controls.Add(siparis);
        }

        private void bunifuButton23_Click(object sender, EventArgs e)
        {
            bunifuPanel2.Controls.Clear();
            bunifuPanel2.Controls.Add(fatura);
        }

        private void bunifuButton24_Click(object sender, EventArgs e)
        {
            bunifuPanel2.Controls.Clear();
            bunifuPanel2.Controls.Add(kasa);
        }

        private void bunifuButton25_Click(object sender, EventArgs e)
        {
            bunifuPanel2.Controls.Clear();
            bunifuPanel2.Controls.Add(banka);
        }

        private void bunifuButton26_Click(object sender, EventArgs e)
        {
            bunifuPanel2.Controls.Clear();
            bunifuPanel2.Controls.Add(satisTem);
        }

        private void bunifuButton27_Click(object sender, EventArgs e)
        {
            bunifuPanel2.Controls.Clear();
            bunifuPanel2.Controls.Add(cariHesap);
        }

        private void AnaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
                Giris giris = new Giris();
                giris.Show();
        }

        
    }
}

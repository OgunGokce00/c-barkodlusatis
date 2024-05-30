using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VetRx
{
    public partial class FnakitKart : Form
    {
        public FnakitKart()
        {
            InitializeComponent();
        }

        private void Tnakit_KeyDown(object sender, KeyEventArgs e)
        {
            if (Tnakit.Text!=null)
            {
                if (e.KeyCode==Keys.Enter)
                {
                    Hesapla();
                }
            }
        }
       
        private void Btn_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (b.Text == ",")
            {
                if (!Tnakit.Text.Contains(","))
                {
                    Tnakit.Text += b.Text;
                }
            }
            else if (b.Text == "<")
            {
                if (Tnakit.Text.Length > 0)
                {
                    Tnakit.Text = Tnakit.Text.Substring(0, Tnakit.Text.Length - 1);
                }
            }
            else
            {
                Tnakit.Text += b.Text;
            }
        }
        private void Hesapla()
         {
            Fsatis f = (Fsatis)Application.OpenForms["Fsatis"];
            double nakit = Islemler.DoubleYap(Tnakit.Text);
            double geneltoplam = Islemler.DoubleYap(f.Texttutar.Text);
            double kart = geneltoplam - nakit;
            f.Lnakit.Text =  Math.Abs(nakit).ToString("C2");
            f.Lkart.Text = Math.Abs(kart).ToString("C2");
            f.SatisYap("Kart-Nakit");
           
                f.Todnen.Text = Math.Abs(nakit).ToString("C2");
                f.label5.Text = "NakitÖdenen \n Miktar";
                f.Tpraust.Text = Math.Abs(kart).ToString("C2");
                f.Labelson.Text = "Ödenmesi \n beklenen \n Tutar";
                
            
            this.Hide();



        }
        private void Benter_Click(object sender, EventArgs e)
        {
            if (Tnakit.Text!="")
            {

                Hesapla();
            }
            else
            {
                MessageBox.Show("Miktar tutar giriniz lütfen dikkat ediniz.");
            }
        }

        private void Tnakit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar)==false&&e.KeyChar!=(char)08)
            {
                e.Handled = true;

            }
        }

    
    }
}

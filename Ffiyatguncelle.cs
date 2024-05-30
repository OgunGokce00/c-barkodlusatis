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
    public partial class Ffiyatguncelle : Form
    {
        public Ffiyatguncelle()
        {
            InitializeComponent();
        }

        private void TxtBrkd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                Cursor.Current = Cursors.WaitCursor;
                using (var Db= new BarkodDbEntities())
                {
                    if (Db.Urun.Any(x=>x.Barkod==TxtBrkd.Text))
                    {
                        var getir = Db.Urun.Where(x => x.Barkod == TxtBrkd.Text).SingleOrDefault();
                        Lbarkod.Text = getir.Barkod;
                        Luruad.Text = getir.UrunAd;
                        double mevcutfiyat = Convert.ToDouble(getir.SatisFiyat);
                        Lfiyat.Text= mevcutfiyat.ToString("C2");


                    }
                    else
                    {
                        MessageBox.Show("Ürün Kayıtlı Değil");

                    }
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void Ffiyatguncelle_Load(object sender, EventArgs e)
        {

        }

        private void Btnkyt_Click(object sender, EventArgs e)
        {
            if (TxtFiyat.Text!=null && Lbarkod.Text!= "")
            {
                using ( var Db = new BarkodDbEntities())
                {
                    var Guncelleme = Db.Urun.Where(x => x.Barkod == Lbarkod.Text).SingleOrDefault();
                    Guncelleme.SatisFiyat = Islemler.DoubleYap(TxtFiyat.Text);
                    Db.SaveChanges();
                    MessageBox.Show("Yeni Fiyat kayıt edilmiştir");
                    Lbarkod.Text = "";
                    Luruad.Text = "";
                    Lfiyat.Text = "";


                }
                TxtFiyat.Clear();
                TxtBrkd.Clear();
                TxtBrkd.Focus();

            }
            else
            {
                MessageBox.Show("Ürün Okutunuz");
                TxtBrkd.Focus();
            }
        }

        private void TxtBrkd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08)
            {
                e.Handled = true;

            }
        }
    }
}

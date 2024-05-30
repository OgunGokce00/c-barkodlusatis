using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VetRx
{
    public partial class Flogin : Form
    {
        public Flogin()
        {
            InitializeComponent();
        }

        private void Btngiriş_Click(object sender, EventArgs e)
        {
            if (Tkullanici.Text != "" && Tsifre.Text != "")
            {
                try
                {
                    using (var Db = new BarkodDbEntities())
                    {
                        if (Db.Kullanici.Any())
                        {
                            var bak = Db.Kullanici.Where(x => x.KullaniciAd == Tkullanici.Text && x.Sifre == Tsifre.Text).FirstOrDefault();
                            if (bak != null)
                            {
                                Cursor.Current = Cursors.WaitCursor;
                                Fbaslangic f = new Fbaslangic();
                                f.Btnn1.Enabled = (bool)bak.Satis;
                                f.Btnn2.Enabled = (bool)bak.Rapor;
                                f.Btnn3.Enabled = (bool)bak.Stok;
                                f.Btnn4.Enabled = (bool)bak.UrunGiris;
                                f.Btnn5.Enabled = (bool)bak.Ayarlar;
                                f.Btnn6.Enabled = (bool)bak.FiyatGuncelle;
                                f.Btnn7.Enabled = (bool)bak.Yedekleme;
                                f.Lklnc.Text = bak.KullaniciAd;
                                f.Show();
                                this.Hide();


                                Cursor.Current = Cursors.Default;
                            }
                            else
                            {
                                MessageBox.Show("Hatalı Giriş");
                            }
                        }
                        else
                        {
                            Kullanici k = new Kullanici
                            {
                                AdSoyad = "admin",
                                KullaniciAd = "admin",
                                Eposta = "eposta",
                                Sifre = "admin",
                                Telefon = "05331968675",
                                Rapor = true,
                                Satis = true,
                                Stok = true,
                                UrunGiris = true,
                                Ayarlar = true,
                                Yedekleme = true,
                                FiyatGuncelle = true
                            };
                            Db.Kullanici.Add(k);
                            Db.SaveChanges();
                            var bak = Db.Kullanici.Where(x => x.KullaniciAd == Tkullanici.Text && x.Sifre == Tsifre.Text).FirstOrDefault();
                            Cursor.Current = Cursors.WaitCursor;
                            Fbaslangic f = new Fbaslangic();
                            f.Btnn1.Enabled = (bool)bak.Satis;
                            f.Btnn2.Enabled = (bool)bak.Rapor;
                            f.Btnn3.Enabled = (bool)bak.Stok;
                            f.Btnn4.Enabled = (bool)bak.UrunGiris;
                            f.Btnn5.Enabled = (bool)bak.Ayarlar;
                            f.Btnn6.Enabled = (bool)bak.FiyatGuncelle;
                            f.Btnn7.Enabled = (bool)bak.Yedekleme;
                            f.Lklnc.Text = bak.KullaniciAd;
                            f.Show();
                            this.Hide();


                            Cursor.Current = Cursors.Default;


                        }

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }

        }

        private void Tsifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Tkullanici.Text != "" && Tsifre.Text != "")
                {
                    try
                    {
                        using (var Db = new BarkodDbEntities())
                        {
                            if (Db.Kullanici.Any())
                            {
                                var bak = Db.Kullanici.Where(x => x.KullaniciAd == Tkullanici.Text && x.Sifre == Tsifre.Text).FirstOrDefault();
                                if (bak != null)
                                {
                                    Cursor.Current = Cursors.WaitCursor;
                                    Fbaslangic f = new Fbaslangic();
                                    f.Btnn1.Enabled = (bool)bak.Satis;
                                    f.Btnn2.Enabled = (bool)bak.Rapor;
                                    f.Btnn3.Enabled = (bool)bak.Stok;
                                    f.Btnn4.Enabled = (bool)bak.UrunGiris;
                                    f.Btnn5.Enabled = (bool)bak.Ayarlar;
                                    f.Btnn6.Enabled = (bool)bak.FiyatGuncelle;
                                    f.Btnn7.Enabled = (bool)bak.Yedekleme;
                                    f.Lklnc.Text = bak.KullaniciAd;
                                    f.Show();
                                    this.Hide();


                                    Cursor.Current = Cursors.Default;
                                }
                                else
                                {
                                    MessageBox.Show("Hatalı Giriş");
                                }
                            }
                            else
                            {
                                Kullanici k = new Kullanici
                                {
                                    AdSoyad = "admin",
                                    KullaniciAd = "admin",
                                    Eposta = "eposta",
                                    Sifre = "admin",
                                    Telefon = "05331968675",
                                    Rapor = true,
                                    Satis = true,
                                    Stok = true,
                                    UrunGiris = true,
                                    Ayarlar = true,
                                    Yedekleme = true,
                                    FiyatGuncelle = true
                                };
                                Db.Kullanici.Add(k);
                                Db.SaveChanges();
                                var bak = Db.Kullanici.Where(x => x.KullaniciAd == Tkullanici.Text && x.Sifre == Tsifre.Text).FirstOrDefault();
                                Cursor.Current = Cursors.WaitCursor;
                                Fbaslangic f = new Fbaslangic();
                                f.Btnn1.Enabled = (bool)bak.Satis;
                                f.Btnn2.Enabled = (bool)bak.Rapor;
                                f.Btnn3.Enabled = (bool)bak.Stok;
                                f.Btnn4.Enabled = (bool)bak.UrunGiris;
                                f.Btnn5.Enabled = (bool)bak.Ayarlar;
                                f.Btnn6.Enabled = (bool)bak.FiyatGuncelle;
                                f.Btnn7.Enabled = (bool)bak.Yedekleme;
                                f.Lklnc.Text = bak.KullaniciAd;
                                f.Show();
                                this.Hide();


                                Cursor.Current = Cursors.Default;


                            }

                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

     
    }
   
    
}
    

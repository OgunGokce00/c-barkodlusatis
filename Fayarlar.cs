using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VetRx
{
    public partial class Fayarlar : Form
    {
        public Fayarlar()
        {
            InitializeComponent();
        }
        private void Temizle()
        {
            Tkullanici.Clear();
            Tadsoyad.Clear();
            Ttelefon.Clear();
            Teposta.Clear();
            Tsifre.Clear();
            TsifreTekrar.Clear();
            Chsatis.Checked = false;
            Chstok.Checked = false;
            Chrapor.Checked = false;
            Chyedek.Checked = false;
            Churun.Checked = false;
            Chayarlar.Checked = false;
            Chfiyat.Checked = false;



        }
        private void Btnkaydet_Click(object sender, EventArgs e)
        {
            if (Btnkaydet.Text == "KAYDET")
            {
                if (Tadsoyad.Text != "" && Tsifre.Text != "" && TsifreTekrar.Text != "")
                {
                    if (Tsifre.Text == TsifreTekrar.Text)
                    {
                        try
                        {
                            using (var Db = new BarkodDbEntities())
                            {
                                if (!Db.Kullanici.Any(x => x.KullaniciAd == Tkullanici.Text))
                                {
                                    Kullanici k = new Kullanici
                                    {
                                        AdSoyad = Tadsoyad.Text,
                                        Telefon = Ttelefon.Text,
                                        Eposta = Teposta.Text,
                                        KullaniciAd = Tkullanici.Text.Trim(),
                                        Sifre = Tsifre.Text,
                                        Satis = Chsatis.Checked,
                                        Rapor = Chrapor.Checked,
                                        Stok = Chstok.Checked,
                                        UrunGiris = Churun.Checked,
                                        Ayarlar = Chayarlar.Checked,
                                        FiyatGuncelle = Chfiyat.Checked,
                                        Yedekleme = Chyedek.Checked
                                    };
                                    Db.Kullanici.Add(k);
                                    Db.SaveChanges();
                                    Doldur();



                                }
                            }
                            Temizle();
                        }
                        catch (Exception)
                        {

                            MessageBox.Show("Hata Oluştu adminle iletişime geçin");

                        }
                    }
                    else
                    {
                        MessageBox.Show(" şifre ve şifre tekrarı Uyuşmuyor");


                    }

                }
                else
                {
                    MessageBox.Show("Adsoyad,şifre ve şifre tekrarı  Boş Bırakılamaz");

                }
            }
            else if (Btnkaydet.Text == "Düzenle/Kaydet")
            {
                if (Tadsoyad.Text != "" && Tsifre.Text != "" && TsifreTekrar.Text != "")
                {
                    if (Tsifre.Text == TsifreTekrar.Text)
                    {
                        int id = Convert.ToInt32(Lid.Text);
                        using (var Db = new BarkodDbEntities())
                        {
                            var guncelle = Db.Kullanici.Where(x => x.Id == id).FirstOrDefault();
                            guncelle.AdSoyad = Tadsoyad.Text;
                            guncelle.Telefon = Ttelefon.Text;
                            guncelle.Eposta = Teposta.Text;
                            guncelle.KullaniciAd = Tkullanici.Text.Trim();
                            guncelle.Sifre = Tsifre.Text;
                            guncelle.Satis = Chsatis.Checked;
                            guncelle.Rapor = Chrapor.Checked;
                            guncelle.Stok = Chstok.Checked;
                            guncelle.UrunGiris = Churun.Checked;
                            guncelle.Ayarlar = Chayarlar.Checked;
                            guncelle.FiyatGuncelle = Chfiyat.Checked;
                            guncelle.Yedekleme = Chyedek.Checked;
                            Db.SaveChanges();
                            MessageBox.Show("Güncelleme yapıldı");
                            Btnkaydet.Text = "KAYDET";
                            Temizle();
                            Doldur();
                        }
                    }
                    else
                    {

                        MessageBox.Show(" şifre ve şifre tekrarı Uyuşmuyor");
                    }

                }
                else
                {
                    MessageBox.Show("Adsoyad,şifre ve şifre tekrarı  Boş Bırakılamaz");

                }

            }
        }

        private void DüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DataGrwd2.Rows.Count > 0)
            {
                int Id = Convert.ToInt32(DataGrwd2.CurrentRow.Cells["Id"].Value.ToString());
                Lid.Text = Id.ToString();
                using (var Db = new BarkodDbEntities())
                {
                    var getir = Db.Kullanici.Where(x => x.Id == Id).FirstOrDefault();
                    Tadsoyad.Text = getir.AdSoyad;
                    Ttelefon.Text = getir.Telefon;
                    Teposta.Text = getir.Eposta;
                    Tkullanici.Text = getir.KullaniciAd;
                    Tsifre.Text = getir.Sifre;
                    TsifreTekrar.Text = getir.Sifre;
                    Chsatis.Checked = (bool)getir.Satis;
                    Chstok.Checked = (bool)getir.Stok;
                    Chrapor.Checked = (bool)getir.Rapor;
                    Churun.Checked = (bool)getir.UrunGiris;
                    Chayarlar.Checked = (bool)getir.Ayarlar;
                    Chfiyat.Checked = (bool)getir.FiyatGuncelle;
                    Chyedek.Checked = (bool)getir.Yedekleme;
                    Btnkaydet.Text = "Düzenle/Kaydet";
                    Doldur();
                }
            }
            else
            {
                MessageBox.Show("Kulanıcı seçiniz");
            }
        }

        private void Fayarlar_Load(object sender, EventArgs e)
        {
            Cursor .Current = Cursors.WaitCursor; 
            Doldur();
           
            Cursor.Current = Cursors.Default;   
        }
        private void Doldur()
        {
            
            using (var Db = new BarkodDbEntities())
            {
                if (Db.Kullanici.Any())
                {
                    DataGrwd2.DataSource = Db.Kullanici.Select(x => new { x.Id, x.AdSoyad, x.KullaniciAd, x.Telefon, }).ToList();
                }
                Islemler.SabitVarsayilan();

                var sabitler = Db.Sabit.FirstOrDefault();
                Tnumara.Text = sabitler.KartKomisyon.ToString();
            }
        }

        private void Btnekle_Click(object sender, EventArgs e)
        {
            if (Tnumara.Text!="")
            {
                using (var Db = new BarkodDbEntities())
                {
                    var sabit = Db.Sabit.FirstOrDefault();
                    sabit.KartKomisyon = Convert.ToInt16(Tnumara.Text);
                    Db.SaveChanges();
                    MessageBox.Show("Kart komisyon ayarlandı");
                }
            }
            else
            {
                MessageBox.Show("Kartkomisyon bilgisini giriniz");
            }
           
        }

        private void BtnYedek_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath +@"\ProgramRestore.exe");
            Application.Exit();
        }

        private void Tnumara_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08)
            {
                e.Handled = true;

            }
        }

      

        private void BtnGreri_Click(object sender, EventArgs e)
        {
            Fbaslangic f = new Fbaslangic();
            f.Show();
            this.Hide();
        }

        private void BtnGri_Click(object sender, EventArgs e)
        {
            Fbaslangic f = new Fbaslangic();
            f.Show();
            this.Hide();
        }
    }
}

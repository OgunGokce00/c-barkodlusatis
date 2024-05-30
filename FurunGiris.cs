using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace VetRx
{
    public partial class FurunGiris : Form
    {
        public FurunGiris()
        {
            InitializeComponent();

        }
        readonly BarkodDbEntities Db = new BarkodDbEntities();
        private void FurunGiris_Load(object sender, EventArgs e)
        {

            int urunSayisi = Db.Urun.Count();
            Textsasyı.Text = urunSayisi.ToString();
            DataGrwd.DataSource = Db.Urun.ToList();
            DataGrwd.AutoGenerateColumns = true;
        }

        private void TexBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string barkod = TexBarkod.Text.Trim();
                if (Db.Urun.Any(a => a.Barkod == barkod))
                {

                    var urun = Db.Urun.Where(a => a.Barkod == barkod).SingleOrDefault();
                    TexAd.Text = urun.UrunAd;
                    TexAlisfyt.Text = urun.AlisFiyatı.ToString();
                    TexSatisfiyati.Text = urun.SatisFiyat.ToString();
                    TexMiktar.Text = urun.Miktar.ToString();



                }
                else
                {
                    MessageBox.Show("Ürün kayıtlı değil ürünü ekleye bilirsiniz");

                }


            }
        }
        private void Sil()
        {
            TexBarkod.Clear();
            TexAd.Clear();
            TexAlisfyt.Clear();
            TexSatisfiyati.Clear();
            TexMiktar.Clear();


        }

        private void Btnkayit_Click(object sender, EventArgs e)
        {
            if (TexBarkod.Text != "" && TexMiktar.Text != "" && TexAd.Text != "" && TexSatisfiyati.Text != "" && TexAlisfyt.Text != "")
            {
                if (Db.Urun.Any(a => a.Barkod == TexBarkod.Text))
                {  // güncelleme
                    var guncelle = Db.Urun.Where(a => a.Barkod == TexBarkod.Text).SingleOrDefault();

                    guncelle.UrunAd = TexAd.Text;

                    guncelle.AlisFiyatı = Convert.ToDouble(TexAlisfyt.Text);
                    guncelle.SatisFiyat = Convert.ToDouble(TexSatisfiyati.Text);
                    guncelle.Miktar = Convert.ToDouble(TexMiktar.Text);
                    guncelle.Birim = "Adet";
                    guncelle.Tarih = DateTime.Now;
                    guncelle.Kullanici = Lkullanici.Text;

                    Db.SaveChanges();
                    DataGrwd.DataSource = Db.Urun.OrderByDescending(a => a.UrunId).Take(10).ToList();

                    MessageBox.Show("Güncelleme işlemi tamamlandı");
                    Sil();

                }
                else
                {
                    //urun ekleme
                    Urun urun = new Urun
                    {
                        Barkod = TexBarkod.Text,
                        UrunAd = TexAd.Text,
                        AlisFiyatı = Convert.ToDouble(TexAlisfyt.Text),
                        SatisFiyat = Convert.ToDouble(TexSatisfiyati.Text),
                        Miktar = Convert.ToDouble(TexMiktar.Text),
                        Birim = "Adet",
                        Tarih = DateTime.Now,
                        Kullanici = Lkullanici.Text
                    };
                    Db.Urun.Add(urun);
                    Db.SaveChanges();
                    Islemler.StokGiris(TexBarkod.Text, TexAd.Text, "Adet", Convert.ToDouble(TexMiktar.Text), Lkullanici.Text);
                    DataGrwd.DataSource = Db.Urun.OrderByDescending(a => a.UrunId).Take(20).ToList();
                   
                    if (TexBarkod.Text.Length == 8)
                    {
                       Barkod _barkod = new Barkod() { Barkodno = int.Parse(urun.Barkod) };
                        Db.Barkod.Add(_barkod);
                        Db.SaveChanges();
                    }
                    Sil();
                }


                Sil();
            }
            else
            {
                MessageBox.Show("bu alanları boş bırakılarak ürün kaydı yapamazsınız !!");
                TexBarkod.Focus();
            }
        }

        private void Textara_TextChanged(object sender, EventArgs e)
        {

            if (Textara.Text.Length >= 2)
            {

                string urunad = Textara.Text;
                DataGrwd.DataSource = Db.Urun.Where(a => a.UrunAd.Contains(urunad)).ToList();

            }


        }



        private void Btniptal_Click(object sender, EventArgs e)
        {
            Sil();
        }

        private void Btnbarkod_Click(object sender, EventArgs e)
        {
            var barkodno = Db.Barkod.Max(x => x.Barkodno);
            int karakter = barkodno.ToString().Trim().Length;
            string sifirlar = string.Empty;
            for (int i = 0; i < 8 - karakter; i++)
            {
                sifirlar += "0";
            }
            string oluşanbarkod = sifirlar + (barkodno + 1).ToString();
            TexBarkod.Text = oluşanbarkod;
            TexAd.Focus();


        }

        private void SiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DataGrwd.Rows.Count > 0)
            {
                int Urunid = Convert.ToInt32(DataGrwd.CurrentRow.Cells["UrunId"].Value.ToString());
                string Urunad = DataGrwd.CurrentRow.Cells["UrunAd"].Value.ToString();
                string barkod = DataGrwd.CurrentRow.Cells["Barkod"].Value.ToString();

                DialogResult onay = MessageBox.Show(Urunad + "İLACI SİLMEK İSTİYORMUSUNUZ ?", "UYARI", MessageBoxButtons.YesNo);
                if (onay == DialogResult.Yes)
                {
                    var Urun = Db.Urun.Find(Urunid);
                    Db.Urun.Remove(Urun);
                    Db.SaveChanges();
                    var Urunn = Db.StokHareket.Where(x => x.Barkod == barkod).FirstOrDefault();
                    if (Urunn != null)
                    {
                        Db.StokHareket.Remove(Urunn);
                        Db.SaveChanges();
                    }

                    var Hizliurun = Db.HizliUrun.FirstOrDefault(x => x.Barkod == barkod);
                    if (Hizliurun != null && Hizliurun.Barkod != "_")
                    {
                        Hizliurun.Barkod = "_";
                        Hizliurun.UrunAd = "_";
                        Hizliurun.Fiyat = 0;
                        Db.SaveChanges();
                    }


                    MessageBox.Show("İlaç silindi");
                    DataGrwd.DataSource = Db.Urun.OrderByDescending(a => a.UrunId).Take(20).ToList();
                    TexBarkod.Focus();

                }
            }


        }

        private void Btnrapor_Click(object sender, EventArgs e)
        {
            Form f = new Frapor();
            f.ShowDialog();


        }

        private void DüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DataGrwd.Rows.Count > 0)
            {
                TexBarkod.Text = DataGrwd.CurrentRow.Cells["Barkod"].Value.ToString();
                TexAd.Text = DataGrwd.CurrentRow.Cells["UrunAd"].Value.ToString();
                TexMiktar.Text = DataGrwd.CurrentRow.Cells["Miktar"].Value.ToString();
                TexSatisfiyati.Text = DataGrwd.CurrentRow.Cells["SatisFiyat"].Value.ToString();
                TexAlisfyt.Text = DataGrwd.CurrentRow.Cells["AlisFiyatı"].Value.ToString();


            }
        }

        private void FurunGiris_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08)
            {
                e.Handled = true;

            }
        }


    }
}

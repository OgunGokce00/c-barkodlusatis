using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace VetRx
{
    public partial class Fsatis : Form
    {
        public Fsatis()
        {
            InitializeComponent();

        }

        private void Fsatis_Load(object sender, EventArgs e)
        {

            HizliBtndoldur();



        }
        private void HizliBtndoldur()
        {
            var hızlıurun = db.HizliUrun.ToList();
            foreach (var item in hızlıurun)
            {
                if (this.Controls.Find("Bh" + item.Id, true).FirstOrDefault() is Button Bh)
                {
                    double fiyat = Islemler.DoubleYap(item.Fiyat.ToString());
                    Bh.Text = item.UrunAd + "\n" + fiyat.ToString("C2");
                }



            }

        }
        private void HizliBtnClick(object sender, EventArgs e)
        {

            Button b = (Button)sender;
            int butunıd = Convert.ToInt16(b.Name.ToString().Substring(2, b.Name.Length - 2));
            if (b.Text.ToString().StartsWith("_"))
            {
                Fhizlibtnekle frm = new Fhizlibtnekle();
                frm.LbutonId.Text = butunıd.ToString();
                frm.ShowDialog();
            }
            else
            {

                var urunbarkod = db.HizliUrun.Where(a => a.Id == butunıd).Select(a => a.Barkod).FirstOrDefault();
                var urun = db.Urun.Where(a => a.Barkod == urunbarkod).FirstOrDefault();
                UrunGetirlisteye(urun, urunbarkod, Convert.ToDouble(Texmktr.Text));
                GenelToplam();



            }
        }

        readonly BarkodDbEntities db = new BarkodDbEntities();

        private void Texbrkd_KeyDown(object sender, KeyEventArgs e)
        {



            string barkod = Texbrkd.Text.Trim();
            if (e.KeyCode == Keys.Enter)
            {
                Texbrkd.Focus();

                if (barkod.Length <= 2)
                {
                    Texmktr.Text = barkod;
                    Texbrkd.Clear();
                    Texbrkd.Focus();
                }



                else
                {


                    if (db.Urun.Any(a => a.Barkod == barkod))
                    {
                        var urun = db.Urun.FirstOrDefault(a => a.Barkod == barkod);
                        UrunGetirlisteye(urun, barkod, Convert.ToDouble(Texmktr.Text));
                        Texbrkd.Clear();
                        Texbrkd.Focus();
                        GenelToplam();

                    }
                    else
                    {
                        FurunGiris f = (FurunGiris)Application.OpenForms["FurunGiris"];
                        if (f == null)
                        {
                            DialogResult onay = MessageBox.Show("ürün kayıtlı değil  ,Ürün ekleme  Sayfasına Geçilsin mi ? ", "BİLGİLENDİRME", MessageBoxButtons.YesNo);
                            if (onay == DialogResult.Yes)
                            {
                                f = new FurunGiris();
                                f.TexBarkod.Text = barkod;
                                f.ShowDialog();
                            }
                        }
                        else
                        {

                            f.TexBarkod.Text = barkod;
                            f.Focus();


                        }
                        DataGridSatis.ClearSelection();
                        GenelToplam();

                    }

                }

            }
        }

        private void DataGridSatis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DataGridSatis.Columns["Sil"].Index && e.RowIndex >= 0)
            {

                DataGridSatis.Rows.RemoveAt(e.RowIndex);
                DataGridSatis.ClearSelection();
                GenelToplam();
                Texbrkd.Focus();
            }
        }

        public void GenelToplam()
        {

            double toplam = 0;
            for (int i = 0; i < DataGridSatis.Rows.Count; i++)
            {
                toplam += Convert.ToDouble(DataGridSatis.Rows[i].Cells["Toplam"].Value);
               
            }
            Texttutar.Text = toplam.ToString("C2");
            Texmktr.Text = "1";
            Texbrkd.Clear();
            Texbrkd.Focus();

        }


        private void UrunGetirlisteye(Urun urun, string barkod, double miktar)
        {
            int satrsayısı = DataGridSatis.Rows.Count;
            bool Satisiade = CheckIslm.Checked;
            // double miktar = Convert.ToDouble(Texmktr.Text);
            bool eklenmısmı = false;
            if (!Satisiade)
            {
               
                if (satrsayısı > 0)
                {
                    for (int i = 0; i < satrsayısı; i++)
                    {
                        if (DataGridSatis.Rows[i].Cells["Barkod"].Value.ToString() == barkod)
                        {
                            double yeniAdet = miktar + Convert.ToDouble(DataGridSatis.Rows[i].Cells["Adet"].Value);
                            double yeniToplam = Math.Round(yeniAdet * Convert.ToDouble(DataGridSatis.Rows[i].Cells["Fiyat"].Value), 2);

                            DataGridSatis.Rows[i].Cells["Adet"].Value = yeniAdet;
                            DataGridSatis.Rows[i].Cells["Toplam"].Value = yeniToplam;

                            if (yeniAdet <= 0)
                            {
                                MessageBox.Show("Satılamaz. Stok yok.", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);


                                DataGridSatis.Rows.RemoveAt(i);
                            }



                            eklenmısmı = true;
                            break;
                        }
                    }
                }
                if (!eklenmısmı)
                {


                    if (urun.Miktar <= 0)
                    {
                        MessageBox.Show("stok miktarını kontrol ediniz");


                    }
                    else
                    {
                        DataGridSatis.Rows.Add();
                        int yeniSatirIndex = DataGridSatis.Rows.Count - 1;
                        DataGridSatis.Rows[yeniSatirIndex].Cells["Barkod"].Value = barkod;
                        DataGridSatis.Rows[yeniSatirIndex].Cells["ilaçadı"].Value = urun.UrunAd;
                        DataGridSatis.Rows[yeniSatirIndex].Cells["Birim"].Value = urun.Birim;
                        DataGridSatis.Rows[yeniSatirIndex].Cells["Fiyat"].Value = urun.SatisFiyat;
                        DataGridSatis.Rows[yeniSatirIndex].Cells["Adet"].Value = Convert.ToDouble(Texmktr.Text);
                        DataGridSatis.Rows[yeniSatirIndex].Cells["Miktar"].Value = urun.Miktar;
                        DataGridSatis.Rows[yeniSatirIndex].Cells["Toplam"].Value = miktar * (double)urun.SatisFiyat;
                        DataGridSatis.Rows[yeniSatirIndex].Cells["AlisFiyat"].Value = urun.AlisFiyatı;

                    }

                    
                }

                Satisiade = true;


            }
            else
            {
                if (satrsayısı > 0)
                {
                    for (int i = 0; i < satrsayısı; i++)
                    {
                        if (DataGridSatis.Rows[i].Cells["Barkod"].Value.ToString() == barkod)
                        {
                            double yeniAdet = miktar + Convert.ToDouble(DataGridSatis.Rows[i].Cells["Adet"].Value);
                            double yeniToplam = Math.Round(yeniAdet * Convert.ToDouble(DataGridSatis.Rows[i].Cells["Fiyat"].Value), 2);

                            DataGridSatis.Rows[i].Cells["Adet"].Value = yeniAdet;
                            DataGridSatis.Rows[i].Cells["Toplam"].Value = yeniToplam;
                            eklenmısmı = true;
                            break;
                        }
                    }
                }
                if (!eklenmısmı)
                {
                    DataGridSatis.Rows.Add();
                    int yeniSatirIndex = DataGridSatis.Rows.Count - 1;
                    DataGridSatis.Rows[yeniSatirIndex].Cells["Barkod"].Value = barkod;
                    DataGridSatis.Rows[yeniSatirIndex].Cells["ilaçadı"].Value = urun.UrunAd;
                    DataGridSatis.Rows[yeniSatirIndex].Cells["Birim"].Value = urun.Birim;
                    DataGridSatis.Rows[yeniSatirIndex].Cells["Fiyat"].Value = urun.SatisFiyat;
                    DataGridSatis.Rows[yeniSatirIndex].Cells["Adet"].Value = Convert.ToDouble(Texmktr.Text);
                    DataGridSatis.Rows[yeniSatirIndex].Cells["Miktar"].Value = urun.Miktar;
                    DataGridSatis.Rows[yeniSatirIndex].Cells["Toplam"].Value = Math.Round(miktar * (double)urun.SatisFiyat, 2);
                    DataGridSatis.Rows[yeniSatirIndex].Cells["AlisFiyat"].Value = urun.AlisFiyatı;
                }

            }


        }




        private void Sil_Click(object sender, EventArgs e)
        {
            int butonid = Convert.ToInt16(sender.ToString().Substring(19, sender.ToString().Length - 19));
            var guncel = db.HizliUrun.Find(butonid);
            guncel.Barkod = "_";
            guncel.UrunAd = "_";
            guncel.Fiyat = 0;
            db.SaveChanges();
            double fiyat = 0;
            Button b = this.Controls.Find("Bh" + butonid, true).FirstOrDefault() as Button;
            b.Text = "_" + "\n" + "_" + "\n" + fiyat.ToString("C2");


        }

        private void Bnx_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Text == ",")
            {
                int virgul = Tbnn.Text.Count(x => x == ',');
                if (virgul < 1)
                {
                    Tbnn.Text += b.Text;
                }
            }
            else if (b.Text == "<")
            {
                if (Tbnn.Text.Length > 0)
                {
                    Tbnn.Text = Tbnn.Text.Substring(0, Tbnn.Text.Length - 1);

                }
            }
            else
            {
                Tbnn.Text += b.Text;
            }

        }

        private void Bbarkod_Click(object sender, EventArgs e)
        {

            if (Tbnn.Text != null)
            {
                string barkod = Tbnn.Text;
                if (db.Urun.Any(a => a.Barkod == Tbnn.Text))
                {
                    var urun = db.Urun.Where(a => a.Barkod == Tbnn.Text).FirstOrDefault();
                    UrunGetirlisteye(urun, Tbnn.Text, Convert.ToDouble(Texmktr.Text));
                    GenelToplam();
                    Tbnn.Clear();
                    Texbrkd.Focus();
                    Texmktr.Text = "1";

                }
                else
                {
                    FurunGiris f = (FurunGiris)Application.OpenForms["FurunGiris"];
                    if (f == null)
                    {
                        DialogResult onay = MessageBox.Show("ürün kayıtlı değil  ,Ürün ekleme  Sayfasına Geçilsin mi ? ", "BİLGİLENDİRME", MessageBoxButtons.YesNo);
                        if (onay == DialogResult.Yes)
                        {
                            f = new FurunGiris();
                            f.TexBarkod.Text = barkod;
                            f.ShowDialog();
                        }


                    }
                    else
                    {

                        f.TexBarkod.Text = barkod;
                        f.Focus();


                    }
                }



            }


        }


        private void Badet_Click(object sender, EventArgs e)
        {
            if (Tbnn.Text != "")
            {
                Texmktr.Text = Tbnn.Text;
                Texbrkd.Clear();
                Texbrkd.Focus();
                Tbnn.Clear();
            }
            else
            {
                MessageBox.Show("Geçersiz İşlem");
            }
        }

        private void Bodenen_Click(object sender, EventArgs e)
        {
            if (Tbnn.Text != "")
            {
                if (Islemler.DoubleYap(Texttutar.Text) > Islemler.DoubleYap(Tbnn.Text))
                {
                    double tutar = double.Parse(Tbnn.Text);
                    Todnen.Text = tutar.ToString("C2");
                    double sonuc = Islemler.DoubleYap(Texttutar.Text) - Islemler.DoubleYap(Tbnn.Text);
                    Tpraust.Text = Math.Abs(sonuc).ToString("C2");
                    Labelson.Text = "Ödenmesi \n beklenen \n Tutar";
                    Tbnn.Clear();
                    Texbrkd.Focus();
                }
                else
                {

                    double sonuc = Islemler.DoubleYap(Texttutar.Text) - Islemler.DoubleYap(Tbnn.Text);
                    double tutar = double.Parse(Tbnn.Text);
                    Todnen.Text = tutar.ToString("C2");
                    Tpraust.Text = Math.Abs(sonuc).ToString("C2");
                    Labelson.Text = "Para Üstü";
                    Tbnn.Clear();
                    Texbrkd.Focus();
                }


            }
            else
            {
                MessageBox.Show("Geçersiz İşlem");
            }
        }


       

        private void Biade_Click(object sender, EventArgs e)
        {
            if (CheckIslm.Checked)
            {
                CheckIslm.Checked = false;
                CheckIslm.Text = "Satış Yapılıyor";


            }
            else
            {
                CheckIslm.Checked = true;
                CheckIslm.Text = "İADE İŞLEMİ YAPILIYOR";
            }
        }

        private void Btemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
        public void Temizle()
        {
            Texmktr.Text = "1";
            Texbrkd.Clear();
            Todnen.Clear();
            Tpraust.Clear();
            Tbnn.Clear();
            Texttutar.Clear();
            CheckIslm.Checked = false;
            DataGridSatis.Rows.Clear();
            Texbrkd.Focus();

        }

        public void SatisYap(string Odemesekli)
        {



            // Satış İşlemleri 
            int? İslemno = db.Islem.First().IslemNo;
           

            int Satirsayisi = DataGridSatis.Rows.Count;
            bool Satisiade = CheckIslm.Checked;

            double toplamAlisFiyat = 0;


          
            for (int i = 0; i < DataGridSatis.Rows.Count; i++)
            {
              
                double tbn = Convert.ToDouble(DataGridSatis.Rows[i].Cells["Miktar"].Value.ToString());
                double adet = Convert.ToDouble(DataGridSatis.Rows[i].Cells["Adet"].Value.ToString());
               
                string urunAdi = DataGridSatis.Rows[i].Cells["ilaçadı"].Value.ToString();
                Satis satis = new Satis();
                var Barkod = DataGridSatis.Rows[i].Cells["Barkod"].Value.ToString();
                double Toplam = Convert.ToDouble( DataGridSatis.Rows[i].Cells["Toplam"].Value.ToString());
                var urunBilgi = db.Urun.FirstOrDefault(x => x.Barkod == Barkod);
                double mktr = (double)urunBilgi.Miktar;
                if (adet > mktr)
                {
                    MessageBox.Show($"\"{urunBilgi.UrunAd}\" Stokta yeterli ürün bulunmamaktadır. Satılacak adet stok miktarından fazla olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    foreach (DataGridViewRow row in DataGridSatis.Rows)
                    {
                        if (row.Cells["Barkod"].Value.ToString() == Barkod)
                        {
                            // Tutar güncelleme işlemi
                            double urunToplam = Islemler.DoubleYap(row.Cells["Toplam"].Value.ToString());
                            double mevcutTutar = Islemler.DoubleYap(Texttutar.Text);
                            double yeniTutar = mevcutTutar - urunToplam;
                            Texttutar.Text = yeniTutar.ToString();
                            DataGridSatis.Rows.Remove(row);
                            break;
                        }
                    }
                }
                satis.IslemNo = İslemno;
                    satis.UrunAd = urunAdi;
                    satis.Birim_ = DataGridSatis.Rows[i].Cells["Birim"].Value.ToString();
                    satis.Barkod = Barkod;
                    satis.AlisFiyatı = Islemler.DoubleYap(DataGridSatis.Rows[i].Cells["AlisFiyat"].Value.ToString());
                    satis.SatisFiyat = Islemler.DoubleYap(DataGridSatis.Rows[i].Cells["Fiyat"].Value.ToString());
                    satis.Miktar = adet;
                    satis.Toplam = Islemler.DoubleYap(DataGridSatis.Rows[i].Cells["Toplam"].Value.ToString());



                    satis.OdemeSekli = Odemesekli;
                    satis.Iade = Satisiade;
                    satis.Tarih = DateTime.Now;
                    satis.Kullanici = Lkullanıcı.Text;


                    double? yeniMiktar = 0;
                  
                    if (!Satisiade)
                    {
                        yeniMiktar = Islemler.StokAzalt(DataGridSatis.Rows[i].Cells["Barkod"].Value.ToString(), Islemler.DoubleYap(DataGridSatis.Rows[i].Cells["Adet"].Value.ToString()), db);

                    }
                    else
                    {
                        yeniMiktar = Islemler.StokArtir(DataGridSatis.Rows[i].Cells["Barkod"].Value.ToString(), Islemler.DoubleYap(DataGridSatis.Rows[i].Cells["Adet"].Value.ToString()));

                    }
                toplamAlisFiyat = Islemler.DoubleYap(Texttutar.Text);
                db.Satis.Add(satis);
                db.SaveChanges();

               

                
            }
            
                                                                                                                                                                                                                                                                                                           
            IslemOzet io = new IslemOzet
            {
                IslemNo = İslemno,
                Iade = Satisiade,
                AlısFiyatToplam = toplamAlisFiyat
            };




            if (!Satisiade)
            {
                io.Aciklama = Odemesekli + "Satış";

            }
            else
            {
                io.Aciklama = "İade işlemi(" + Odemesekli + ")";
            }
            io.OdemeSekli = Odemesekli;
            io.Kullanici = Lkullanıcı.Text;
            io.Tarih = DateTime.Now;
            switch (Odemesekli)
            {
                case "Nakit":
                    io.Nakit = Islemler.DoubleYap(Texttutar.Text);
                    io.Kart = 0; break;
                case "Kart":
                    io.Kart = Islemler.DoubleYap(Texttutar.Text);
                    io.Nakit = 0; break;
                case "Kart-Nakit":
                    io.Nakit = Islemler.DoubleYap(Lnakit.Text);
                    io.Kart = Islemler.DoubleYap(Lkart.Text);
                  
                        break;

            }


            var İslemnoartir = db.Islem.First();
            İslemnoartir.IslemNo += 1;
            db.IslemOzet.Add(io);
            db.SaveChanges();

            MessageBox.Show("Satış işlemi Tamamlandı");
        



        }

        private void Btnnakıt_Click(object sender, EventArgs e)
        {
             

            if (Texttutar.Text != "")
            {
                SatisYap("Nakit");
                Temizle();
            }

            else
            {
                MessageBox.Show("boş Ürün Satılamaz");
            }

        }

        private void Btnkart_Click(object sender, EventArgs e)
        {
            if (Texttutar.Text != "")
            {
                SatisYap("Kart");
                Temizle();
            }
            else
            {
                MessageBox.Show("boş Ürün Satılamaz");
            }
        }

        private void Tkartnakit_Click(object sender, EventArgs e)
        {
            FnakitKart f = new FnakitKart();
            f.ShowDialog();


        }

        private void Texmktr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08)
            {
                e.Handled = true;

            }
        }



        private void CheckIslm_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckIslm.Checked)
            {
                CheckIslm.Text = "iade yapılıyor";

            }
            else
            {
                CheckIslm.Text = "Satış yapılıyor";
            }
        }

        private void Bh1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {


                Button b = (Button)sender;
                if (!b.Text.StartsWith("_"))
                {
                    int butonıd = Convert.ToInt16(b.Name.ToString().Substring(2, b.Name.Length - 2));
                    ContextMenuStrip s = new ContextMenuStrip();
                    ToolStripMenuItem sil = new ToolStripMenuItem
                    {
                        Text = "Temizle - Buton No:" + butonıd.ToString()
                    };
                    sil.Click += Sil_Click;
                    s.Items.Add(sil);
                    this.ContextMenuStrip = s;

                }

            }
        }

       
    }
}

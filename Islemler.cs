using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace VetRx
{
    internal class Islemler
    {
        public static double DoubleYap(string deger)
        {
            double.TryParse(deger, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat, out double sonuc);
            return Math.Round(sonuc, 2);
        }

        public static double? StokAzalt(string Barkod, double Miktar, BarkodDbEntities db)
        {
                        
                var urubvilgi = db.Urun.SingleOrDefault(x => x.Barkod == Barkod);

                if (urubvilgi != null)
                {
                   
                    if ((urubvilgi.Miktar - Miktar) >= 0)
                    {
                        urubvilgi.Miktar -= Miktar;
                       
                    }
                   
                    db.SaveChanges();


                }
                else
                {

                    MessageBox.Show("İşlem  Tamamlanıyor!");
                }
                return urubvilgi.Miktar;
            

        }
        public static double? StokArtir(string Barkod, double Miktar)
        {
            using (var db = new BarkodDbEntities())
            {

                var urubvilgi = db.Urun.SingleOrDefault(x => x.Barkod == Barkod);
                urubvilgi.Miktar += Miktar;
                if (urubvilgi == null)
                {
                    urubvilgi.Miktar += 1;
                }
                db.SaveChanges();
                return urubvilgi.Miktar;

            }
        }
        public static void StokGiris(string Barkod, string Urunıd, string Birim, double Miktar, string Kullanici)
        {
            using (var Db = new BarkodDbEntities())
            {
                try
                {
                    StokHareket Sh = new StokHareket
                    {
                        Barkod = Barkod,
                        UrunAd_ = Urunıd,
                        Birim = Birim,
                        Miktar = Miktar,
                        Kullanici = Kullanici,
                        Tarih = DateTime.Now
                    };


                    Db.StokHareket.Add(Sh);
                    Db.SaveChanges();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Stok hareketi eklenirken bir hata oluştu: " + ex.Message);
                }

            }
        }
        public static int KartKomisyonn()
        {
            int sonuc = 0;
            using (var db = new BarkodDbEntities())
            {
                if (db.Sabit.Any())
                {
                    sonuc = Convert.ToInt16(db.Sabit.First().KartKomisyon);


                }
                else
                {
                    sonuc = 0;

                }


            }
            return sonuc;
        }

        public static void SabitVarsayilan()
        {
            using (var Db = new BarkodDbEntities())
            {
                if (!Db.Sabit.Any())
                {
                    Sabit s = new Sabit
                    {
                        KartKomisyon = 0
                    };
                    Db.Sabit.Add(s);
                    Db.SaveChanges();

                }


            }
        }

        public static void Backup()
        {
            SaveFileDialog save = new SaveFileDialog
            {
                Filter = "Veri yedek dosyası|0.bak",
                FileName = "VetRx_satıs_Programi_" + DateTime.Now.ToShortDateString()
            };
            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    if (File.Exists(save.FileName))
                    {
                        File.Delete(save.FileName);
                    }
                    var dbHedef = save.FileName;
                    string dbKaynak = Application.StartupPath + @"\BarkodDb.mdf";
                    using (var db = new BarkodDbEntities())
                    {
                        var cmd = @"BACKUP DATABASE[" + dbKaynak + "] TO DISK='" + dbHedef + "'";
                        db.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, cmd);
                    }
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Yedekleme Tamamlanmıştır");


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VetRx
{
    public partial class Frapor : Form
    {
        public Frapor()
        {
            InitializeComponent();
        }

        private void Btngstr_Click(object sender, EventArgs e)
        {
            Cursor.Current= Cursors.WaitCursor;
            DateTime Balangıc = DateTime.Parse(Dtbaslan.Value.ToShortDateString());
            DateTime Bitis = DateTime.Parse(Dtbitis.Value.ToShortDateString());
            Bitis = Bitis.AddDays(1);
            using ( var Db= new BarkodDbEntities())
            {
              

                if (Listuru.SelectedIndex==0)//Tümünü getir
                {
                    Db.IslemOzet.Where(x => x.Tarih >= Balangıc && x.Tarih <= Bitis).OrderByDescending(x=>x.Tarih).Load();
                    var Islemozet = Db.IslemOzet.Local.ToList();
                    Grwdliste1.DataSource = Islemozet;
                   

                    Text1.Text = Convert.ToDouble(Islemozet.Where(x => x.Iade == false ).Sum(x => x.Nakit)).ToString("C2");
                    Text2.Text = Convert.ToDouble(Islemozet.Where(x => x.Iade == false  ).Sum(x => x.Kart)).ToString("C2");

                    Text4.Text = Convert.ToDouble(Islemozet.Where(x => x.Iade == true ).Sum(x => x.Nakit)).ToString("C2");
                    Text3.Text = Convert.ToDouble(Islemozet.Where(x => x.Iade == true).Sum(x => x.Kart)).ToString("C2");
                 

                    double toplamNakit = Convert.ToDouble( Islemozet.Where(x => x.Iade == false).Sum(x => x.Nakit));
                    double toplamKart = Convert.ToDouble( Islemozet.Where(x => x.Iade == false).Sum(x => x.Kart));
                    double toplamIadeNakit = Convert.ToDouble( Islemozet.Where(x => x.Iade == true).Sum(x => x.Nakit));
                    double toplamIadeKart = Convert.ToDouble(Islemozet.Where(x => x.Iade == true).Sum(x => x.Kart)); 

                   

                    double kalan = (toplamNakit + toplamKart) - (toplamIadeNakit + toplamIadeKart);
                    Tkalan.Text = kalan.ToString("C2");


                }
                else if (Listuru.SelectedIndex == 1)
                {
                    Tkalan.Clear();
                    Db.IslemOzet.Where(x => x.Tarih >= Balangıc && x.Tarih <= Bitis && x.Iade==false).Load();
                    var Islemozet = Db.IslemOzet.Local.ToBindingList();
                    Grwdliste1.DataSource = Islemozet;
                   


                    Text1.Text = Convert.ToDouble(Islemozet.Where(x => x.Iade == false ).Sum(x => x.Nakit)).ToString("C2");
                    Text2.Text = Convert.ToDouble(Islemozet.Where(x => x.Iade == false ).Sum(x => x.Kart)).ToString("C2");

                    Text4.Text = Convert.ToDouble(Islemozet.Where(x => x.Iade == true).Sum(x => x.Nakit)).ToString("C2");
                    Text3.Text = Convert.ToDouble(Islemozet.Where(x => x.Iade == true).Sum(x => x.Kart)).ToString("C2");
                }
                else if (Listuru.SelectedIndex == 2)
                {
                    Tkalan.Clear();
                    Db.IslemOzet.Where(x => x.Tarih >= Balangıc && x.Tarih <= Bitis && x.Iade == true).Load();
                    var Islemozet = Db.IslemOzet.Local.ToBindingList();
                    Grwdliste1.DataSource = Islemozet;
                  


                    Text1.Text = Convert.ToDouble(Islemozet.Where(x => x.Iade == false).Sum(x => x.Nakit)).ToString("C2");
                    Text2.Text = Convert.ToDouble(Islemozet.Where(x => x.Iade == false).Sum(x => x.Kart)).ToString("C2");

                    Text4.Text = Convert.ToDouble(Islemozet.Where(x => x.Iade == true).Sum(x => x.Nakit)).ToString("C2");
                    Text3.Text = Convert.ToDouble(Islemozet.Where(x => x.Iade == true).Sum(x => x.Kart)).ToString("C2");
                }

                
            }





            Cursor.Current = Cursors.Default;
        }

        private void Frapor_Load(object sender, EventArgs e)
        {
            Listuru.SelectedIndex = 0;
            Text7.Text = Islemler.KartKomisyonn().ToString();


        }

        private void Grwdliste1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex==2)
            {
                if (e.Value is bool value)
                {
                    e.Value = (value) ? "Evet" : "Hayır";
                    e.FormattingApplied = true;
                }
            }
        }

      

        private void Btnrapor_Click(object sender, EventArgs e)
        {
            Raporlar.Baslik = "Genel Rapor";
            Raporlar.SatisKart = Text2.Text;
            Raporlar.SatisNakit = Text1.Text;
            Raporlar.IadeKart = Text3.Text;
            Raporlar.IadeNakit = Text4.Text;
            Raporlar.KartKomisyon = Text7.Text;
            Raporlar.TarihBaslangic = Dtbaslan.Value.ToShortDateString();
            Raporlar.TarihBitis = Dtbitis.Value.ToShortDateString();

            Raporlar.RaporSayfasiRapor(Grwdliste1);
        }

      

        private void DetayGösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Grwdliste1.Rows.Count>0)
            {
                int Islemno =Convert.ToInt32(Grwdliste1.CurrentRow.Cells["IslemNo"].Value.ToString());
                if (Islemno!=0)
                {
                    Fdetaycs f = new Fdetaycs
                    {
                        Islemno = Islemno
                    };
                    f.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Hata!");
                }
            }
        }
    }
}

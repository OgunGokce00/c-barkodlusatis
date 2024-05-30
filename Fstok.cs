using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VetRx
{
    public partial class Fstok : Form
    {
        public Fstok()
        {
            InitializeComponent();
        }
      
        private void Btnara_Click(object sender, EventArgs e)
        {
            if (CmdBox.Text==null)
            {
                MessageBox.Show("Lütfen Seçim yapınız");
            }

            else if (CmdBox.SelectedIndex == 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                Grwdliste.DataSource = null;
                using (var Db = new BarkodDbEntities())
                {

                    Db.Urun.OrderBy(x => x.Miktar).Load();
                    Grwdliste.DataSource = Db.Urun.Local.ToBindingList();
                    Grwdliste.Columns["Birim"].Visible = false;



                }
                Cursor.Current = Cursors.Default;
            }
            else if (CmdBox.SelectedIndex == 1)
            {
               Cursor.Current = Cursors.WaitCursor;
                Grwdliste.DataSource = null;
                using (var Db = new BarkodDbEntities())
                {
                    DateTime baslangıc = DateTime.Parse(Databaslan.Value.ToShortDateString());
                    DateTime bitis = DateTime.Parse(Databitis.Value.ToShortDateString());

                    Db.StokHareket.OrderByDescending(x => x.Tarih).Where(x => x.Tarih >= baslangıc && x.Tarih <= bitis).Load();
                    Grwdliste.DataSource = Db.StokHareket.Local.ToBindingList();
                    Grwdliste.Columns["Birim"].Visible = false;
                }
                Cursor.Current = Cursors.WaitCursor;
            }


          else if (CmdBox.SelectedIndex == 2)
          {
                Cursor.Current = Cursors.WaitCursor;
                using (var Db = new BarkodDbEntities())
                {
                    DateTime baslangıc = DateTime.Parse(Databaslan.Value.ToShortDateString());
                    DateTime bitis = DateTime.Parse(Databitis.Value.ToShortDateString());

                    Db.Urun.OrderByDescending(x => x.Tarih).Where(x => x.Tarih >= baslangıc && x.Tarih <= bitis).Load();
                    Grwdliste.DataSource = Db.Urun.Local.ToBindingList();
                    Grwdliste.Columns["Birim"].Visible = false;
                }
                Cursor.Current = Cursors.WaitCursor;

          }

        }
        private void Textara_TextChanged(object sender, EventArgs e)
        {
            using (var Db = new BarkodDbEntities())
            {
                if (Textara.Text != null && Textara.Text.Length>=2)
                {
                    string urunad = Textara.Text;
                    var urunler = Db.Urun.Where(a => a.Barkod.Contains(urunad)).ToList();
                    Grwdliste.DataSource = urunler;
                }
            }

        }

       
    }
}


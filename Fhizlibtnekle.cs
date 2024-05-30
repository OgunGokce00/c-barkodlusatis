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
    public partial class Fhizlibtnekle : Form
    {
        public Fhizlibtnekle()
        {
            InitializeComponent();
        }
        readonly BarkodDbEntities Db =new BarkodDbEntities();

        private void Texturunara_TextChanged(object sender, EventArgs e)
        {
            if (Texturunara.Text !=null)
            {  
                 string urunad= Texturunara.Text;
                var urunler = Db.Urun.Where(a => a.Barkod.Contains(urunad)).ToList();
                 DataGridUrunler.DataSource = urunler;
            }
        }

        private void DataGridUrunler_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridUrunler.Rows.Count>0)
            {
                string barkod = DataGridUrunler.CurrentRow.Cells["Barkod"].Value.ToString();
                string  urunad = DataGridUrunler.CurrentRow.Cells["UrunAd"].Value.ToString();
                double fiyat =  Convert.ToDouble( DataGridUrunler.CurrentRow.Cells["SatisFiyat"].Value.ToString());
                int id = Convert.ToInt16(LbutonId.Text);
                var guncellenecek = Db.HizliUrun.Find(id);
                guncellenecek.Barkod= barkod;
                guncellenecek.UrunAd = urunad;
                guncellenecek.Fiyat= fiyat;
                Db.SaveChanges();
                MessageBox.Show("Buton Tanımlanmiştır");
                Fsatis f = (Fsatis)Application.OpenForms["Fsatis"];
                if (f!=null)
                {
                    Button b = f.Controls.Find("Bh" + id, true).FirstOrDefault() as Button;
                    b.Text= urunad+"\n"+ fiyat.ToString("C2");
                }


            }
        }

        private void Chtumu_CheckedChanged(object sender, EventArgs e)
        {
            if (Chtumu.Checked)
            {
                DataGridUrunler.DataSource = Db.Urun.ToList();
                DataGridUrunler.Columns["AlisFiyatı"].Visible = false;
                DataGridUrunler.Columns["SatisFiyat"].Visible = false;
                DataGridUrunler.Columns["Kullanici"].Visible = false;
                DataGridUrunler.Columns["Tarih"].Visible = false;
                DataGridUrunler.Columns["Birim"].Visible = false;
                DataGridUrunler.Columns["UrunId"].Visible = false;



            }
            else
            {
                DataGridUrunler.DataSource=null;
            }
           

        }

       
    }
}

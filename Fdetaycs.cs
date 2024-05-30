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
    public partial class Fdetaycs : Form
    {
        public Fdetaycs()
        {
            InitializeComponent();
        }
        public int Islemno { get; set; }

        private void Fdetaycs_Load(object sender, EventArgs e)
        {
            LislemNo.Text = "İşlem No :" + Islemno.ToString();
            using (var Db =  new BarkodDbEntities())
            {
                Grwdliste3.DataSource = Db.Satis.Select(s=> new{s.IslemNo,s.UrunAd, s.OdemeSekli,s.Miktar,s.SatisFiyat,s.Toplam}).Where(x => x.IslemNo == Islemno).ToList();
            }
        }
    }
}

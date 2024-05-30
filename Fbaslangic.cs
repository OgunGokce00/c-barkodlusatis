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
    public partial class Fbaslangic : Form
    {
        public Fbaslangic()
        {
            InitializeComponent();
        }
       
        private void Btnn1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Fsatis f = new Fsatis();
            f.Lkullanıcı.Text = Lklnc.Text;
            f.ShowDialog();
           
        }

       

        private void Btnn2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Frapor f = new Frapor();
            f.Lkllnc.Text = Lklnc.Text;
            f.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void Btnn3_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Fstok f = new Fstok();
            f.Lkullanici.Text=Lklnc.Text;
            f.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void Btnn4_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            FurunGiris f = new FurunGiris();
            f.Lkullanici.Text = Lklnc.Text;
            f.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void Btnn9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btnn6_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Ffiyatguncelle f = new Ffiyatguncelle();
            f.ShowDialog(this);
            Cursor.Current=Cursors.Default;
        }

        private void Btnn5_Click(object sender, EventArgs e)
        {
            Fayarlar f = new Fayarlar();
            f.ShowDialog();


        }

        private void Btnn7_Click(object sender, EventArgs e)
        {
            Islemler.Backup();
        }

        private void Btnn8_Click(object sender, EventArgs e)
        {
            Flogin f = new Flogin();

            f.Show();
            this.Hide();
                
                
        }

        private void Fbaslangic_Load(object sender, EventArgs e)
        {
            
        }
    }
}

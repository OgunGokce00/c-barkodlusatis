using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VetRx
{
    static class Raporlar
    {
        public static string Baslik { get; set; }
        public  static string TarihBaslangic { get; set; }
        public  static string TarihBitis { get; set; }
        public static string  SatisNakit { get; set; }
        public static string SatisKart { get; set; }
        public static string IadeNakit { get; set; }
        public static string IadeKart{ get; set; }
        public static string KartKomisyon { get; set; }

        public static void RaporSayfasiRapor(DataGridView dgv)
        {
            try
            {



                Cursor.Current = Cursors.WaitCursor;

                List<IslemOzet> list = new List<IslemOzet>();
                list.Clear();
                for (int i = 0; i < dgv.Rows.Count; i++)
                {

                    list.Add(new IslemOzet
                    {
                        IslemNo = dgv.Rows[i].Cells["IslemNo"].Value != null ? Convert.ToInt32(dgv.Rows[i].Cells["IslemNo"].Value.ToString()) : 0,
                        Iade = dgv.Rows[i].Cells["Iade"].Value != null && Convert.ToBoolean(dgv.Rows[i].Cells["Iade"].Value),
                        OdemeSekli = dgv.Rows[i].Cells["OdemeSekli"].Value != null ? dgv.Rows[i].Cells["OdemeSekli"].Value.ToString() : "",
                        Nakit = dgv.Rows[i].Cells["Nakit"].Value != null ? Islemler.DoubleYap(dgv.Rows[i].Cells["Nakit"].Value.ToString()) : 0.0,
                        Kart = dgv.Rows[i].Cells["Kart"].Value != null ? Islemler.DoubleYap(dgv.Rows[i].Cells["Kart"].Value.ToString()) : 0.0,
                        AlısFiyatToplam = dgv.Rows[i].Cells["AlısFiyatToplam"].Value != null ? Islemler.DoubleYap(dgv.Rows[i].Cells["AlısFiyatToplam"].Value.ToString()) : 0.0,
                        Aciklama = dgv.Rows[i].Cells["Aciklama"].Value != null ? dgv.Rows[i].Cells["Aciklama"].Value.ToString() : "",
                        Tarih = dgv.Rows[i].Cells["Tarih"].Value != null ? Convert.ToDateTime(dgv.Rows[i].Cells["Tarih"].Value.ToString()) : DateTime.MinValue,
                        Kullanici = dgv.Rows[i].Cells["Kullanici"].Value != null ? dgv.Rows[i].Cells["Kullanici"].Value.ToString() : ""
                    });





                }
                ReportDataSource rs = new ReportDataSource
                {
                    Name = "dsGenelRapor",
                    Value = list
                };


                fRaporGoste f = new fRaporGoste();
                f.reportViewer1.LocalReport.DataSources.Clear();
                f.reportViewer1.LocalReport.DataSources.Add(rs);
                f.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"/rpGenelRapor.rdlc";
                ReportParameter[] prm = new ReportParameter[8];
                prm[0] = new ReportParameter("Baslik", Baslik);
                prm[1] = new ReportParameter("TarihBaslangic", TarihBaslangic);
                prm[2] = new ReportParameter("TarihBitis", TarihBitis);
                prm[3] = new ReportParameter("SatisKart", SatisKart);
                prm[4] = new ReportParameter("SatisNakit",SatisNakit);
                prm[5] = new ReportParameter("IadeKart", IadeKart);
                prm[6] = new ReportParameter("IadeNakit", IadeNakit);
                prm[7] = new ReportParameter("KartKomisyon", KartKomisyon);

                f.reportViewer1.LocalReport.SetParameters(prm);

                f.ShowDialog();

                Cursor.Current = Cursors.Default;


            }
            catch (Exception ex)
            {

                MessageBox.Show("HATA" + ex);
            }
        }

    }
}

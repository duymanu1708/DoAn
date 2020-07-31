using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DoAn
{
    public partial class frmTongChi : Form
    {
        public frmTongChi()
        {
            InitializeComponent();
        }
        public string MaHD;
        private void frmTongChi_Load(object sender, EventArgs e)
        {
            var query = "SELECT SANPHAM.MaSP, SANPHAM.TenSP, SANPHAM.SoLuong, SANPHAM.DonVi, SANPHAM.GiaGoc, NSX.MaNSX, SANPHAM.SoLuong * SANPHAM.GiaGoc AS TongChi FROM SANPHAM INNER JOIN NSX ON SANPHAM.MaNSX = NSX.MaNSX";
            SqlDataAdapter da = new SqlDataAdapter(query, Modules.cnn);
            try
            {
                DataTable tbTongChi = new DataTable();
                da.Fill(tbTongChi);
                TongChi rpt = new TongChi();
                rpt.SetDataSource(tbTongChi);

            }catch(SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{
    public partial class frmThongKeDoanhThu : Form
    {
        public frmThongKeDoanhThu()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            TabPage p = (TabPage)this.Parent;
            TabControl tabMain = (TabControl)p.Parent;
            tabMain.TabPages.Remove(p);
        }

        private void frmThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            classKetNoi kn = new classKetNoi();
            dt = kn.laybang("SELECT DONHANG.MaHD, KHACHHANG.TenKH, KHACHHANG.MaKH, KHACHHANG.SoDT, SANPHAM.TenSP, SANPHAM.DonVi, SANPHAM.DonGia, CTHD.SoLuong, CTHD.SoLuong * SANPHAM.DonGia AS ThanhTien FROM DONHANG INNER JOIN CTHD ON DONHANG.MaHD = CTHD.MaHD INNER JOIN KHACHHANG ON DONHANG.MaKH = KHACHHANG.MaKH INNER JOIN SANPHAM ON CTHD.MaSP = SANPHAM.MaSP");
            ThongKeDoanhThu RP = new ThongKeDoanhThu();
            RP.SetDataSource(dt);
            crystalReportViewer1.ReportSource = RP;
        }
    }
}

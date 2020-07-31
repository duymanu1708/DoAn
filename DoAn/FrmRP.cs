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
    public partial class frmRP : Form
    {
        public frmRP()
        {
            InitializeComponent();
        }


        private void FrmRP_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            classKetNoi kn = new classKetNoi();
            dt = kn.laybang("SELECT DONHANG.MaHD, KHACHHANG.TenKH, KHACHHANG.MaKH, KHACHHANG.SoDT, SANPHAM.TenSP, SANPHAM.DonVi, SANPHAM.DonGia, CTHD.SoLuong, CTHD.SoLuong * SANPHAM.DonGia AS ThanhTien, DONHANG.NgayLap FROM DONHANG INNER JOIN CTHD ON DONHANG.MaHD = CTHD.MaHD INNER JOIN KHACHHANG ON DONHANG.MaKH = KHACHHANG.MaKH INNER JOIN SANPHAM ON CTHD.MaSP = SANPHAM.MaSP where DONHANG.MaHD=CTHD.MaHD");
            InHD RP = new InHD();
            RP.SetDataSource(dt);
            crystalReportViewer1.ReportSource = RP;
        }

        private void btnTimkiemRP_Click(object sender, EventArgs e)
        {
            if(txtTimkiemRP.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập mã khách hàng!");
            }
            else
            {
                DataTable dt = new DataTable();
                classKetNoi kn = new classKetNoi();
                dt = kn.laybang("SELECT DONHANG.MaHD, KHACHHANG.TenKH, KHACHHANG.MaKH, KHACHHANG.SoDT, SANPHAM.TenSP, SANPHAM.DonVi, SANPHAM.DonGia, CTHD.SoLuong, CTHD.SoLuong * SANPHAM.DonGia AS ThanhTien, DONHANG.NgayLap FROM DONHANG INNER JOIN CTHD ON DONHANG.MaHD = CTHD.MaHD INNER JOIN KHACHHANG ON DONHANG.MaKH = KHACHHANG.MaKH INNER JOIN SANPHAM ON CTHD.MaSP = SANPHAM.MaSP where DONHANG.MaHD=CTHD.MaHD and KHACHHANG.MaKH='" + txtTimkiemRP.Text + "'");
                InHD RP = new InHD();
                RP.SetDataSource(dt);
                crystalReportViewer1.ReportSource = RP;
            }
            
        }
    }
}

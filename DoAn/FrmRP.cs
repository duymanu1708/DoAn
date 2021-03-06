﻿using System;
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
        public string MaHD;

        private void FrmRP_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            classKetNoi kn = new classKetNoi();
            dt = kn.laybang("SELECT DONHANG.MaHD, KHACHHANG.TenKH, KHACHHANG.MaKH, KHACHHANG.SoDT, SANPHAM.TenSP, SANPHAM.DonVi, SANPHAM.DonGia, CTHD.SoLuong, CTHD.SoLuong * SANPHAM.DonGia AS ThanhTien, DONHANG.NgayLap FROM DONHANG INNER JOIN CTHD ON DONHANG.MaHD = CTHD.MaHD INNER JOIN KHACHHANG ON DONHANG.MaKH = KHACHHANG.MaKH INNER JOIN SANPHAM ON CTHD.MaSP = SANPHAM.MaSP where DONHANG.MaHD='"+MaHD+"'");
            InHD RP = new InHD();
            RP.SetDataSource(dt);
            crystalReportViewer1.ReportSource = RP;
        }

    }
}

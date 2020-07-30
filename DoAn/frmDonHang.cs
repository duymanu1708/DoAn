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
    public partial class frmDonHang : Form
    {
        BindingManagerBase DSHD;
        public frmDonHang()
        {
            InitializeComponent();
        }
        DataTable tblKHACHHANG, tblSANPHAM, tblDONHANG, tblCTHD;

        private void btnThoat_Click(object sender, EventArgs e)
        {
            TabPage p = (TabPage)this.Parent;
            TabControl tabMain = (TabControl)p.Parent;
            tabMain.TabPages.Remove(p);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void frmDonHang_Load(object sender, EventArgs e)
        {
            tblKHACHHANG = new DataTable();
            daKH = new SqlDataAdapter("select * from KHACHHANG", Modules.cnnStr);
            tblSANPHAM = new DataTable();
            daSP = new SqlDataAdapter("select * from SANPHAM",Modules.cnnStr);
            tblDONHANG = new DataTable();
            daDH = new SqlDataAdapter("select * from DONHANG",Modules.cnnStr);
            tblCTHD = new DataTable();
            daCTHD = new SqlDataAdapter("select * from CTHD",Modules.cnnStr);
            try
            {
                daDH.Fill(tblDONHANG);
                daKH.Fill(tblKHACHHANG);
                daCTHD.Fill(tblCTHD);
                daSP.Fill(tblSANPHAM);
            }catch(SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            loadCTHD();
            var cmb = new SqlCommandBuilder(daDH);
            txtHoTen.DataBindings.Add("text", tblDONHANG, "TenKH", true);
            //txtDonGia.DataBindings.Add("float", tblDONHANG, "DonGia", true);
            txtMaKH.DataBindings.Add("text", tblDONHANG, "MaKH", true);
            //txtTenSP.DataBindings.Add("text", tblDONHANG, "TenSP", true);
            //txtThanhTien.DataBindings.Add("float", tblDONHANG, "Tong", true);
            //numSoLuong.DataBindings.Add("value", tblDONHANG, "SoLuong", true);
            dtNgayMua.Value= DateTime.Today;
            DSHD = this.BindingContext[tblDONHANG];

        }
        private void loadCTHD()
        {
            DataSet ds = new DataSet();
            ds.Tables.AddRange(new DataTable[] {tblDONHANG, tblKHACHHANG });
            DataRelation qh = new DataRelation("FK_KHACHHANG_DONHANG", tblDONHANG.Columns["MaKH"],tblKHACHHANG.Columns["MaKH"] );
            ds.Relations.Add(qh);
            DataColumn cTenKH = new DataColumn("TenKH", Type.GetType("System.String"), "Parent(FK_KHACHHANG_DONHANG).TenKH");
            tblDONHANG.Columns.Add(cTenKH);
            //DataSet ds1 = new DataSet();
            //ds1.Tables.AddRange(new DataTable[] { tblCTHD, tblDONHANG });
            //DataRelation qh1 = new DataRelation("FRK_DONHANG_CTHD", tblKHACHHANG.Columns["MaHD"], tblDONHANG.Columns["MaHD"]);
            //ds1.Relations.Add(qh1);
            //DataColumn cSoLuong = new DataColumn("SoLuong", Type.GetType("System.String"), "Parent(FRK_DONHANG_CTHD).SoLuong");
            //tblDONHANG.Columns.Add(cSoLuong);
            //DataColumn cTong = new DataColumn("Tong", Type.GetType("System.String"), "Parent(FRK_DONHANG_CTHD).Tong");
            //tblDONHANG.Columns.Add(cTong);
            //DataSet ds2 = new DataSet();
            //ds2.Tables.AddRange(new DataTable[] { tblSANPHAM, tblDONHANG });
            //DataRelation qh2 = new DataRelation("FRK_DONHANG_SANPHAM", tblKHACHHANG.Columns["MaSP"], tblDONHANG.Columns["MaSP"]);
            //ds2.Relations.Add(qh2);
            //DataColumn cTenSP = new DataColumn("TenSP", Type.GetType("System.String"), "Parent(FRK_DONHANG_SANPHAM).TenSP");
            //tblDONHANG.Columns.Add(cTenSP);
            //DataColumn cDonGia = new DataColumn("DonGIa", Type.GetType("System.String"), "Parent(FRK_DONHANG_SANPHAM).DonGIa");
            //tblDONHANG.Columns.Add(cDonGia);
            dgvTTHD.AutoGenerateColumns = false;
            dgvTTHD.DataSource = tblDONHANG;
        }

        private void dgvTTHD_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in dgvTTHD.Rows)
                r.Cells[0].Value = r.Index + 1;
        }

        SqlDataAdapter daKH, daDH, daCTHD, daSP;
        bool capNhat;
    }
}

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
        public frmDonHang()
        {
            InitializeComponent();
        }
        DataTable tblKHACHHANG, tblSANPHAM, tblDONHANG, tblCTHD;
        SqlDataAdapter daSP, daKH, daDH, daCTHD;
        bool capnhat = false;
        private void btnThoat_Click(object sender, EventArgs e)
        {
            TabPage p = (TabPage)this.Parent;
            TabControl tabMain = (TabControl)p.Parent;
            tabMain.TabPages.Remove(p);
        }
        BindingManagerBase DSHD;
        private void btnInHD_Click(object sender, EventArgs e)
        {
            frmRP f = new frmRP();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }
        private void frmDonHang_Load(object sender, EventArgs e)
        {
            tblKHACHHANG = new DataTable();
            daDH = new SqlDataAdapter("select * from KHACHHANG", Modules.cnnStr);
            tblSANPHAM = new DataTable();
            daSP = new SqlDataAdapter("select * from SANPHAM", Modules.cnnStr);
            tblDONHANG = new DataTable();
            daDH = new SqlDataAdapter("select * from DONHANG", Modules.cnnStr);
            tblCTHD = new DataTable();
            daCTHD = new SqlDataAdapter("select * from CTHD", Modules.cnnStr);
            try
            {
                daDH.Fill(tblDONHANG);
                daKH.Fill(tblKHACHHANG);
                daCTHD.Fill(tblCTHD);
                daSP.Fill(tblSANPHAM);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            //loadCTHD();
            var cmb = new SqlCommandBuilder(daDH);
            //txtHoTen.DataBindings.Add("text", tblCTHD, "TenKH", true);
            txtDonGia.DataBindings.Add("text", tblCTHD, "DonGia", true);
            //txtMaKH.DataBindings.Add("text", tblCTHD, "MaKH", true);
            //txtTenSP.DataBindings.Add("text", tblCTHD, "TenSP", true);
            txtThanhTien.DataBindings.Add("text", tblCTHD, "Tong", true);
            numSoLuong.DataBindings.Add("Value", tblCTHD, "SoLuong", true);
            //dtNgayMua.Value = DateTime.Today;
            DSHD = this.BindingContext[tblCTHD];
            enableButton();

        }
        private void loadCTHD()
        {
            DataSet ds = new DataSet();
            ds.Tables.AddRange(new DataTable[] { tblDONHANG, tblKHACHHANG });
            DataRelation qh = new DataRelation("FK_KHACHHANG_DONHANG", tblKHACHHANG.Columns["MaKH"], tblDONHANG.Columns["MaKH"]);
            ds.Relations.Add(qh);
            DataColumn cTenKH = new DataColumn("TenKH", Type.GetType("System.String"), "Parent(FK_KHACHHANG_DONHANG).TenKH");
            tblDONHANG.Columns.Add(cTenKH);

            DataSet ds1 = new DataSet();
            ds1.Tables.AddRange(new DataTable[] { tblCTHD, tblDONHANG });
            DataRelation qh1 = new DataRelation("FRK_DONHANG_CTHD", tblDONHANG.Columns["MaHD"],tblCTHD.Columns["MaHD"]);
            ds1.Relations.Add(qh1);
            DataColumn cTenKhachHang = new DataColumn("TenKH", Type.GetType("System.String"), "Parent(FRK_DONHANG_CTHD).TenKH");
            DataColumn cMaKH = new DataColumn("MaKH", Type.GetType("System.String"), "Parent(FRK_DONHANG_CTHD).MaKH");
            tblCTHD.Columns.Add(cTenKhachHang);
            tblCTHD.Columns.Add(cMaKH);

            DataSet ds2 = new DataSet();
            ds2.Tables.AddRange(new DataTable[] { tblCTHD, tblSANPHAM });
            DataRelation qh2 = new DataRelation("FRK_CTHD_SANPHAM", tblSANPHAM.Columns["MaSP"], tblCTHD.Columns["MaSP"]);
            ds2.Relations.Add(qh2);
            DataColumn cTenSP = new DataColumn("TenSP", Type.GetType("System.String"), "Parent(FRK_DONHANG_SANPHAM).TenSP");
            tblCTHD.Columns.Add(cTenSP);
            dgvTTHD.AutoGenerateColumns = false;
            dgvTTHD.DataSource = tblCTHD;
        }

        private void dgvTTHD_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in dgvTTHD.Rows)
                r.Cells[0].Value = r.Index + 1;
        }
        
        private void enableButton()
        {
            btnThem.Enabled = !capnhat;
            btnXoa.Enabled = !capnhat;
            btnSua.Enabled = !capnhat;
            btnInHD.Enabled = !capnhat;
            btnLuu.Enabled = capnhat;
            btnHuy.Enabled = capnhat;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            DSHD.AddNew();
            capnhat = true;
            enableButton();
        }
        
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                DSHD.EndCurrentEdit();
                daKH.Update(tblDONHANG);
                tblDONHANG.AcceptChanges();
                capnhat = false;
                enableButton();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DSHD.CancelCurrentEdit();
            tblDONHANG.RejectChanges();
            capnhat = false;
            enableButton();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DSHD.RemoveAt(DSHD.Position);
                daDH.Update(tblDONHANG);
                tblDONHANG.AcceptChanges();
            }
            catch (SqlException ex)
            {
                tblDONHANG.RejectChanges();
                MessageBox.Show("Xóa thất bại!");
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            capnhat = true;
            enableButton();
        }
    }
}

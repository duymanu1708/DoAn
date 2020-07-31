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
        DataTable tblSANPHAM, tblDONHANG, tblCTHD;
        SqlDataAdapter daSP, daDH, daCTHD;
        bool capnhat = false;
        BindingManagerBase DSHD;
        public frmDonHang()
        {
            InitializeComponent();
        }
        
        private void frmDonHang_Load(object sender, EventArgs e)
        {
            tblSANPHAM = new DataTable();
            daSP = new SqlDataAdapter("select * from SANPHAM", Modules.cnnStr);
            tblDONHANG = new DataTable();
            daDH = new SqlDataAdapter("select * from DONHANG", Modules.cnnStr);
            tblCTHD = new DataTable();
            daCTHD = new SqlDataAdapter("select * from CTHD", Modules.cnnStr);
            try
            {
                daDH.Fill(tblDONHANG);
                daCTHD.Fill(tblCTHD);
                daSP.Fill(tblSANPHAM);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            loadCTHD();
            loadCBOSP();
            var cmb = new SqlCommandBuilder(daCTHD);
            txtMaHD.DataBindings.Add("text", tblCTHD, "MaHD", true);
            txtDonGia.DataBindings.Add("text", tblCTHD, "DonGia", true);
            txtMaKH.DataBindings.Add("text", tblCTHD, "MaKH", true);
            txtThanhTien.DataBindings.Add("text", tblCTHD, "Tong", true);
            numSoLuong.DataBindings.Add("Value", tblCTHD, "SoLuong", true);
            dtNgayMua.DataBindings.Add("text", tblCTHD, "NgayLap", true);
            DSHD = this.BindingContext[tblCTHD];
            enableButton();

        }
        private void loadCTHD()
        {
            DataSet ds1 = new DataSet();
            ds1.Tables.AddRange(new DataTable[] { tblCTHD, tblDONHANG });
            DataRelation qh1 = new DataRelation("FRK_DONHANG_CTHD", tblDONHANG.Columns["MaHD"],tblCTHD.Columns["MaHD"]);
            ds1.Relations.Add(qh1);
            DataColumn cMaKH = new DataColumn("MaKH", Type.GetType("System.String"), "Parent(FRK_DONHANG_CTHD).MaKH");
            tblCTHD.Columns.Add(cMaKH);
            DataColumn cNgayLap = new DataColumn("NgayLap", Type.GetType("System.String"), "Parent(FRK_DONHANG_CTHD).NgayLap");
            tblCTHD.Columns.Add(cNgayLap);

            
            ds1.Tables.AddRange(new DataTable[] { tblCTHD, tblSANPHAM });
            DataRelation qh2 = new DataRelation("FRK_CTHD_SANPHAM", tblSANPHAM.Columns["MaSP"], tblCTHD.Columns["MaSP"]);
            ds1.Relations.Add(qh2);
            DataColumn cDonGia = new DataColumn("DonGia", Type.GetType("System.String"), "Parent(FRK_CTHD_SANPHAM).DonGia");
            tblCTHD.Columns.Add(cDonGia);

            dgvTTHD.AutoGenerateColumns = false;
            dgvTTHD.DataSource = tblCTHD;
        }
        private void loadCBOSP()
        {
            cboTenSP.DataSource = tblSANPHAM;
            cboTenSP.DisplayMember = "TenSP";
            cboTenSP.ValueMember = "MaSP";
        }
        private void dgvTTHD_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in dgvTTHD.Rows)
                r.Cells[0].Value = r.Index + 1;
        }
        private void btnInHD_Click(object sender, EventArgs e)
        {
            frmRP f = new frmRP();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }
        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            TabPage p = (TabPage)this.Parent;
            TabControl tabMain = (TabControl)p.Parent;
            tabMain.TabPages.Remove(p);
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow r = tblCTHD.Select("MaKH ='" + txtTimKiem.Text + "'")[0];
                DSHD.Position =tblCTHD.Rows.IndexOf(r);
            }
            catch
            {
                MessageBox.Show("Không Tìm Thấy");
            }
        }


        private void txtTimKiem_MouseDown(object sender, MouseEventArgs e)
        {
            txtTimKiem.Text = "";
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnTimKiem_Click(sender, e);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                DSHD.EndCurrentEdit();
                daCTHD.Update(tblCTHD);
                tblDONHANG.AcceptChanges();
                capnhat = false;
                enableButton();
            }
            catch
            {
                MessageBox.Show("Lưu Thất Bại!!");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DSHD.CancelCurrentEdit();
            tblCTHD.RejectChanges();
            capnhat = false;
            enableButton();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DSHD.RemoveAt(DSHD.Position);
                daCTHD.Update(tblCTHD);
                tblCTHD.AcceptChanges();
            }
            catch
            {
                tblCTHD.RejectChanges();
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

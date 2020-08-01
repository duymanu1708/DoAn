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
    public partial class frmSanPham : Form
    {
        DataTable tblSanPham,tblNSX,tblLoaiSP;
        SqlDataAdapter daSanPham,daNSX,daLoaiSP;
        BindingManagerBase bindSP;
        bool capnhat = false;
        public frmSanPham()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            TabPage p = (TabPage)this.Parent;
            TabControl tabMain = (TabControl)p.Parent;
            tabMain.TabPages.Remove(p);
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            tblSanPham = new DataTable();
            daSanPham = new SqlDataAdapter("Select * from SANPHAM", Modules.cnnStr);
            tblNSX = new DataTable();
            daNSX = new SqlDataAdapter("select * from NSX", Modules.cnnStr);
            tblLoaiSP = new DataTable();
            daLoaiSP = new SqlDataAdapter("select * from LoaiSP",Modules.cnnStr);
            try
            {
                daSanPham.Fill(tblSanPham);
                daNSX.Fill(tblNSX);
                daLoaiSP.Fill(tblLoaiSP);     
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            var cmb = new SqlCommandBuilder(daSanPham);
            addcol();
            loadCBONSX();
            loadCBOLoaiSP();
            loadDGVSP();
            txtTenSP.DataBindings.Add("text", tblSanPham, "TenSP", true);
            txtMaSP.DataBindings.Add("text", tblSanPham, "MaSP", true);
            txtDonGia.DataBindings.Add("text", tblSanPham, "DonGia", true);
            txtDonVi.DataBindings.Add("text", tblSanPham, "DonVi", true);
            numSoLuong.DataBindings.Add("Value", tblSanPham, "SoLuong", true);
            txtGiaGoc.DataBindings.Add("text", tblSanPham, "GiaGoc", true);
            cboNSX.DataBindings.Add("SelectedValue", tblSanPham, "MaNSX", true);
            cboLoaiSP.DataBindings.Add("SelectedValue", tblSanPham, "MaLoai", true);
            bindSP = this.BindingContext[tblSanPham];
            enableButton();
        }
        private void addcol()
        {
            DataSet ds = new DataSet();
            ds.Tables.AddRange(new DataTable[] { tblSanPham, tblNSX,tblLoaiSP });
            DataRelation qh = new DataRelation("FRK_NSX_SANPHAM", tblNSX.Columns["MaNSX"], tblSanPham.Columns["MaNSX"]);
            ds.Relations.Add(qh);
            DataColumn cTenNSX = new DataColumn("TenNSX", Type.GetType("System.String"), "Parent(FRK_NSX_SANPHAM).TenNSX");
            tblSanPham.Columns.Add(cTenNSX);
            DataRelation qh1 = new DataRelation("FRK_LoaiSP_SANPHAM", tblLoaiSP.Columns["MaLoai"], tblSanPham.Columns["MaLoai"]);
            ds.Relations.Add(qh1);
            DataColumn cTenLoai = new DataColumn("TenLoai", Type.GetType("System.String"), "Parent(FRK_LoaiSP_SANPHAM).TenLoai");
            tblSanPham.Columns.Add(cTenLoai);

        }
        private void loadDGVSP()
        {
            dgvSP.AutoGenerateColumns = false;
            dgvSP.DataSource = tblSanPham;
        }
        private void loadCBOLoaiSP()
        {
            cboLoaiSP.DataSource = tblLoaiSP;
            cboLoaiSP.DisplayMember = "TenLoai";
            cboLoaiSP.ValueMember = "MaLoai";
        }
        private void loadCBONSX()
        {
            cboNSX.DataSource = tblNSX;
            cboNSX.DisplayMember = "TenNSX";
            cboNSX.ValueMember = "MaNSX";
        }
        private void enableButton()
        {
            btnThem.Enabled = !capnhat;
            btnXoa.Enabled = !capnhat;
            btnSua.Enabled = !capnhat;
            btnLuu.Enabled = capnhat;
            btnHuy.Enabled = capnhat;
        }
       
 

        private void btnThem_Click(object sender, EventArgs e)
        {
            bindSP.AddNew();
            capnhat = true;
            enableButton();

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                bindSP.EndCurrentEdit();
                daSanPham.Update(tblSanPham);
                tblSanPham.AcceptChanges();
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
            bindSP.CancelCurrentEdit();
            tblSanPham.RejectChanges();
            capnhat = false;
            enableButton();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow r = tblSanPham.Select("MaSP='" + txtTimKiem.Text + "'")[0];
                bindSP.Position = tblSanPham.Rows.IndexOf(r);
            }
            catch
            {
                MessageBox.Show("Không tìm thấy");
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

        private void cboNSX_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cboNSX.SelectedIndex;
            if(index>=0)
            {
                txtDiaChiNSX.Text = tblNSX.Rows[index]["DiaChiNSX"].ToString();
            }else
            {
                txtDiaChiNSX.Text = "";
            }
        }


        private void dgvSP_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in dgvSP.Rows)
                r.Cells[0].Value = r.Index + 1;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                bindSP.RemoveAt(bindSP.Position);
                daSanPham.Update(tblSanPham);
                tblSanPham.AcceptChanges();

            }
            catch
            {
                tblSanPham.RejectChanges();
                MessageBox.Show("Xoa that bai!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            capnhat = true;
            enableButton();
        }
    }
}

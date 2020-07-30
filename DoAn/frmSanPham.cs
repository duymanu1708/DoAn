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
        DataTable tblSanPham,tblNSX;
        SqlDataAdapter daSanPham,daNSX;
        BindingManagerBase DSSP;
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
            try
            {
                daSanPham.Fill(tblSanPham);
                daNSX.Fill(tblNSX);     
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            var cmb = new SqlCommandBuilder(daSanPham);
            loadNSX();
            txtTenSP.DataBindings.Add("text", tblSanPham, "TenSP", true);
            txtTenNSX.DataBindings.Add("text", tblSanPham, "TenNSX", true);
            txtMaSP.DataBindings.Add("text", tblSanPham, "MaSP", true);
            txtDonGia.DataBindings.Add("text", tblSanPham, "DonGia", true);
            txtDonVi.DataBindings.Add("text", tblSanPham, "DonVi", true);
            numSoLuong.DataBindings.Add("Value", tblSanPham, "SoLuong", true);
            DSSP = this.BindingContext[tblSanPham];
            enableButton();
        }
        private void loadNSX()
        {
            DataSet ds = new DataSet();
            ds.Tables.AddRange(new DataTable[] { tblSanPham,tblNSX  });
            DataRelation qh = new DataRelation("FRK_NSX_SANPHAM", tblNSX.Columns["MaNSX"], tblSanPham.Columns["MaNSX"]);
            ds.Relations.Add(qh);
            DataColumn cTenNSX = new DataColumn("TenNSX", Type.GetType("System.String"), "Parent(FRK_NSX_SANPHAM).TenNSX");
            tblSanPham.Columns.Add(cTenNSX);
            dgvSP.AutoGenerateColumns = false;
            dgvSP.DataSource = tblSanPham;
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
            DSSP.AddNew();
            capnhat = true;
            enableButton();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                DSSP.EndCurrentEdit();
                daSanPham.Update(tblSanPham);
                tblSanPham.AcceptChanges();
                capnhat = false;
                enableButton();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DSSP.CancelCurrentEdit();
            tblSanPham.RejectChanges();
            capnhat = false;
            enableButton();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DSSP.RemoveAt(DSSP.Position);
                daSanPham.Update(tblSanPham);
                tblSanPham.AcceptChanges();

            }
            catch (SqlException ex)
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

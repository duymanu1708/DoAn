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
    public partial class frmKhachHang : Form
    {
        DataTable tblKhachHang;
        SqlDataAdapter daKhachHang;
        BindingManagerBase DSKH;
        bool capnhat = false;
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            TabPage p = (TabPage)this.Parent;
            TabControl tabMain = (TabControl)p.Parent;
            tabMain.TabPages.Remove(p);
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            tblKhachHang = new DataTable();
            daKhachHang = new SqlDataAdapter("Select * from KHACHHANG", Modules.cnnStr);
            try
            {
                daKhachHang.Fill(tblKhachHang);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            var cmb = new SqlCommandBuilder(daKhachHang);
            loaddgv();
            txtMaKH.DataBindings.Add("text", tblKhachHang, "MaKH", true);
            txtHoTen.DataBindings.Add("text", tblKhachHang, "TenKH", true);
            txtDiaChi.DataBindings.Add("text", tblKhachHang, "DiaChi", true);
            txtSDT.DataBindings.Add("text", tblKhachHang, "SoDT", true);
            radname.DataBindings.Add("checked", tblKhachHang, "GioiTinh", true);
            DSKH = this.BindingContext[tblKhachHang];
            enableButton();
        }
        private void enableButton()
        {
            btnThem.Enabled = !capnhat;
            btnXoa.Enabled = !capnhat;
            btnSua.Enabled = !capnhat;
            btnLuu.Enabled = capnhat;
            btnHuy.Enabled = capnhat;
        }
        private void loaddgv()
        {
            dgvKH.AutoGenerateColumns = false;
            dgvKH.DataSource = tblKhachHang;
        }

        private void radname_CheckedChanged(object sender, EventArgs e)
        {
            radNu.Checked = !radname.Checked;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DSKH.AddNew();
            capnhat = true;
            enableButton();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                DSKH.EndCurrentEdit();
                daKhachHang.Update(tblKhachHang);
                tblKhachHang.AcceptChanges();
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
            DSKH.CancelCurrentEdit();
            tblKhachHang.RejectChanges();
            capnhat = false;
            enableButton();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DSKH.RemoveAt(DSKH.Position);
                daKhachHang.Update(tblKhachHang);
                tblKhachHang.AcceptChanges();
            }
            catch(SqlException ex)
            {
                tblKhachHang.RejectChanges();
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

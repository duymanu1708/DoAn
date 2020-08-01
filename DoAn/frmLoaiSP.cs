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
    public partial class frmLoaiSP : Form
    {
        DataTable tblLoaiSP;
        SqlDataAdapter daLoaiSP;
        BindingManagerBase DSLSP;
        bool capnhat = false;
        public frmLoaiSP()
        {
            InitializeComponent();
        }

        private void frmLoaiSP_Load(object sender, EventArgs e)
        {
            tblLoaiSP = new DataTable();
            daLoaiSP = new SqlDataAdapter("Select * from LOAISP", Modules.cnnStr);
            try
            {
                daLoaiSP.Fill(tblLoaiSP);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            var cmb = new SqlCommandBuilder(daLoaiSP);
            loaddgvLSP();
            txtMaLoai.DataBindings.Add("text", tblLoaiSP, "MaLoai", true);
            txtTenLoai.DataBindings.Add("text", tblLoaiSP, "TenLoai", true);
            DSLSP = this.BindingContext[tblLoaiSP];
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
        private void loaddgvLSP()
        {
            dgvLoaiSP.AutoGenerateColumns = false;
            dgvLoaiSP.DataSource = tblLoaiSP;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DSLSP.AddNew();
            capnhat = true;
            enableButton();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                DSLSP.EndCurrentEdit();
                daLoaiSP.Update(tblLoaiSP);
                tblLoaiSP.AcceptChanges();
                capnhat = false;
                enableButton();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            capnhat = true;
            enableButton();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DSLSP.CancelCurrentEdit();
            tblLoaiSP.RejectChanges();
            capnhat = false;
            enableButton();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DSLSP.RemoveAt(DSLSP.Position);
                daLoaiSP.Update(tblLoaiSP);
                tblLoaiSP.AcceptChanges();
            }
            catch
            {
                tblLoaiSP.RejectChanges();
                MessageBox.Show("Xóa thất bại!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            TabPage p = (TabPage)this.Parent;
            TabControl tabMain = (TabControl)p.Parent;
            tabMain.TabPages.Remove(p);
        }

        private void dgvLoaiSP_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in dgvLoaiSP.Rows)
            {
                r.Cells[0].Value = r.Index + 1;
            }
        }
    }
}

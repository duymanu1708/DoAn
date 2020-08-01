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
    public partial class frmNSX : Form
    {
        DataTable tblNSX;
        SqlDataAdapter daNSX;
        BindingManagerBase DSNSX;
        bool capnhat = false;
        public frmNSX()
        {
            InitializeComponent();
        }

        private void frmNSX_Load(object sender, EventArgs e)
        {
            tblNSX = new DataTable();
            daNSX = new SqlDataAdapter("Select * from NSX", Modules.cnnStr);
            try
            {
                daNSX.Fill(tblNSX);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            var cmb = new SqlCommandBuilder(daNSX);
            loaddgvNSX();
            txtMaNSX.DataBindings.Add("text", tblNSX, "MaNSX", true);
            txtTenNSX.DataBindings.Add("text", tblNSX, "TenNSX", true);
            txtDCNSX.DataBindings.Add("text", tblNSX, "DiaChiNSX", true);
            DSNSX = this.BindingContext[tblNSX];
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
        private void loaddgvNSX()
        {
            dgvNSX.AutoGenerateColumns = false;
            dgvNSX.DataSource = tblNSX;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DSNSX.AddNew();
            try
            {
                SqlCommand cmm = new SqlCommand("select dbo.fn_CreateMaNSX()", Modules.cnn);
                Modules.cnn.Open();
                txtMaNSX.Text = cmm.ExecuteScalar().ToString();
                capnhat = true;
                enableButton();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Modules.cnn.Close();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            capnhat = true;
            enableButton();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DSNSX.RemoveAt(DSNSX.Position);
                daNSX.Update(tblNSX);
                tblNSX.AcceptChanges();
            }
            catch
            {
                tblNSX.RejectChanges();
                MessageBox.Show("Xóa thất bại!");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
            try
            {
                DSNSX.EndCurrentEdit();
                daNSX.Update(tblNSX);
                tblNSX.AcceptChanges();
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
            DSNSX.CancelCurrentEdit();
            tblNSX.RejectChanges();
            capnhat = false;
            enableButton();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            TabPage p = (TabPage)this.Parent;
            TabControl tabMain = (TabControl)p.Parent;
            tabMain.TabPages.Remove(p);
        }

        private void dgvNSX_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in dgvNSX.Rows)
            {
                r.Cells[0].Value = r.Index + 1;
            }
        }
    }
}

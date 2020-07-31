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
        DataTable tblKHACHHANG, tblCTHD, tblDONHANG, tblSANPHAM;
        SqlDataAdapter daKHACHHANG, daCTHD, daDONHANG, daSANPHAM;
        bool capNhat;

        private void loadDSDH()
        {
            txtMaHD.DataBindings.Add("text", tblDONHANG, "MaHD", true);
            dtNgayLap.DataBindings.Add("text", tblDONHANG, "NgayLap", true);
            cboSDT.DataBindings.Add("selectedValue", tblDONHANG, "MaKH",true);
            bindDH = this.BindingContext[tblDONHANG];
            bindDH.PositionChanged += new EventHandler(bdDH_PositionChanged);
        }
        private void ennableButton()
        {
            btnThem.Enabled = !capNhat;
            btnXoa.Enabled = !capNhat;
            btnHuy.Enabled = capNhat;
            btnLuu.Enabled = capNhat;
            btnThemSP.Enabled = capNhat;
            btnXoaSP.Enabled = capNhat;
            btnSua.Enabled = !capNhat;
            btnInHD.Enabled = !capNhat;
            dgvTTHD.Enabled = capNhat;
        }
        private void bdDH_PositionChanged(object sender, EventArgs e)
        {
            tblCTHD.DefaultView.RowFilter = "MaHD='" + txtMaHD.Text + "'";


        }
        private void frmDonHang_Load(object sender, EventArgs e)
        {
            tblKHACHHANG = new DataTable();
            tblDONHANG = new DataTable();
            tblCTHD = new DataTable();
            tblSANPHAM = new DataTable();
            daCTHD = new SqlDataAdapter("select * from CTHD", Modules.cnnStr);
            daDONHANG = new SqlDataAdapter("select * from  DONHANG", Modules.cnnStr);
            daKHACHHANG = new SqlDataAdapter("select * from KHACHHANG", Modules.cnnStr);
            daSANPHAM = new SqlDataAdapter("select * from SANPHAM", Modules.cnnStr);
            try
            {
                daCTHD.Fill(tblCTHD);
                daDONHANG.Fill(tblDONHANG);
                daKHACHHANG.Fill(tblKHACHHANG);
                daSANPHAM.Fill(tblSANPHAM);
                SqlCommandBuilder cmdDH = new SqlCommandBuilder(daDONHANG);
                SqlCommandBuilder cmdCTHD = new SqlCommandBuilder(daCTHD);

            }catch(SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            loadCTHD();
            loadSanPham();
            loadDSDT();
            loadDSDH();
            addColCTHD();
            bdDH_PositionChanged(sender, e);
            capNhat = false;
            ennableButton();
        }

        private void dgvTTHD_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach(DataGridViewRow r in dgvTTHD.Rows)
            {
                r.Cells[0].Value = r.Index + 1;
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            bindDH.Position = 0;
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            if (bindDH.Position > 0)
                bindDH.Position -= 1;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (bindDH.Position < bindDH.Count - 1)
                bindDH.Position += 1;
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            bindDH.Position = bindDH.Count - 1;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            TabPage p = (TabPage)this.Parent;
            TabControl tabMain = (TabControl)p.Parent;
            tabMain.TabPages.Remove(p);
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if(cboTenSP.SelectedIndex==-1)
            {
                MessageBox.Show("Chưa chọn sản phẩm!!");
                return;
            }
            int count = tblCTHD.Select("MaHD='" + txtMaHD.Text + "' and MaSP='" + cboTenSP.SelectedValue + "'").Count();
            if(count>0)
            {
                MessageBox.Show("Sản phẩm đã tồn tại chọn sản phẩm khác!!");
                return;
            }
            DataRow r = tblCTHD.NewRow();
            r["MaSP"] = cboTenSP.SelectedValue;
            r["MaHD"] = txtMaHD.Text;
            r["SoLuong"] = numSoLuong.Value;
            tblCTHD.Rows.Add(r);
            bdDH_PositionChanged(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                var rows = tblDONHANG.Select("MaHD ='" + txtMaHD + "'");
                foreach (DataRow r in rows)
                    r.Delete();
                daCTHD.Update(tblCTHD);
                tblCTHD.AcceptChanges();
                bindDH.RemoveAt(bindDH.Position);
                daDONHANG.Update(tblDONHANG);
                tblDONHANG.AcceptChanges();
                MessageBox.Show("Xóa thành công!!");
            }catch(SqlException ex)
            {
                tblCTHD.RejectChanges();
                tblDONHANG.RejectChanges();
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            bindCTHD.CancelCurrentEdit();
            tblCTHD.RejectChanges();
            bindDH.CancelCurrentEdit();
            tblDONHANG.RejectChanges();
            bdDH_PositionChanged(sender, e);
            capNhat = false;
            ennableButton();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            bindDH.AddNew();
            dtNgayLap.Value = DateTime.Now;
            try
            {
                SqlCommand cmm = new SqlCommand("select dbo.fn_CreateMaHD()",Modules.cnn);
                Modules.cnn.Open();
                txtMaHD.Text = cmm.ExecuteScalar().ToString();
                capNhat = true;
                ennableButton();
            }catch(SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Modules.cnn.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(cboSDT.SelectedIndex==-1)
            {
                MessageBox.Show("Chưa chọn khách hàng!!");
                return;
            }
            try
            {
                bindDH.EndCurrentEdit();
                daDONHANG.Update(tblDONHANG);
                tblDONHANG.AcceptChanges();

                bindCTHD.EndCurrentEdit();
                daCTHD.Update(tblCTHD);
                tblCTHD.AcceptChanges();
                MessageBox.Show("Cập nhật thành công!!");
                capNhat = false;
                ennableButton();
            }catch(SqlException ex)
            {
                tblCTHD.RejectChanges();
                tblDONHANG.RejectChanges();
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            int index = bindCTHD.Position;
            if (index >= 0)
                bindCTHD.RemoveAt(index);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            capNhat = true;
            ennableButton();
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            frmRP f = new frmRP();
            f.MaHD = txtMaHD.Text;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        BindingManagerBase bindDH, bindCTHD;
        private void cboSDT_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cboSDT.SelectedIndex;
            if(index>=0)
            {
                
                txtHoTen.Text = tblKHACHHANG.Rows[index]["TenKH"].ToString();
                txtDiaChi.Text=tblKHACHHANG.Rows[index]["DiaChi"].ToString();
                if(tblKHACHHANG.Rows[index]["GioiTinh"].ToString()=="True")
                {
                    radNam.Checked = true;
                }
                else
                {
                    radNam.Checked = false;
                }
                
            }
            else
            {
                txtHoTen.Text = "";
                txtDiaChi.Text = "";
                radNam.Checked = false;
            }
        }
        private void loadSanPham()
        {
            cboTenSP.DataSource = tblSANPHAM;
            cboTenSP.ValueMember = "MaSP";
            cboTenSP.DisplayMember = "TenSP";
            cboTenSP.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboTenSP.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboTenSP.SelectedIndex = -1;
        }
        private void loadDSDT()
        {
            cboSDT.DataSource = tblKHACHHANG;
            cboSDT.DisplayMember = "SoDT";
            cboSDT.ValueMember = "MaKH";
            cboSDT.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboSDT.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void addColCTHD()
        {
            DataSet ds = new DataSet();
            ds.Tables.AddRange(new DataTable[] { tblCTHD, tblSANPHAM });
            DataRelation qh = new DataRelation("FRK_CTHD_SANPHAM", tblSANPHAM.Columns["MaSP"], tblCTHD.Columns["MaSP"]);
            ds.Relations.Add(qh);
            DataColumn cTenSP = new DataColumn("TenSP",Type.GetType("System.String"), "Parent(FRK_CTHD_SANPHAM).TenSP");
            DataColumn cDonGia = new DataColumn("DonGia", Type.GetType("System.String"), "Parent(FRK_CTHD_SANPHAM).DonGia");
            DataColumn cThanhTien = new DataColumn("ThanhTien", Type.GetType("System.String"), "Parent(FRK_CTHD_SANPHAM).DonGia*SoLuong");
            tblCTHD.Columns.Add(cTenSP);
            tblCTHD.Columns.Add(cDonGia);
            tblCTHD.Columns.Add(cThanhTien);
        }
        private void loadCTHD()
        {
            bindCTHD = this.BindingContext[tblCTHD];
            dgvTTHD.AutoGenerateColumns = false;
            dgvTTHD.DataSource = tblCTHD;
        }
    }
}

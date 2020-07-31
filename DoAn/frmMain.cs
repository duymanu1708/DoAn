using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmKhachHang f = new frmKhachHang();
            TabPage p = new TabPage(f.Text);
            p.Name = "tabKhachHang";
            f.TopLevel = false;
            p.Controls.Add(f);
            f.Dock = DockStyle.Fill;
            f.FormBorderStyle = FormBorderStyle.None;
            tabControl1.TabPages.Add(p);
            f.Show();
        }

        private void btnKhoSanPham_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSanPham f = new frmSanPham();
            TabPage p = new TabPage(f.Text);
            p.Name = "tabSanPham";
            f.TopLevel = false;
            p.Controls.Add(f);
            f.Dock = DockStyle.Fill;
            f.FormBorderStyle = FormBorderStyle.None;
            tabControl1.TabPages.Add(p);
            f.Show();
        }

        private void btnDonHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDonHang f = new frmDonHang();
            TabPage p = new TabPage(f.Text);
            p.Name = "tabDonHang";
            f.TopLevel = false;
            p.Controls.Add(f);
            f.Dock = DockStyle.Fill;
            f.FormBorderStyle = FormBorderStyle.None;
            tabControl1.TabPages.Add(p);
            f.Show();
        }

        private void btnThongKeDoanhThu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmThongKeDoanhThu f = new frmThongKeDoanhThu();
            TabPage p = new TabPage(f.Text);
            p.Name = "tabThongKeDoanhThu";
            f.TopLevel = false;
            p.Controls.Add(f);
            f.Dock = DockStyle.Fill;
            f.FormBorderStyle = FormBorderStyle.None;
            tabControl1.TabPages.Add(p);
            f.Show();
        }

        private void btnTongChi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}

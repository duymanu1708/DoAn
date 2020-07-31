namespace DoAn
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnKhachHang = new DevExpress.XtraBars.BarButtonItem();
            this.btnKhoSanPham = new DevExpress.XtraBars.BarButtonItem();
            this.btnDonHang = new DevExpress.XtraBars.BarButtonItem();
            this.btnThongKeDoanhThu = new DevExpress.XtraBars.BarButtonItem();
            this.btnTongChi = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnKhachHang,
            this.btnKhoSanPham,
            this.btnDonHang,
            this.btnThongKeDoanhThu,
            this.btnTongChi});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 6;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(748, 141);
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.Caption = "Khách Hàng";
            this.btnKhachHang.Id = 1;
            this.btnKhachHang.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKhachHang.ImageOptions.Image")));
            this.btnKhachHang.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnKhachHang.ImageOptions.LargeImage")));
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // btnKhoSanPham
            // 
            this.btnKhoSanPham.Caption = "Kho Sản Phẩm";
            this.btnKhoSanPham.Id = 2;
            this.btnKhoSanPham.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKhoSanPham.ImageOptions.Image")));
            this.btnKhoSanPham.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnKhoSanPham.ImageOptions.LargeImage")));
            this.btnKhoSanPham.Name = "btnKhoSanPham";
            this.btnKhoSanPham.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnKhoSanPham_ItemClick);
            // 
            // btnDonHang
            // 
            this.btnDonHang.Caption = "Đơn Hàng";
            this.btnDonHang.Id = 3;
            this.btnDonHang.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDonHang.ImageOptions.Image")));
            this.btnDonHang.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDonHang.ImageOptions.LargeImage")));
            this.btnDonHang.Name = "btnDonHang";
            this.btnDonHang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDonHang_ItemClick);
            // 
            // btnThongKeDoanhThu
            // 
            this.btnThongKeDoanhThu.Caption = "Tổng Thu Nhập";
            this.btnThongKeDoanhThu.Id = 4;
            this.btnThongKeDoanhThu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThongKeDoanhThu.ImageOptions.Image")));
            this.btnThongKeDoanhThu.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnThongKeDoanhThu.ImageOptions.LargeImage")));
            this.btnThongKeDoanhThu.Name = "btnThongKeDoanhThu";
            this.btnThongKeDoanhThu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThongKeDoanhThu_ItemClick);
            // 
            // btnTongChi
            // 
            this.btnTongChi.Caption = "Tổng Chi";
            this.btnTongChi.Id = 5;
            this.btnTongChi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTongChi.ImageOptions.Image")));
            this.btnTongChi.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnTongChi.ImageOptions.LargeImage")));
            this.btnTongChi.Name = "btnTongChi";
            this.btnTongChi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTongChi_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Quản Lý Hiệu Sách";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnKhachHang);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnKhoSanPham);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnDonHang);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "ribbonPageGroup3";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnThongKeDoanhThu);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "ribbonPageGroup4";
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 141);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(748, 277);
            this.tabControl1.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 418);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "frmMain";
            this.Text = "frmMain";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnKhachHang;
        private DevExpress.XtraBars.BarButtonItem btnKhoSanPham;
        private DevExpress.XtraBars.BarButtonItem btnDonHang;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private System.Windows.Forms.TabControl tabControl1;
        private DevExpress.XtraBars.BarButtonItem btnThongKeDoanhThu;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem btnTongChi;
    }
}
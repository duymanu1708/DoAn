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

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            TabPage p = (TabPage)this.Parent;
            TabControl tabMain = (TabControl)p.Parent;
            tabMain.TabPages.Remove(p);
        }

        SqlDataAdapter daKH, daDH, daCTHD;
        bool capNhat;
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

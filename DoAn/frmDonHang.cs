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


        SqlDataAdapter daKH, daDH, daCTHD;
        bool capNhat;
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

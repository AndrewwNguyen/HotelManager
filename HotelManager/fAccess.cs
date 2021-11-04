
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fAccess : Form
    {
        private int idStaffType = -1;
        public fAccess()
        {
            InitializeComponent();
            cbbStaffType.DisplayMember = "Name";
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
          
        }
        private void BtnBack_Click(object sender, EventArgs e)
        {
        }
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {

        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
        }
        private void btnInsertStaffType_Click(object sender, EventArgs e)
        {

        }
        private void cbbStaffType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbbStaffType.SelectedIndex;
            idStaffType = (int)((DataTable)cbbStaffType.DataSource).Rows[index]["id"];
        }
    }
}


using HotelManager.Class;
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
    public partial class fAddStaffType : Form
    {
        string index;
        public fAddStaffType(string _index)
        {
            index = _index;
            InitializeComponent();
            btn.ButtonText = "Thêm mới";
            title.Text = "Thêm Loại Nhân Viên";
            txbName.Text = index;

        }
        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btn_Click(object sender, EventArgs e)
        {
            if(txbName.Text !=string.Empty)
            {
                Functions.Chaysql("UPDATE StaffType SET Name = N'"+txbName.Text+"' where Name = '"+index+"'");
                MessageBox.Show("Cập nhập loại nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
                btnClose_Click(sender, e);
            else if (e.KeyChar == 13)
                btn_Click(sender, e);
        }
    }
}

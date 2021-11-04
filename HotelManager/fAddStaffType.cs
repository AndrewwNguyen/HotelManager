
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
        private int idStaffType = -1;
        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btn_Click(object sender, EventArgs e)
        {
         
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

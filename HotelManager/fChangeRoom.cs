
using HotelManager.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fChangeRoom : Form
    {
        string user;
        public fChangeRoom(string username)
        {
            user = username;
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClose__Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {

        }

        private void fChangeRoom_Load(object sender, EventArgs e)
        {
            string c = "select StaffType.Name from StaffType join Staff on StaffType.ID = Staff.IDStaffType where Staff.UserName ='" + user + "'";
            ccc.Text = Functions.Laygiatri(c);
        }
    }
}

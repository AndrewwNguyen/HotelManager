
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
        int idRoom,idReceiveRoom;
        public fChangeRoom(int _idRoom,int _idReceiveRoom)
        {
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
    }
}

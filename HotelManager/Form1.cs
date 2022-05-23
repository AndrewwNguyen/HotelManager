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
    public partial class Form1 : Form
    {
        string user;
        public Form1(string username)
        {
            user = username;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void btnClose__Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string str = "SELECT Nationality FROM Customer WHERE IDCard = N'Việt Nam'";
            txbStaffType.Text = Functions.Laygiatri(str);
        }
    }
}

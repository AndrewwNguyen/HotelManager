using HotelManager.DAO;
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
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }
        public bool Login()
        {
            return AccountDAO.Instance.Login(txbUserName.Text, txbPassWord.Text);
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Login())
            {
                this.Hide();
                fManagement f = new fManagement(txbUserName.Text);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Tên Đăng Nhập không tồn tại hoặc Mật Khẩu không đúng.\nVui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit__Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void txbPassWord_Click(object sender, EventArgs e)
        {
            txbPassWord.Clear();
            txbPassWord.PasswordChar = '*';
            panel2.BackColor = Color.FromArgb(128, 64, 64);
            txbPassWord.ForeColor = Color.FromArgb(128, 64, 64);

            panel1.BackColor = Color.WhiteSmoke; ;
            txbUserName.ForeColor = Color.WhiteSmoke;
        }

        private void txbUserName_Click(object sender, EventArgs e)
        {
            txbUserName.Clear();
            panel1.BackColor = Color.FromArgb(128, 64, 64);
            txbUserName.ForeColor = Color.FromArgb(128, 64, 64);
            panel2.BackColor = Color.WhiteSmoke; ;
            txbPassWord.ForeColor = Color.WhiteSmoke;

            panel2.BackColor = Color.WhiteSmoke; ;
            txbPassWord.ForeColor = Color.WhiteSmoke;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void fLogin_Load(object sender, EventArgs e)
        {

        }
    }
}

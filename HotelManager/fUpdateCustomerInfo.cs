
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
    public partial class fUpdateCustomerInfo : Form
    {
        string idCard;
        List<Sex> Listitem;
        List<Nationality> Listitem1;
        Class.Functions dtBase = new Class.Functions();
        public fUpdateCustomerInfo(string _idCard)
        {
            idCard = _idCard;
            InitializeComponent();
            Listitem = new List<Sex>()
            {
               new Sex(){name = "Nam"},
               new Sex(){name = "Nữ"},
               new Sex(){name = "Khác" }
             };
            cbSex.DataSource = Listitem;
            cbSex.DisplayMember = "name";
            Listitem1 = new List<Nationality>()
            {
               new Nationality(){name = "Việt Nam"},
               new Nationality(){name = "Trung Quốc"},
               new Nationality(){name = "Thái Lan" },
               new Nationality(){name = "Nhật Bản" },
               new Nationality(){name = "Lào" },
               new Nationality(){name = "Hàn Quốc" },
               new Nationality(){name = "Singapore" },
               new Nationality(){name = "Hoa Kỳ" },
               new Nationality(){name = "Anh" },
               new Nationality(){name = "Pháp" },
               new Nationality(){name = "Đức" },
               new Nationality(){name = "Ytaly" },
               new Nationality(){name = "Tây Ban Nha" },
               new Nationality(){name = "Canada" }
             };
            cbNationality.DataSource = Listitem1;
            cbNationality.DisplayMember = "name";
        }
        public class Sex
        {
            public string name { get; set; }
        }
        public class Nationality
        {
            public string name { get; set; }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClose__Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }
        private bool CheckDate()
        {
            if (DateTime.Now.Subtract(dpkDateOfBirth.Value).Days <= 0)
                return false;
            else return true;
        }

        private void txbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (txbFullName.Text != string.Empty && txbIDCard.Text != string.Empty && txbAddress.Text != string.Empty && cbNationality.Text != string.Empty && txbPhoneNumber.Text != string.Empty)
            {
                if (CheckDate())
                {
                    string sql;
                    sql = "UPDATE Customer SET Name = N'" + txbFullName.Text + "',IDCard = '" + txbIDCard.Text + "',IDCustomerType = '" + cbCustomerType.SelectedValue.ToString() + "',PhoneNumber = '" + txbPhoneNumber.Text + "',DateOfBirth = '" + dpkDateOfBirth.Value + "',Address = N'" + txbAddress.Text + "',Sex = N'" + cbSex.Text + "',Nationality = N'" + cbNationality.Text + "' where IDCard = '" + idCard + "'";
                    Functions.Chaysql(sql);
                    MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Ngày sinh phải nhỏ hơn ngày hiện tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void fUpdateCustomerInfo_Load(object sender, EventArgs e)
        {
            cbCustomerType.DataSource = dtBase.DataReader("SELECT Name,ID FROM  CustomerType");
            cbCustomerType.DisplayMember = "Name";
            cbCustomerType.ValueMember = "ID";
            LoadInfoIdcard();
        }
        public void LoadInfoIdcard()
        {
            string str;
            str = "SELECT DateOfBirth FROM Customer WHERE IDCard = N'" +idCard+ "'";
            dpkDateOfBirth.Value = DateTime.Parse(Functions.laygiatri(str));
            str = "SELECT Name FROM Customer WHERE IDCard = N'" + idCard + "'";
            txbFullName.Text = Functions.laygiatri(str);
            str = "SELECT CustomerType.Name FROM Customer join CustomerType on Customer.IDCustomerType = CustomerType.ID WHERE IDCard = N'" + idCard + "'";
            cbCustomerType.Text = Functions.laygiatri(str);
            str = "SELECT PhoneNumber FROM Customer WHERE IDCard = N'" + idCard + "'";
            txbPhoneNumber.Text = Functions.laygiatri(str);
            str = "SELECT IDCard FROM Customer WHERE IDCard = N'" + idCard + "'";
            txbIDCard.Text = Functions.laygiatri(str);
            str = "SELECT Address FROM Customer WHERE IDCard = N'" + idCard + "'";
            txbAddress.Text = Functions.laygiatri(str);
            str = "SELECT Sex FROM Customer WHERE IDCard = N'" + idCard + "'";
            cbSex.Text = Functions.laygiatri(str);
            str = "SELECT Nationality FROM Customer WHERE IDCard = N'" + idCard + "'";
            cbNationality.Text = Functions.laygiatri(str);
        }
    }
}

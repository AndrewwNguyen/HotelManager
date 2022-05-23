
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
    public partial class fAddCustomer : Form
    {
        List<Sex> Listitem;
        List<Nationality> Listitem1;
        Class.Functions dtBase = new Class.Functions();
        public fAddCustomer()
        {
            InitializeComponent();
            Listitem = new List<Sex>()
            {
               new Sex(){name = "Nam"},
               new Sex(){name = "Nữ"},
               new Sex(){name = "Khác" }
             };
            comboBoxSex.DataSource = Listitem;
            comboBoxSex.DisplayMember = "name";
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
            txbNationality.DataSource = Listitem1;
            txbNationality.DisplayMember = "name";
        }
        public class Sex
        {
            public string name { get; set; }
        }
        public class Nationality
        {
            public string name { get; set; }
        }
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if(txbFullName.Text !=string.Empty && txbAddress.Text !=string.Empty &&txbIDCard.Text !=string.Empty && txbPhoneNumber.Text != string.Empty)
            {
                if(!Functions.ktra("select IDcard from Customer where IDCard = '"+txbIDCard.Text+"'"))
                {
                    Functions.Chaysql("Insert Customer ([ID], [IDCard], [IDCustomerType], [Name], [DateOfBirth], [Address], [PhoneNumber], [Sex], [Nationality]) VALUES('"+Functions.key()+"','"+txbIDCard.Text+"','"+comboBoxCustomerType.SelectedValue.ToString()+"',N'"+txbFullName.Text+"','"+datepickerDateOfBirth.Value+"',N'"+txbAddress.Text+"','"+txbPhoneNumber.Text+"',N'"+comboBoxSex.Text+"',N'"+txbNationality.Text+"')");
                    MessageBox.Show("Thêm Khách hàng thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                else
                {
                    MessageBox.Show("Căn cước công dân đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose__Click(object sender, EventArgs e)
        {
            Close();
        }
        private void TxbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void fAddCustomer_Load(object sender, EventArgs e)
        {
            comboBoxCustomerType.DataSource = dtBase.DataReader("SELECT Name,ID FROM CustomerType");
            comboBoxCustomerType.DisplayMember = "Name";
            comboBoxCustomerType.ValueMember = "ID";
            comboBoxCustomerType.SelectedIndex = 0;
        }
    }
}

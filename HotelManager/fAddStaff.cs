
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
    public partial class fAddStaff : Form
    {
        Class.Functions dtBase = new Class.Functions();
        public fAddStaff()
        {
            InitializeComponent();
        }
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thêm nhân viên mới không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                if(txbName.Text !=string.Empty && txbFullName.Text != string.Empty && txbIDcard.Text != string.Empty && txbAddress.Text != string.Empty && txbPhoneNumber.Text != string.Empty)
                {
                    if (!Functions.ktra("Select * From Staff where UserName = '" + txbName.Text + "'"))
                    {
                        if (!Functions.ktra("Select * From Staff where IDCard = '" + txbIDcard.Text + "'"))
                        {
                            if (CheckDate())
                            {
                                Functions.Chaysql("INSERT INTO Staff (UserName, DisplayName, PassWord, IDStaffType, IDCard,DateOfBirth,Sex, PhoneNumber,StartDay,Address) VALUES('" + txbName.Text + "',N'" + txbFullName.Text + "','" + Functions.HashPass("123456") + "','" + comboBoxStaffType.SelectedValue.ToString() + "','" + txbIDcard.Text + "','" + datepickerDateOfBirth.Value + "',N'" + comboBoxSex.Text + "','" + txbPhoneNumber.Text + "','" + datePickerStartDay.Value + "',N'" + txbAddress.Text + "')");
                                MessageBox.Show("Thêm Nhân Viên '"+txbFullName.Text+"' Thành Công Mật Khẩu Mặc Định : 123456 ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Căn cước/CMND đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tên tài khoản đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Không được để trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

        }
        private void TxbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private void TxbUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '.' || e.KeyChar == '-' ||
                e.KeyChar == '_' || e.KeyChar == '@'))
                e.Handled = true;
            // ^ ([a - zA - Z0 - 9\.\-_ ?@] +)$

        }
        private bool CheckDate()
        {
            if (!CheckTrueDate(datepickerDateOfBirth.Value, DateTime.Now))
            {
                MessageBox.Show("Ngày sinh không hợp lệ (Tuổi phải lớn hơn 18)", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                if (!CheckTrueDate(datepickerDateOfBirth.Value, datePickerStartDay.Value))
            {
                MessageBox.Show("Ngày vào làm không hợp lệ (Lớn hơn 18 tuổi)", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool CheckTrueDate(DateTime date1, DateTime date2)
        {
            if (date2.Subtract(date1).Days < 6574)
                return false;
            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fAddStaff_Load(object sender, EventArgs e)
        {
            comboBoxStaffType.DataSource = dtBase.DataReader("SELECT Name,ID FROM StaffType");
            comboBoxStaffType.DisplayMember = "Name";
            comboBoxStaffType.ValueMember = "ID";
            comboBoxStaffType.SelectedIndex = 0;
            datePickerStartDay.Value = DateTime.Now;
            comboBoxSex.SelectedIndex = 0;
        }
    }

}

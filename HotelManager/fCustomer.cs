
using HotelManager.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace HotelManager
{
    public partial class fCustomer : Form
    {
        List<Sex> Listitem;
        List<Nationality> Listitem1;
        Class.Functions dtBase = new Class.Functions();
        internal fCustomer()
        {
            InitializeComponent();
            cbCustomerSearch.SelectedIndex = 3;
            comboBoxSex.SelectedIndex = 0;
            txbNationality.SelectedIndex = 0;
            //SaveCustomer.OverwritePrompt = true;
            cbCustomerSearch.SelectedIndex = 0;
            comboboxID.DisplayMember = "id";
            FormClosing += FCustomer_FormClosing;
            txbSearch.KeyPress += TxbSearch_KeyPress;
            dataGridViewCustomer.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            LoaddataGridViewCustomer("Select Customer.ID, Customer.Name, IDCard, CustomerType.Name, PhoneNumber, Address, Nationality from Customer join CustomerType on Customer.IDCustomerType = CustomerType.ID");
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
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ToolStripLabel1_Click(object sender, EventArgs e)
        {

        }
        private void BtnAddCustomer_Click(object sender, EventArgs e)
        {
            new fAddCustomer().ShowDialog();
            LoaddataGridViewCustomer("Select Customer.ID, Customer.Name, IDCard, CustomerType.Name, PhoneNumber, Address, Nationality from Customer join CustomerType on Customer.IDCustomerType = CustomerType.ID");
        }
        private void BindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            txbFullName.Text = string.Empty;
            txbAddress.Text = string.Empty;
            txbIDCard.Text = string.Empty;
            txbNationality.Text = string.Empty;
            txbPhoneNumber.Text = string.Empty;
        }
        private void BtnClose1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (txbFullName.Text != string.Empty && txbAddress.Text != string.Empty && txbIDCard.Text != string.Empty && txbPhoneNumber.Text != string.Empty)
            {
                DialogResult result = MessageBox.Show("Bạn có muốn cập nhật khách hàng này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.OK)
                    if (CheckDate())
                    {
                        Functions.Chaysql("Update Customer SET Name = N'"+txbFullName.Text+"', IDCustomerType ='"+comboBoxCustomerType.SelectedValue.ToString()+"', PhoneNumber ='"+txbPhoneNumber.Text+"',Address = N'"+txbAddress.Text+"', Sex = N'"+comboBoxSex.Text+ "',Nationality =N'"+txbNationality.Text+"', DateOfBirth = '"+datepickerDateOfBirth.Value+"' where ID = '"+comboboxID.Text+"'");
                        MessageBox.Show("Cập nhập khách hàng thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoaddataGridViewCustomer("Select Customer.ID, Customer.Name, IDCard, CustomerType.Name, PhoneNumber, Address, Nationality from Customer join CustomerType on Customer.IDCustomerType = CustomerType.ID");

                    }
                    else
                        MessageBox.Show("Ngày sinh phải nhỏ hơn ngày hiện tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Không được bỏ trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void Search()
        {
            if(cbCustomerSearch.Text == "Số điện thoại")
            {
                LoaddataGridViewCustomer("Select Customer.ID, Customer.Name, IDCard, CustomerType.Name, PhoneNumber, Address, Nationality from Customer join CustomerType on Customer.IDCustomerType = CustomerType.ID where PhoneNumber like '%"+txbSearch.Text+"%'");
            }
            if (cbCustomerSearch.Text == "Mã khách hàng")
            {
                LoaddataGridViewCustomer("Select Customer.ID, Customer.Name, IDCard, CustomerType.Name, PhoneNumber, Address, Nationality from Customer join CustomerType on Customer.IDCustomerType = CustomerType.ID where Customer.ID like '%" + txbSearch.Text + "%'");
            }
            if (cbCustomerSearch.Text == "Số CMND")
            {
                LoaddataGridViewCustomer("Select Customer.ID, Customer.Name, IDCard, CustomerType.Name, PhoneNumber, Address, Nationality from Customer join CustomerType on Customer.IDCustomerType = CustomerType.ID where IDCard like '%" + txbSearch.Text + "%'");
            }
            if (cbCustomerSearch.Text == "Tên khách hàng")
            {
                LoaddataGridViewCustomer("Select Customer.ID, Customer.Name, IDCard, CustomerType.Name, PhoneNumber, Address, Nationality from Customer join CustomerType on Customer.IDCustomerType = CustomerType.ID where Customer.Name like '%" + txbSearch.Text + "%'");
            }

        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            txbSearch.Text = txbSearch.Text.Trim();
            if (txbSearch.Text != string.Empty)
            {
                txbAddress.Text = string.Empty;
                txbFullName.Text = string.Empty;
                txbIDCard.Text = string.Empty;
                txbPhoneNumber.Text = string.Empty;
                txbNationality.Text = string.Empty;

                btnSearch.Visible = false;
                btnCancel.Visible = true;
                Search();
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = false;
            btnSearch.Visible = true;
        }
        public static bool CheckFillInText(Control[] controls)
        {
            foreach (var control in controls)
            {
                if (control.Text == string.Empty)
                    return false;
            }
            return true;
        }
       
   
        private void DataGridViewCustomer_SelectionChanged(object sender, EventArgs e)
        {
            txbFullName.Text = dataGridViewCustomer.CurrentRow.Cells[1].Value.ToString();
            txbIDCard.Text = dataGridViewCustomer.CurrentRow.Cells[2].Value.ToString();
            comboBoxCustomerType.Text = dataGridViewCustomer.CurrentRow.Cells[3].Value.ToString();
            txbPhoneNumber.Text = dataGridViewCustomer.CurrentRow.Cells[4].Value.ToString();
            txbAddress.Text = dataGridViewCustomer.CurrentRow.Cells[5].Value.ToString();
            txbNationality.Text = dataGridViewCustomer.CurrentRow.Cells[6].Value.ToString();
            comboBoxSex.Text = Functions.Laygiatri("select Sex from Customer where ID = '"+comboboxID.Text+"'");
        }
        private void TxbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || e.KeyChar == '\b'))
                e.Handled = true;
        }
        private bool CheckDate()
        {
            if (DateTime.Now.Subtract(datepickerDateOfBirth.Value).Days <= 0)
                return false;
            else return true;
        }
        private void Txb_Enter(object sender, EventArgs e)
        {
            Bunifu.Framework.UI.BunifuMetroTextbox text = sender as Bunifu.Framework.UI.BunifuMetroTextbox;
            text.Tag = text.Text;
        }
        private void Txb_Leave(object sender, EventArgs e)
        {
            Bunifu.Framework.UI.BunifuMetroTextbox text = sender as Bunifu.Framework.UI.BunifuMetroTextbox;
            if (text.Text == string.Empty)
                text.Text = text.Tag as string;
        }
        private void TxbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                BtnSearch_Click(sender, null);
            else
                if (e.KeyChar == 27 && btnCancel.Visible == true)
                BtnCancel_Click(sender, null);
        }
        private void FCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27 && btnCancel.Visible == true)
                BtnCancel_Click(sender, null);
        }
        private void FCustomer_FormClosing(object sender, FormClosingEventArgs e)
        { 

        }
        public void LoaddataGridViewCustomer(string sql)
        {
            dataGridViewCustomer.DataSource = dtBase.DataReader(sql);
            dataGridViewCustomer.Columns[0].HeaderText = "Mã";
            dataGridViewCustomer.Columns[1].HeaderText = "Họ Tên";
            dataGridViewCustomer.Columns[2].HeaderText = "Số CMND";
            dataGridViewCustomer.Columns[3].HeaderText = "Loại";
            dataGridViewCustomer.Columns[4].HeaderText = "SĐT";
            dataGridViewCustomer.Columns[5].HeaderText = "Địa Chỉ";
            dataGridViewCustomer.Columns[6].HeaderText = "Quốc Tịch";
            dataGridViewCustomer.Columns[0].Width = 45;
            dataGridViewCustomer.Columns[3].Width = 90;
            BindingSource source = new BindingSource();
            source.DataSource = dtBase.DataReader(sql);
            dataGridViewCustomer.DataSource = source;
            bindingCustomer.BindingSource = source;
            comboboxID.DataSource = source;
        }
        private void fCustomer_Load(object sender, EventArgs e)
        {
            comboBoxCustomerType.DataSource = dtBase.DataReader("SELECT Name,ID FROM CustomerType");
            comboBoxCustomerType.DisplayMember = "Name";
            comboBoxCustomerType.ValueMember = "ID";
            comboBoxCustomerType.SelectedIndex = 0;
        }
    }
}

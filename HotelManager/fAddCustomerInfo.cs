
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
    public partial class fAddCustomerInfo : Form
    {
        List<Sex> Listitem;
        List<Nationality> Listitem1;
        Class.Functions dtBase = new Class.Functions();
        int idReceiveRoomdetails;
        public fAddCustomerInfo(int a)
        {
            idReceiveRoomdetails = a;
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
        public void InsertReceiveDetails()
        {
            string sql,sql2;
            sql2= "SELECT ID from Customer where IDcard = '"+ txbIDCardSearch.Text+"'";
            if (!Functions.ktra(sql2))
            {
                  MessageBox.Show("Thẻ căn cước/CMND không tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            sql = "INSERT ReceiveRoomDetails(IDReceiveRoom,IDCustomerOther) VALUES ('"+idReceiveRoomdetails+"','"+Functions.laygiatri(sql2)+"')";
            Functions.Chaysql(sql);
            MessageBox.Show("Thêm khách hàng vào phòng thành công !.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (txbFullName.Text != string.Empty && txbIDCard.Text != string.Empty && txbAddress.Text != string.Empty && cbNationality.Text != string.Empty && txbPhoneNumber.Text != string.Empty)
            {
                if(txbIDCardSearch.Enabled==false)
                {
                    string sql = "select IDCard from Customer where IDCard = '"+txbIDCard.Text+"' and IDCard not in (select IDCard from ReceiveRoomDetails join Customer on Customer.ID = ReceiveRoomDetails.IDCustomerOther)";
                    if (Functions.ktra(sql))
                    {
                        InsertReceiveDetails();
                    }
                    else
                    {
                        MessageBox.Show("Thông tin khách hàng này đã được thêm vào phòng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (txbIDCardSearch.Enabled == true)
                {
                    string sql = "Select IDCard From Customer where IDCard ='"+txbIDCard+"'";
                    if(!Functions.ktra(sql))
                    {
                        if(CheckDate())
                        {
                            string sql2;
                            int a = Functions.key();
                            Functions.Chaysql("INSERT [dbo].[Customer] ([ID], [IDCard], [IDCustomerType], [Name], [DateOfBirth], [Address], [PhoneNumber], [Sex], [Nationality]) VALUES ('" + a + "',N'" + txbIDCard.Text + "','" + cbCustomerType.SelectedValue.ToString() + "',N'" + txbFullName.Text + "','" + dpkDateOfBirth.Value + "',N'" + txbAddress.Text + "','" + txbPhoneNumber.Text + "',N'" + cbSex.Text + "',N'" + cbNationality.Text + "')");
                            sql2 = "INSERT ReceiveRoomDetails(IDReceiveRoom,IDCustomerOther) VALUES ('" + idReceiveRoomdetails + "','" + a + "')";
                            Functions.Chaysql(sql2);
                            MessageBox.Show("Thêm khách hàng vào phòng thành công !.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Ngày sinh phải nhỏ hơn ngày hiện tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }    
                }    
            }
            else
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private bool CheckDate()
        {
            if (DateTime.Now.Subtract(dpkDateOfBirth.Value).Days <= 0)
                return false;
            else return true;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnSearch.Visible = false;
            btnCancel2.Visible = true;
            string sql = "SELECT ID From Customer where IDCard = '" + txbIDCardSearch.Text + "'";
            if (!Functions.ktra(sql))
            {
                MessageBox.Show("Thẻ căn cước/CMND không tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                LoadInfoIdcard();
                txbAddress.Enabled = false;
                txbFullName.Enabled = false;
                txbIDCard.Enabled = false;
                txbPhoneNumber.Enabled = false;
                txbIDCardSearch.Enabled = false;
            }
        }
        public void LoadInfoIdcard()
        {
            string str;
            str = "SELECT DateOfBirth FROM Customer WHERE IDCard = N'" + txbIDCardSearch.Text + "'";
            dpkDateOfBirth.Value = DateTime.Parse(Functions.laygiatri(str));
            str = "SELECT Name FROM Customer WHERE IDCard = N'" + txbIDCardSearch.Text + "'";
            txbFullName.Text = Functions.laygiatri(str);
            str = "SELECT CustomerType.Name FROM Customer join CustomerType on Customer.IDCustomerType = CustomerType.ID WHERE IDCard = N'" + txbIDCardSearch.Text + "'";
            cbCustomerType.Text = Functions.laygiatri(str);
            str = "SELECT PhoneNumber FROM Customer WHERE IDCard = N'" + txbIDCardSearch.Text + "'";
            txbPhoneNumber.Text = Functions.laygiatri(str);
            str = "SELECT IDCard FROM Customer WHERE IDCard = N'" + txbIDCardSearch.Text + "'";
            txbIDCard.Text = Functions.laygiatri(str);
            str = "SELECT Address FROM Customer WHERE IDCard = N'" + txbIDCardSearch.Text + "'";
            txbAddress.Text = Functions.laygiatri(str);
            str = "SELECT Sex FROM Customer WHERE IDCard = N'" + txbIDCardSearch.Text + "'";
            cbSex.Text = Functions.laygiatri(str);
            str = "SELECT Nationality FROM Customer WHERE IDCard = N'" + txbIDCardSearch.Text + "'";
            cbNationality.Text = Functions.laygiatri(str);
        }
        private void txbIDCardSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txbIDCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnClose__Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }

        private void fAddCustomerInfo_Load(object sender, EventArgs e)
        {
            cbCustomerType.DataSource = dtBase.DataReader("SELECT Name,ID FROM  CustomerType");
            cbCustomerType.DisplayMember = "Name";
            cbCustomerType.ValueMember = "ID";
            cbCustomerType.SelectedIndex = -1;
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            btnCancel2.Visible = false;
            btnSearch.Visible = true;
            txbFullName.Enabled = true;
            txbAddress.Enabled = true;
            txbFullName.Enabled = true;
            txbIDCard.Enabled = true;
            txbPhoneNumber.Enabled = true;
            txbIDCardSearch.Enabled = true;
            ClearData();
        }
        public void ClearData()
        {
            txbIDCardSearch.Text = txbIDCard.Text = txbFullName.Text = txbAddress.Text = txbPhoneNumber.Text = cbNationality.Text = String.Empty;
        }
    }
}

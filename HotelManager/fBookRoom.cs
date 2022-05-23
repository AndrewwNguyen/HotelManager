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
using HotelManager.Class;

namespace HotelManager
{
    public partial class fBookRoom : Form
    {
        List<Sex> Listitem;
        List<Nationality> Listitem1;
        Class.Functions dtBase = new Class.Functions();
        public fBookRoom()
        {
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
            LoadData();


        }
        public class Sex
        {
            public string name { get; set; }
        }
        public class Nationality
        {
            public string name { get; set; }
        }
        public void LoadData()
        {
            LoadDate();
            LoadDays();
            ClearData();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txbDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        public void LoadRoomType()
        {
            string sql = "Select ID from RoomType where Name = N'" + cbRoomType.Text + "'";
            txbRoomTypeID.Text = Functions.Laygiatri(sql);
            sql = "Select Name from RoomType where Name = N'" + cbRoomType.Text + "'";
            txbRoomTypeName.Text = Functions.Laygiatri(sql);
            sql = "Select LimitPerson from RoomType where Name = N'" + cbRoomType.Text + "'";
            txbAmountPeople.Text = Functions.Laygiatri(sql);
            sql = "Select Price from RoomType where Name = N'" + cbRoomType.Text + "'";
            txbPrice.Text = IntToString(Functions.Laygiatri(sql));
        }
        private void cbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRoomType();
        }
        string b = "Chưa nhận phòng";
        public void BookRoom()
        {
            int a;
            a = Functions.key();
            string sql1;
            string sql2;
            sql1 = "INSERT [dbo].[Customer] ([ID], [IDCard], [IDCustomerType], [Name], [DateOfBirth], [Address], [PhoneNumber], [Sex], [Nationality]) VALUES ('" + a + "',N'" + txbIDCard.Text + "','" + cbCustomerType.SelectedValue.ToString() + "',N'" + txbFullName.Text + "','" + dpkDateOfBirth.Value + "',N'" + txbAddress.Text + "','" + txbPhoneNumber.Text + "',N'" + cbSex.Text + "',N'" + cbNationality.Text + "')";
            sql2 = "INSERT [dbo].[BookRoom] ([ID], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut],[Days],[Checked]) VALUES ('" + Functions.key() + "','" + a + "','" + cbCustomerType.SelectedValue.ToString() + "','" + dpkDateCheckIn.Value + "','" + dpkDateCheckIn.Value + "','" + dpkDateCheckOut.Value + "','" + txbDays.Text + "','" + b + "')";
            Functions.Chaysql(sql1);
            Functions.Chaysql(sql2);
            MessageBox.Show("Đặt phòng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearData();
            LoaddataGridViewBookRoom();
            label5.Text = String.Empty;
        }
        private void dpkDateCheckOut_onValueChanged(object sender, EventArgs e)
        {
            if (dpkDateCheckOut.Value < DateTime.Now)
                LoadDate();
            if (dpkDateCheckOut.Value <= dpkDateCheckIn.Value)
                LoadDate();
            LoadDays();
        }

        private void dpkDateCheckIn_onValueChanged(object sender, EventArgs e)
        {
                        if (dpkDateCheckIn.Value <= DateTime.Now)
                LoadDate();
            if (dpkDateCheckOut.Value <= dpkDateCheckIn.Value)
                LoadDate();
            LoadDays();
        }

        private void txbIDCardSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txbIDCard_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private string IntToString(string text)
        {
            if (text == string.Empty)
                return 0.ToString("C0", CultureInfo.CreateSpecificCulture("vi-VN"));
            if (text.Contains(".") || text.Contains(" "))
                return text;
            else
                return (int.Parse(text).ToString("C0", CultureInfo.CreateSpecificCulture("vi-VN")));
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "SELECT IDCard FROM Customer WHERE IDCard = '" + txbIDCardSearch.Text + "'";
            if (!Functions.ktra(sql))
            {
                MessageBox.Show("Thẻ căn cước/CMND không tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                LoadInfoIdcard();
                label5.Text = Functions.Laygiatri("SELECT ID FROM Customer WHERE IDcard = '" + txbIDCardSearch.Text + "'");
                btnSearch.Visible = false;
                btnCancel2.Visible = true;
                HideText();
            }
        }
        public void LoaddataGridViewBookRoom()
        {
            dataGridViewBookRoom.DataSource = dtBase.DataReader("SELECT BookRoom.ID,Customer.Name,IDCard,RoomType.Name,DateCheckIn,DateCheckOut FROM BookRoom JOIN Customer ON BookRoom.IDCustomer= Customer.ID JOIN RoomType ON RoomType.ID = BookRoom.IDRoomType");
            dataGridViewBookRoom.Columns[0].HeaderText = "Mã đặt phòng";
            dataGridViewBookRoom.Columns[1].HeaderText = "Họ tên";
            dataGridViewBookRoom.Columns[2].HeaderText = "CMND";
            dataGridViewBookRoom.Columns[3].HeaderText = "Loại phòng";
            dataGridViewBookRoom.Columns[4].HeaderText = "Ngày Nhận";
            dataGridViewBookRoom.Columns[5].HeaderText = "Ngày trả";
        }
        private void btnBookRoom_Click(object sender, EventArgs e)
        {
            if (txbIDCard.Text != String.Empty && txbFullName.Text != String.Empty && txbAddress.Text != String.Empty && txbPhoneNumber.Text != String.Empty && cbNationality.Text != String.Empty)
            {
                if (MessageBox.Show("Bạn có muốn đặt phòng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sql = "SELECT IDCard FROM Customer WHERE IDCard = '" + txbIDCard.Text + "'";
                    if (!Functions.ktra(sql))
                    {

                        BookRoom();

                    }
                    else
                    {
                        if (label5.Text != String.Empty)
                        {
                            string sql2;
                            sql2 = "INSERT [dbo].[BookRoom] ([ID], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut],[Days],[Checked]) VALUES ('" + Functions.key() + "','" + label5.Text + "','" + txbRoomTypeID.Text + "','" + dpkDateCheckIn.Value + "','" + dpkDateCheckIn.Value + "','" + dpkDateCheckOut.Value + "','" + txbDays.Text + "','" + b + "')";
                            Functions.Chaysql(sql2);
                            MessageBox.Show("Đặt phòng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoaddataGridViewBookRoom();
                        }
                        else
                        {
                            MessageBox.Show("Thẻ căn cước/CMND đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txbIDCard.Text = string.Empty;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không được để trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnClose__Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            int idBookRoom = (int)dataGridViewBookRoom.SelectedRows[0].Cells[0].Value;
            string idCard = Functions.Laygiatri("SELECT ID FROM Customer WHERE IDCard = '" + dataGridViewBookRoom.SelectedRows[0].Cells[2].Value.ToString() + "'");
            fBookRoomDetails f = new fBookRoomDetails(idBookRoom, idCard);
            f.ShowDialog();
            LoaddataGridViewBookRoom();
        }

        private void txbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void fBookRoom_Load(object sender, EventArgs e)
        {
            cbRoomType.DataSource = dtBase.DataReader("SELECT Name,ID FROM Roomtype ");
            cbRoomType.DisplayMember = "Name";
            cbRoomType.ValueMember = "ID";
            cbRoomType.SelectedIndex = 0;
            cbCustomerType.DataSource = dtBase.DataReader("SELECT Name,ID FROM  CustomerType");
            cbCustomerType.DisplayMember = "Name";
            cbCustomerType.ValueMember = "ID";
            cbCustomerType.SelectedIndex = 0;
            LoaddataGridViewBookRoom();
        }
        public void LoadDate()
        {
            dpkDateOfBirth.Value = new DateTime(1998, 4, 6);
            dpkDateCheckIn.Value = DateTime.Now;
            dpkDateCheckOut.Value = DateTime.Now.AddDays(1);
        }
        public void LoadDays()
        {
            txbDays.Text = (dpkDateCheckOut.Value.Date - dpkDateCheckIn.Value.Date).Days.ToString();
        }
        public void ClearData()
        {
            txbIDCardSearch.Text = txbIDCard.Text = txbFullName.Text = txbAddress.Text = txbPhoneNumber.Text = cbNationality.Text = String.Empty;
            LoadDate();
        }
        public void LoadInfoIdcard()
        {
            string str;
            str = "SELECT DateOfBirth FROM Customer WHERE IDCard = N'" + txbIDCardSearch.Text + "'";
            dpkDateOfBirth.Value = DateTime.Parse(Functions.Laygiatri(str));
            str = "SELECT Name FROM Customer WHERE IDCard = N'" + txbIDCardSearch.Text + "'";
            txbFullName.Text = Functions.Laygiatri(str);
            str = "SELECT CustomerType.Name FROM Customer join CustomerType on Customer.IDCustomerType = CustomerType.ID WHERE IDCard = N'" + txbIDCardSearch.Text + "'";
            cbCustomerType.Text = Functions.Laygiatri(str);
            str = "SELECT PhoneNumber FROM Customer WHERE IDCard = N'" + txbIDCardSearch.Text + "'";
            txbPhoneNumber.Text = Functions.Laygiatri(str);
            str = "SELECT IDCard FROM Customer WHERE IDCard = N'" + txbIDCardSearch.Text + "'";
            txbIDCard.Text = Functions.Laygiatri(str);
            str = "SELECT Address FROM Customer WHERE IDCard = N'" + txbIDCardSearch.Text + "'";
            txbAddress.Text = Functions.Laygiatri(str);
            str = "SELECT Sex FROM Customer WHERE IDCard = N'" + txbIDCardSearch.Text + "'";
            cbSex.Text = Functions.Laygiatri(str);
            str = "SELECT Nationality FROM Customer WHERE IDCard = N'" + txbIDCardSearch.Text + "'";
            cbNationality.Text = Functions.Laygiatri(str);
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            btnCancel2.Visible = false;
            btnSearch.Visible = true;
            txbFullName.Enabled = false;
            ShowText();
            ClearData();
        }
        private void HideText()
        {
            txbFullName.Enabled = false;
            txbIDCard.Enabled = false;
            txbAddress.Enabled = false;
            cbCustomerType.Enabled = false;
            cbNationality.Enabled = false;
            cbSex.Enabled = false;
            txbPhoneNumber.Enabled = false;
            txbIDCard.Enabled = false;
        }
        private void ShowText()
        {
            txbFullName.Enabled = true;
            txbIDCard.Enabled = true;
            txbAddress.Enabled = true;
            cbCustomerType.Enabled = true;
            cbNationality.Enabled = true;
            cbSex.Enabled = true;
            txbPhoneNumber.Enabled = true;
            txbIDCard.Enabled = true;
        }

        private void cbRoomType_SelectedValueChanged(object sender, EventArgs e)
        {
        }
    }
}

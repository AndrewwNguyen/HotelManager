
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
    public partial class fBookRoomDetails : Form
    {
        List<Sex> Listitem;
        List<Nationality> Listitem1;
        Class.Functions dtBase = new Class.Functions();
        int idBookRoom;
        string idCard;
        public fBookRoomDetails(int _idBookRoom, string _idCard)
        {
            idBookRoom = _idBookRoom;
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

        private void dpkDateCheckIn_onValueChanged(object sender, EventArgs e)
        {
            if (dpkDateCheckIn.Value <= DateTime.Now)
                LoadDate();
            if (dpkDateCheckOut.Value <= dpkDateCheckIn.Value)
                LoadDate();
            LoadDays();
        }
        public void LoadDate()
        {
            dpkDateOfBirth.Value = new DateTime(2001, 2, 20);
            dpkDateCheckIn.Value = DateTime.Now;
            dpkDateCheckOut.Value = DateTime.Now.AddDays(1);
        }
        public void LoadDays()
        {
            txbDays.Text = (dpkDateCheckOut.Value.Date - dpkDateCheckIn.Value.Date).Days.ToString();
        }

        private void dpkDateCheckOut_onValueChanged(object sender, EventArgs e)
        {
            if (dpkDateCheckOut.Value < DateTime.Now)
                LoadDate();
            if (dpkDateCheckOut.Value <= dpkDateCheckIn.Value)
                LoadDate();
            LoadDays();
        }
        public void ClearData()
        {
            txbIDCard.Text = txbFullName.Text = txbAddress.Text = txbPhoneNumber.Text = cbNationality.Text = String.Empty;
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (txbIDCard.Text != String.Empty && txbFullName.Text != String.Empty && txbAddress.Text != String.Empty && txbPhoneNumber.Text != String.Empty && cbNationality.Text != String.Empty)
            {
                string sql1;
                sql1 = "UPDATE Customer SET Name = N'" + txbFullName.Text + "',IDCard = '" + txbIDCard.Text + "',IDCustomerType = '" + cbCustomerType.SelectedValue.ToString() + "',PhoneNumber = '" + txbPhoneNumber.Text + "',DateOfBirth = '" + dpkDateOfBirth.Value + "',Address = N'" + txbAddress.Text + "',Sex = '" + cbSex.Text + "',Nationality = N'" + cbNationality.Text + "' where ID = '" + idCard.ToString() + "'";
                Functions.UpdateData(sql1);
                MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không được để trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;   
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "UPDATE BookRoom SET DateCheckIn ='" + dpkDateCheckIn.Value + "',DateCheckOut = '" + dpkDateCheckOut.Value + "',Days = '" + txbDays.Text + "',IDRoomType = '" + cbRoomType.SelectedValue.ToString() + "' WHERE ID = '" + idBookRoom + "'";
            Functions.UpdateData(sql);
            MessageBox.Show("Cập nhật thông tin đặt phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa khách hàng dẫn đến phiếu đặt phòng cũng bị xóa!\nBạn có muốn tiếp tục?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                string sql;
                string sql2;
                sql = "DELETE Customer WHERE ID = '" + idCard + "'";
                Functions.UpdateData(sql);
                sql2 = "DELETE BookRoom WHERE ID = '" + idBookRoom + "'";
                Functions.UpdateData(sql2);
                MessageBox.Show("Xóa thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void fBookRoomDetails_Load(object sender, EventArgs e)
        {
            cbRoomType.DataSource = dtBase.DataReader("SELECT Name,ID FROM Roomtype");
            cbRoomType.DisplayMember = "Name";
            cbRoomType.ValueMember = "ID";
            cbRoomType.SelectedIndex = -1;
            cbCustomerType.DataSource = dtBase.DataReader("SELECT Name,ID FROM  CustomerType");
            cbCustomerType.DisplayMember = "Name";
            cbCustomerType.ValueMember = "ID";
            cbCustomerType.SelectedIndex = -1;
            string str;
            txbIDBookRoom.Text = idBookRoom.ToString();
            str = "SELECT Nationality FROM Customer WHERE ID = N'" + idCard + "'";
            cbNationality.Text = Functions.Laygiatri(str);
            str = "SELECT IDCard FROM Customer WHERE ID = N'" + idCard + "'";
            txbIDCard.Text = Functions.Laygiatri(str);
            str = "SELECT PhoneNumber FROM Customer WHERE ID = N'" + idCard + "'";
            txbPhoneNumber.Text = Functions.Laygiatri(str);
            str = "SELECT Sex FROM Customer WHERE ID = N'" + idCard + "'";
            cbSex.Text = Functions.Laygiatri(str);
            str = "SELECT Name FROM Customer WHERE ID = N'" + idCard + "'";
            txbFullName.Text = Functions.Laygiatri(str);
            str = "SELECT Address FROM Customer WHERE ID = N'" + idCard + "'";
            txbAddress.Text = Functions.Laygiatri(str);
            str = "SELECT CustomerType.Name FROM Customer join CustOmerType on Customer.IDCustomerType = CustomerType.ID where Customer.ID = N'" + idCard + "'";
            cbCustomerType.Text = Functions.Laygiatri(str);
            str = "SELECT DateCheckIn FROM BookRoom WHERE ID = N'" + idBookRoom + "'";
            dpkDateCheckIn.Value = DateTime.Parse(Functions.Laygiatri(str));
            str = "SELECT DateCheckOut FROM BookRoom WHERE ID = N'" + idBookRoom + "'";
            dpkDateCheckOut.Value = DateTime.Parse(Functions.Laygiatri(str));
            str = "SELECT Days FROM BookRoom WHERE ID = N'" + idBookRoom + "'";
            txbDays.Text = Functions.Laygiatri(str);
            str = "SELECT RoomType.Name FROM BookRoom join RoomType on BookRoom.IDRoomType= RoomType.ID WHERE BookRoom.ID =  N'" + idBookRoom + "'";
            cbRoomType.Text = Functions.Laygiatri(str);
            LoadDays();
            txbIDCard.Enabled = false;
        }
    }
}

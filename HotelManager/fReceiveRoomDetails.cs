
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
    public partial class fReceiveRoomDetails : Form
    {
        int idReceiveRoom;
        Class.Functions dtBase = new Class.Functions();
        public fReceiveRoomDetails(int _idReceiRoom)
        {
            idReceiveRoom = _idReceiRoom;
            InitializeComponent();

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClose__Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            int a = Int32.Parse(txbIDReceiveRoom.Text);
            fAddCustomerInfo f = new fAddCustomerInfo(a);
            f.ShowDialog();
            Show();
            LoadReceiveRoomDetails();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            string idCard = dataGridView.SelectedRows[0].Cells[1].Value.ToString();
            string sql1 = "select IDcard from Customer where IDCard = '"+idCard+"' and IDCard not in(select IDCard from Customer join BookRoom on Customer.ID = BookRoom.IDCustomer join ReceiveRoom on ReceiveRoom.IDBookRoom = BookRoom.ID)";
            if(Functions.ktra(sql1))
            {
                string sql;
                sql = "Delete ReceiveRoomDetails from ReceiveRoomDetails join Customer on ReceiveRoomDetails.IDCustomerOther = Customer.ID where Customer.IDCard= '" + idCard + "' ";
                Functions.Chaysql(sql);
                MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadReceiveRoomDetails();
            }
            else
            {
                   MessageBox.Show("Không thể xóa người đặt phòng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            string idCard = dataGridView.SelectedRows[0].Cells[1].Value.ToString();
            fUpdateCustomerInfo f = new fUpdateCustomerInfo(idCard);
            f.ShowDialog();
            Show();
            LoadReceiveRoomDetails();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {

            //fChangeRoom f = new fChangeRoom();
            //f.ShowDialog();
        }

        private void fReceiveRoomDetails_Load(object sender, EventArgs e)
        {
            txbIDReceiveRoom.Text = idReceiveRoom.ToString();
            string str;
            str = "SELECT Room.Name from ReceiveRoom join Room on ReceiveRoom.IDRoom = Room.ID where ReceiveRoom.ID ='" + txbIDReceiveRoom.Text+ "'";
            txbRoomName.Text = Functions.laygiatri(str);
            str = "SELECT DateCheckIn from ReceiveRoom join BookRoom on ReceiveRoom.IDBookRoom = BookRoom.ID where ReceiveRoom.ID='" + txbIDReceiveRoom.Text + "'";
            txbDateCheckIn.Text = Functions.laygiatri(str);
            str = "SELECT DateCheckOut from ReceiveRoom join BookRoom on ReceiveRoom.IDBookRoom = BookRoom.ID where ReceiveRoom.ID='" + txbIDReceiveRoom.Text + "'";
            txbDateCheckOut.Text = Functions.laygiatri(str);
            LoadReceiveRoomDetails();
        }
        public void LoadReceiveRoomDetails()
        {
            dataGridView.DataSource = dtBase.DataReader("SELECT Customer.Name,Customer.IDCard,Customer.Address,PhoneNumber,Nationality from ReceiveRoom join ReceiveRoomDetails on ReceiveRoom.ID = ReceiveRoomDetails.IDReceiveRoom join Customer on ReceiveRoomDetails.IDCustomerOther = Customer.ID where ReceiveRoom.ID = '"+idReceiveRoom+"'");
            dataGridView.Columns[0].HeaderText = "Tên Khách Hàng";
            dataGridView.Columns[1].HeaderText = "CMND";
            dataGridView.Columns[2].HeaderText = "Địa Chỉ";
            dataGridView.Columns[3].HeaderText = "Số điện thoại";
            dataGridView.Columns[4].HeaderText = "Quốc Tịch";
        }
    }
}


using HotelManager.Class;
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

namespace HotelManager
{
    public partial class fAddRoom : Form
    {
        Class.Functions dtBase = new Class.Functions();
        public fAddRoom()
        {
            InitializeComponent();
        }
 
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (txbNameRoom.Text == "")
            {
                MessageBox.Show("Bạn phải tên phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (txbNameRoom.Text != "")
            {
                string ktra;
                ktra = "SELECT Name FROM Room WHERE Name=N'" + txbNameRoom.Text + "'";
                if (Functions.ktra(ktra))
                {
                    MessageBox.Show("Tên phòng đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn thêm phòng mới?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.OK)
                    {
                        int a;
                        string sql;
                        a = Functions.key();
                        sql = "INSERT INTO Room (ID,Name,IDRoomType,IDStatusRoom) VALUES ('" + a + "','" + txbNameRoom.Text + "',N'" + comboBoxRoomType.SelectedValue + "'," + 1 + ")";
                        Functions.Chaysql(sql);
                        txbNameRoom.Text = string.Empty;
                        MessageBox.Show("Thêm Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        private void btnClose__Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fAddRoom_Load(object sender, EventArgs e)
        {
            comboBoxRoomType.DataSource = dtBase.DataReader("SELECT ID,Name FROM RoomType");
            comboBoxRoomType.DisplayMember = "Name";
            comboBoxRoomType.ValueMember = "ID";
            comboBoxRoomType.SelectedIndex = -1;
        }

        private void comboBoxRoomType_SelectedValueChanged(object sender, EventArgs e)
        {
            string str, str1;
            if (comboBoxRoomType.Text == "")
            {
                txbPrice.Text = "";
                txbLimitPerson.Text = "";
            }
            str = "SELECT Price FROM RoomType WHERE ID =N'" + comboBoxRoomType.SelectedIndex + "'";
            str1 = "SELECT LimitPerson FROM RoomType WHERE ID =N'" + comboBoxRoomType.SelectedIndex + "'";
            txbPrice.Text = Functions.laygiatri(str);
            txbLimitPerson.Text = Functions.laygiatri(str1);
        }
    }
}

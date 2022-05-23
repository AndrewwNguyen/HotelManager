using HotelManager.Class;
using HotelManager.DAO;
using HotelManager.DTO;
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
    public partial class fAddService : Form
    {
        Class.Functions dtBase = new Class.Functions();
        public fAddService()
        {
            InitializeComponent();
            txbPrice.Text = IntToString("100000");

        }

        private string StringToInt(string text)
        {
            if (text.Contains(".") || text.Contains(" "))
            {
                string[] vs = text.Split(new char[] { '.', ' ' });
                StringBuilder textNow = new StringBuilder();
                for (int i = 0; i < vs.Length - 1; i++)
                {
                    textNow.Append(vs[i]);
                }
                return textNow.ToString();
            }
            else return text;
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

        private void TxbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void TxbPrice_Leave(object sender, EventArgs e)
        {
            if (txbPrice.Text == string.Empty)
                txbPrice.Text = txbPrice.Tag as string;
            else
                txbPrice.Text = IntToString(txbPrice.Text);
        }
        private void TxbPrice_Enter(object sender, EventArgs e)
        {
            txbPrice.Tag = txbPrice.Text;
            txbPrice.Text = StringToInt(txbPrice.Text);
        }
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if(txbName.Text==string.Empty &&txbPrice.Text ==string.Empty)
            {
                MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                string sql = "select Name from Service where Name = '"+txbName.Text+"'";
                if (!Functions.ktra(sql))
                {
                    Functions.Chaysql("insert Service(ID,Name,IDServiceType,Price) VALUES('"+Functions.key()+"',N'"+txbName.Text+"','"+comboBoxServiceType.SelectedIndex.ToString()+"','"+ StringToInt(txbPrice.Text) + "')");
                    MessageBox.Show("Thêm dịch vụ thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                    txbName.Text = string.Empty;
                    txbPrice.Text = IntToString("100000");
                }
                else
                {
                    MessageBox.Show("Tên dịch vụ đã có", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }    
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fAddService_Load(object sender, EventArgs e)
        {
            comboBoxServiceType.DataSource = dtBase.DataReader("SELECT Name,ID FROM ServiceType");
            comboBoxServiceType.DisplayMember = "Name";
            comboBoxServiceType.ValueMember = "ID";
        }
    }
}

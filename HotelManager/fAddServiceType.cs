
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
    public partial class fAddServiceType : Form
    {
        public fAddServiceType()
        {
            InitializeComponent();
        }
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if(txbName.Text != string.Empty)
            {
                DialogResult result = MessageBox.Show("Bạn có muốn thêm mới loại dịch vụ không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.OK)
                {
                    if(Functions.ktra("select Name from ServiceType where Name = '"+txbName.Text+"'"))
                    {
                        MessageBox.Show("Loại dịch vụ này đã có", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Functions.Chaysql("Insert ServiceType (ID,Name) VALUES('" + Functions.key() + "',N'" + txbName.Text + "')");
                        MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txbName.Text = string.Empty;
                        MessageBox.Show("Loại dịch vụ này đã có", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
                
        }

        private void btnClose__Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

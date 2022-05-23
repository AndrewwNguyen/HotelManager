using HotelManager.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fService : Form
    {
        Class.Functions dtBase = new Class.Functions();
        public fService()
        {
            InitializeComponent();
            comboboxID.DisplayMember = "id";
            txbSearch.KeyPress += TxbSearch_KeyPress;
            btnCancel.Click += BtnCancel_Click;
            KeyPreview = true;
            KeyPress += FService_KeyPress;
            LoaddataGridViewService("select Service.ID, Service.Name, Service.Price, ServiceType.Name from dbo.Service join ServiceType on Service.IDServiceType = ServiceType.ID");
            dataGridViewService.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
        }
        private void BtnInsertService_Click(object sender, EventArgs e)
        {
            new fAddService().ShowDialog();
            if (btnCancel.Visible == false)
            {
                LoaddataGridViewService("select Service.ID, Service.Name, Service.Price, ServiceType.Name from dbo.Service join ServiceType on Service.IDServiceType = ServiceType.ID");
            }
            else
                BtnCancel_Click(null, null);

        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            UpdateService();

        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnServiceType_Click(object sender, EventArgs e)
        {
            new fServiceType().ShowDialog();
            if (btnCancel.Visible == false)
            {
                LoaddataGridViewService("select Service.ID, Service.Name, Service.Price, ServiceType.Name from dbo.Service join ServiceType on Service.IDServiceType = ServiceType.ID");
            }
            else
                BtnCancel_Click(null, null);
        }
        private void BindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            txbName.Text = string.Empty;
            txbPrice.Text = string.Empty;
        }
        private void BtnCLose1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ToolStripLabel1_Click(object sender, EventArgs e)
        {
            
   
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (txbSearch.Text != string.Empty)
            {
                btnSearch.Visible = false;
                btnCancel.Visible = true;
                Search();
                txbSearch.Enabled = false;
            }

        }
        private void Search()
        {
            LoaddataGridViewService("select Service.ID, Service.Name, Service.Price, ServiceType.Name from dbo.Service join ServiceType on Service.IDServiceType = ServiceType.ID where Service.ID like '%" + txbSearch.Text + "%'or Service.Name like '%"+txbSearch.Text+"%'");

        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {

        }

        private void ChangePrice(DataTable table)
        {
            table.Columns.Add("price_New", typeof(string));
            for (int i = 0; i < table.Rows.Count; i++)
            {
                table.Rows[i]["price_New"] = ((int)table.Rows[i]["price"]).ToString("C0", CultureInfo.CreateSpecificCulture("vi-VN"));
            }
        }

        private void ChangeText(DataGridViewRow row)
        {

 
        }
 
        private void DataGridViewService_SelectionChanged(object sender, EventArgs e)
        {

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
        public void UpdateService()
        {
            if (comboboxID.Text == string.Empty)
                MessageBox.Show("Dịch vụ không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else
            {
                if(txbName.Text == string.Empty && txbPrice.Text ==string.Empty)
                {
                    MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else

                {
                    if(Functions.ktra("select Name from Service where Name ='"+txbName.Text+"'"))
                    {
                        MessageBox.Show("Dịch vụ đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        string sql = "Update Service SET Name = N'" + txbName.Text + "',Price = '" + StringToInt(txbPrice.Text) + "' where ID = '" + comboboxID.Text + "'";
                        Functions.Chaysql(sql);
                        MessageBox.Show("Cập nhập dịch vụ thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoaddataGridViewService("select Service.ID, Service.Name, Service.Price, ServiceType.Name from dbo.Service join ServiceType on Service.IDServiceType = ServiceType.ID");
                    }
                }
            }     
        }
        private void TxbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                BtnSearch_Click(sender, null);
            else
                if (e.KeyChar == 27 && btnCancel.Visible == true)
                BtnCancel_Click(sender, null);
        }
        private void FService_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27 && btnCancel.Visible == true)
                BtnCancel_Click(sender, null);
        }

        private void TxbPrice_Enter(object sender, EventArgs e)
        {
            txbPrice.Tag = txbPrice.Text;
            txbPrice.Text = StringToInt(txbPrice.Text);
        }
        private void TxbName_Enter(object sender, EventArgs e)
        {
            txbName.Tag = txbName.Text;
        }
        private void TxbPrice_Leave(object sender, EventArgs e)
        {
            if (txbPrice.Text == string.Empty)
                txbPrice.Text = txbPrice.Tag as string;
            else
                txbPrice.Text = IntToString(txbPrice.Text);
        }
        private void TxbName_Leave(object sender, EventArgs e)
        {
            if (txbName.Text == string.Empty)
                txbName.Text = txbName.Tag as string;
        }

        private void FService_FormClosing(object sender, FormClosingEventArgs e)
        {
            BtnCancel_Click(sender, null);
        }

        private void fService_Load(object sender, EventArgs e)
        {
            comboboxID.DataSource = dtBase.DataReader("SELECT Name,ID FROM Service");
            comboboxID.DisplayMember = "ID";
            comboboxID.ValueMember = "Name";
            comboboxID.SelectedIndex = 0;
            comboBoxServiceType.DataSource = dtBase.DataReader("SELECT Name,ID FROM ServiceType");
            comboBoxServiceType.DisplayMember = "Name";
            comboBoxServiceType.ValueMember = "ID";
            comboBoxServiceType.SelectedIndex = 0;
            string sql = "Select Price from Service where ID = N'" + comboboxID.Text + "'";
            txbPrice.Text = Functions.Laygiatri(sql);
            sql = "Select Name Value from Service where ID = N'" + comboboxID.Text+ "'";
            txbName.Text = Functions.Laygiatri(sql);
            //Showvalues();
        }
        private void comboboxID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadValue();
        }
        public void LoaddataGridViewService(string sql)
        {
            dataGridViewService.DataSource = dtBase.DataReader(sql);
            dataGridViewService.Columns[0].HeaderText = "Mã";
            dataGridViewService.Columns[1].HeaderText = "Tên";
            dataGridViewService.Columns[2].HeaderText = "Giá";
            dataGridViewService.Columns[3].HeaderText = "Loại dịch vụ";
            dataGridViewService.Columns[3].Width = 140;
            dataGridViewService.Columns[1].Width = 170;
            IntToString(dataGridViewService.CurrentRow.Cells[2].Value.ToString());
            BindingSource source = new BindingSource();
            source.DataSource = dtBase.DataReader(sql);
            dataGridViewService.DataSource = source;
            bindingService.BindingSource = source;
            comboboxID.DataSource = source;

        }
        public void LoadService()
        {
            string sql = "Select Price from Service where ID = N'" + comboboxID.Text + "'";
            txbPrice.Text = IntToString(Functions.Laygiatri(sql));
            sql = "Select Name Value from Service where ID = N'" + comboboxID.Text + "'";
            txbName.Text = Functions.Laygiatri(sql);
            sql = "Select ServiceType.Name from Service join ServiceType on Service.IDServiceType = ServiceType.ID where Service.ID = N'" + comboboxID.Text + "'";
            comboBoxServiceType.Text = Functions.Laygiatri(sql);
        }
        private void dataGridViewService_SelectionChanged_1(object sender, EventArgs e)
        {
            txbName.Text = dataGridViewService.CurrentRow.Cells[1].Value.ToString();
            comboboxID.Text = dataGridViewService.CurrentRow.Cells[0].Value.ToString();
            txbPrice.Text = IntToString(dataGridViewService.CurrentRow.Cells[2].Value.ToString());
            comboBoxServiceType.Text = dataGridViewService.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            txbSearch.Enabled = true;
            txbName.Text = string.Empty;
            txbPrice.Text = string.Empty;
            txbSearch.Text = string.Empty;
            comboboxID.SelectedIndex = 0;
            btnSearch.Visible = true;
            btnCancel.Visible = false;
            comboBoxServiceType.SelectedIndex = 0;
            LoaddataGridViewService("select Service.ID, Service.Name, Service.Price, ServiceType.Name from dbo.Service join ServiceType on Service.IDServiceType = ServiceType.ID");
        }

        private void comboboxID_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadService();
        }
    }
}

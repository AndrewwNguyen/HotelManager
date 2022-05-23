
using HotelManager.Class;
using System;
using System.Data;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fParameter : Form
    {
        public fParameter()
        {
           
            InitializeComponent();
            dataGridViewParameter.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            LoaddataGridViewParameter("select Name,Value, Describe, DateModify from Parameter");
        }
        Class.Functions dtBase = new Class.Functions();
        private void BtnCLose1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show( "Bạn có muốn cập nhật không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                UpdateSurcharge();
                comboboxName.Focus();
            }
        }
        public void UpdateSurcharge()
        {
            if (comboboxName.Text != string.Empty && comboboxName.Text !=string.Empty)
            {
                Functions.Chaysql("Update Parameter SET Value ='"+txbValue.Text+ "', Describe = '"+txbDescribe.Text+ "',DateModify = '"+DateTime.Now+"' where Name = N'"+comboboxName.Text+"'");
                MessageBox.Show("Cập nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoaddataGridViewParameter("select Name,Value, Describe, DateModify from Parameter");
            }
            else
            {
                MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }
        private void ToolStripLabel1_Click(object sender, EventArgs e)
        {
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            txbDescribe.Text = string.Empty;
            txbValue.Text = "0";
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            txbSearch.Text = txbSearch.Text.Trim();
            if (txbSearch.Text != string.Empty)
            {
                txbValue.Text = string.Empty;
                btnSearch.Visible = false;
                btnCancel.Visible = true;
                Search();
                txbSearch.Enabled = false;
            }
        }
        public void Search()
        {
            LoaddataGridViewParameter("select  Name,Value, Describe, DateModify From Parameter where Name Like '%" + txbSearch.Text + "%'");

        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = false;
            btnSearch.Visible = true;
            txbSearch.Enabled = true;
        }
 

        private void TxbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '.'))
                e.Handled = true;
        }


        private void DataGridSurcharge_SelectionChanged(object sender, EventArgs e)
        {
            Showvalues();
        }
        public void Showvalues()
        {
            comboboxName.Text = dataGridViewParameter.CurrentRow.Cells[0].Value.ToString();
            txbValue.Text = dataGridViewParameter.CurrentRow.Cells[1].Value.ToString();
            txbDescribe.Text = dataGridViewParameter.CurrentRow.Cells[2].Value.ToString();
        }
        private void TxbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                BtnSearch_Click(sender, null);
            else
                if (e.KeyChar == 27 && btnCancel.Visible == true)
                BtnCancel_Click(sender, null);
        }
        private void FParameter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27 && btnCancel.Visible == true)
                BtnCancel_Click(sender, null);
        }
        private void Txb_Enter(object sender, EventArgs e)
        {
            var textBox = sender as Bunifu.Framework.UI.BunifuMetroTextbox;
            textBox.Tag = textBox.Text;
        }
        private void Txb_Leave(object sender, EventArgs e)
        {
            var textBox = sender as Bunifu.Framework.UI.BunifuMetroTextbox;
            if(textBox.Text == string.Empty)
            {
                textBox.Text = textBox.Tag as string;
            }
        }

        private void FParameter_FormClosing(object sender, FormClosingEventArgs e)
        {
            BtnCancel_Click(sender, null);
        }


        private void fParameter_Load(object sender, EventArgs e)
        {
            comboboxName.DataSource = dtBase.DataReader("SELECT Name FROM Parameter");
            comboboxName.DisplayMember = "Name";
            comboboxName.ValueMember = "Name";
            comboboxName.SelectedIndex = 0;
            LoadValue();
        }
        public void LoadValue()
        {
            string sql = "Select Value from Parameter where Name = N'" + comboboxName.SelectedValue + "'";
            txbValue.Text = Functions.Laygiatri(sql);
            sql = "Select Describe Value from Parameter where Name = N'" + comboboxName.SelectedValue + "'";
            txbDescribe.Text = Functions.Laygiatri(sql);
        }
        private void comboboxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadValue();
        }

        public void LoaddataGridViewParameter(string sql)
        {
            dataGridViewParameter.DataSource = dtBase.DataReader(sql);
            dataGridViewParameter.Columns[0].HeaderText = "Tên";
            dataGridViewParameter.Columns[1].HeaderText = "Giá trị";
            dataGridViewParameter.Columns[2].HeaderText = "Miêu tả";
            dataGridViewParameter.Columns[3].HeaderText = "Ngày cập nhập";
            dataGridViewParameter.Columns[2].Width = 350;
            dataGridViewParameter.Columns[0].Width = 55;
            dataGridViewParameter.Columns[1].Width = 65;
            dataGridViewParameter.Columns[3].Width = 130;
            BindingSource source = new BindingSource();
            source.DataSource = dtBase.DataReader(sql);
            dataGridViewParameter.DataSource = source;
            bindingSurcharge.BindingSource = source;
            comboboxName.DataSource = source;
        }
    }
}

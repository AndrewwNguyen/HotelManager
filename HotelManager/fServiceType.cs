using System.Data;
using System.Windows.Forms;
using HotelManager.DAO;
using HotelManager.DTO;
using System;
using HotelManager.Class;

namespace HotelManager
{
    public partial class fServiceType : Form
    {
        Class.Functions dtBase = new Class.Functions();
        public fServiceType()
        {
            InitializeComponent();
            LoaddataGridViewServiceType("select ID, Name from ServiceType");
            dataGridViewServiceType.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnUpdateServiceType_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn cập nhật loại dịch vụ này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                UpdateServiceType();
            LoaddataGridViewServiceType("select ID, Name from ServiceType");
            comboboxID.Focus();
        }
        public void UpdateServiceType()
        {
            if (txbName.Text != string.Empty)
            {
                    Functions.Chaysql("Update ServiceType SET Name = N'" + txbName.Text + "' where ID = '" + comboboxID.Text + "'");
                    MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnCLose1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnInsert_Click(object sender, EventArgs e)
        {
            new fAddServiceType().ShowDialog();
                LoaddataGridViewServiceType("select ID, Name from ServiceType");

        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            txbName.Text = string.Empty;
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

            }
        }
        public void Search()
        {
            dataGridViewServiceType.DataSource = dtBase.DataReader("select ID, Name from ServiceType  where ServiceType.ID = '" + txbSearch.Text + "'");
            dataGridViewServiceType.Columns[0].HeaderText = "Mã loại dịch vụ";
            dataGridViewServiceType.Columns[1].HeaderText = "Tên loại dịch vụ";
            BindingSource source = new BindingSource();
            source.DataSource = dtBase.DataReader("select ID, Name from ServiceType  where ServiceType.ID = '" + txbSearch.Text + "'");
            dataGridViewServiceType.DataSource = source;
            bindingServiceType.BindingSource = source;
            comboboxID.DataSource = source;
            txbName.Text = dataGridViewServiceType.CurrentRow.Cells[1].Value.ToString();
            comboboxID.Text = dataGridViewServiceType.CurrentRow.Cells[0].Value.ToString();

        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = false;
            btnSearch.Visible = true;
            LoaddataGridViewServiceType("select ID, Name from ServiceType");
        }
        public void ShowServiceType()
        {
            comboboxID.Text = dataGridViewServiceType.CurrentRow.Cells[0].Value.ToString();
            txbName.Text = dataGridViewServiceType.CurrentRow.Cells[1].Value.ToString();
        }
        private void DataGridViewServiceType_SelectionChanged(object sender, EventArgs e)
        {
            ShowServiceType();
        }

        private void fServiceType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnUpdateServiceType_Click(sender, e);
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

        private void FServiceType_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.BtnCancel_Click(sender, null);
            this.txbSearch.Text = string.Empty;
        }

        private void fServiceType_Load(object sender, EventArgs e)
        {
            comboboxID.DataSource = dtBase.DataReader("SELECT ID,Name FROM ServiceType");
            comboboxID.DisplayMember = "ID";
            comboboxID.ValueMember = "Name";
            comboboxID.SelectedIndex = 0;
            ShowServiceType();

        }
        public void LoaddataGridViewServiceType(string sql)
        {
            dataGridViewServiceType.DataSource = dtBase.DataReader(sql);
            dataGridViewServiceType.Columns[0].HeaderText = "Mã loại dịch vụ";
            dataGridViewServiceType.Columns[1].HeaderText = "Tên loại dịch vụ";
            dataGridViewServiceType.Columns[0].Width = 130;
            dataGridViewServiceType.Columns[1].Width = 410;
            BindingSource source = new BindingSource();
            source.DataSource = dtBase.DataReader(sql);
            dataGridViewServiceType.DataSource = source;
            bindingServiceType.BindingSource = source;
            comboboxID.DataSource = source;

        }
        public void LoadServiceType()
        {
            string sql = "select Name from ServiceType where Name = '" + comboboxID.SelectedValue + "'";
            txbName.Text = Functions.Laygiatri(sql);
        }
        private void comboboxID_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadServiceType();
        }
    }
}

using HotelManager.DAO;
using HotelManager.DTO;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fRoom : Form
    {
        #region Properties
        private fRoomType _fRoomtType;
        #endregion

        #region Constructor
        public fRoom()
        {
            InitializeComponent();
            dataGridViewRoom.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnAddRoom_Click(object sender, EventArgs e)
        {
            fAddRoom f = new fAddRoom();
            f.ShowDialog();
        }
        private void BtnRoomType_Click(object sender, EventArgs e)
        {

        }
        private void BtnCLose1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            txbNameRoom.Text = string.Empty;
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {

        }
        private void ToolStripLabel1_Click(object sender, EventArgs e)
        {
            if (saveRoom.ShowDialog() == DialogResult.Cancel)
                return;
            else
            {
                bool check;
                try
                {
                    switch (saveRoom.FilterIndex)
                    {
                        case 2:
                            check = ExportToExcel.Instance.Export(dataGridViewRoom, saveRoom.FileName, ModeExportToExcel.XLSX);
                            break;
                        case 3:
                            check = ExportToExcel.Instance.Export(dataGridViewRoom, saveRoom.FileName, ModeExportToExcel.PDF);
                            break;
                        default:
                            check = ExportToExcel.Instance.Export(dataGridViewRoom, saveRoom.FileName, ModeExportToExcel.XLS);
                            break;
                    }
                    if (check)
                        MessageBox.Show( "Xuất thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show( "Lỗi xuất thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    MessageBox.Show( "Lỗi (Cần cài đặt Office)", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    

        private void BtnSearch_Click(object sender, EventArgs e)
        {

        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = false;
            btnSearch.Visible = true;
        }


        private void DataGridViewRoom_SelectionChanged(object sender, EventArgs e)
        {

        }
        private void ComboBoxRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxRoomType.SelectedIndex;

            if (((DataTable)comboBoxRoomType.DataSource).Rows[index]["Price"].ToString().Contains("."))
                return;
            txbPrice.Text = ((int)((DataTable)comboBoxRoomType.DataSource).Rows[index]["Price"]).ToString("C0", CultureInfo.CreateSpecificCulture("vi-VN"));
        }
 
        private void TxbNameRoom_Enter(object sender, EventArgs e)
        {
            txbNameRoom.Tag = txbNameRoom.Text;
        }
        private void TxbNameRoom_Leave(object sender, EventArgs e)
        {
            if (txbNameRoom.Text == string.Empty)
                txbNameRoom.Text = txbNameRoom.Tag as string;
        }
        #endregion

        #region Key
        private void TxbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                BtnSearch_Click(sender, null);
            else
                if (e.KeyChar == 27 && btnCancel.Visible == true)
                BtnCancel_Click(sender, null);
        }
        private void FRoom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27 && btnCancel.Visible == true)
                BtnCancel_Click(sender, null);
        }
        #endregion

        #region Close
        private void FRoom_FormClosing(object sender, FormClosingEventArgs e)
        {
            BtnCancel_Click(sender, null);
        }
        #endregion
    }
}

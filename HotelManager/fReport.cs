
using HotelManager.Class;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HotelManager
{
    public partial class fReport : Form
    {
        Class.Functions dtBase = new Class.Functions();
        private int month = 1;
        private int year = 1990;
        public fReport()
        {
           
            InitializeComponent();
            dataGridReport.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            LoaddataGridReport("select RoomType.Name, 1.0*SUM(TotalPrice-(TotalPrice*(Discount/100)))/(select SUM(TotalPrice-(TotalPrice*(Discount/100))) from RoomType join BookRoom on BookRoom.IDRoomType = RoomType.ID join ReceiveRoom on ReceiveRoom.IDBookRoom = BookRoom.ID join Bill on Bill.IDReceiveRoom = ReceiveRoom.ID where Bill.IDStatusBill =2 )*100,SUM(TotalPrice-(TotalPrice*(Discount/100))) as price from RoomType join BookRoom on BookRoom.IDRoomType = RoomType.ID join ReceiveRoom on ReceiveRoom.IDBookRoom = BookRoom.ID join Bill on Bill.IDReceiveRoom = ReceiveRoom.ID where Bill.IDStatusBill =2  and MONTH(DateOfCreate) = '"+comboBoxMonth.Text+"' group by RoomType.Name");
        }


        #region Click
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            LoaddataGridReport("select RoomType.Name, 1.0*SUM(TotalPrice-(TotalPrice*(Discount/100)))/(select SUM(TotalPrice-(TotalPrice*(Discount/100))) from RoomType join BookRoom on BookRoom.IDRoomType = RoomType.ID join ReceiveRoom on ReceiveRoom.IDBookRoom = BookRoom.ID join Bill on Bill.IDReceiveRoom = ReceiveRoom.ID where Bill.IDStatusBill =2 )*100,SUM(TotalPrice-(TotalPrice*(Discount/100))) as price from RoomType join BookRoom on BookRoom.IDRoomType = RoomType.ID join ReceiveRoom on ReceiveRoom.IDBookRoom = BookRoom.ID join Bill on Bill.IDReceiveRoom = ReceiveRoom.ID where Bill.IDStatusBill =2  and MONTH(DateOfCreate) = '"+comboBoxMonth.Text+"' group by RoomType.Name");

        }
        private void ToolStripLabel1_Click(object sender, EventArgs e)
        {
          
        }


        private void DrawChart(BindingSource source)
        {   
            chartReport.DataSource = source;
            chartReport.DataBind();
            foreach (DataPoint item in chartReport.Series[0].Points)
            {
                if(item.YValues[0] == 0)
                {
                    item.Label = " ";
                }
            }
        }

        private void FReport_Load(object sender, EventArgs e)
        {
            comboBoxMonth.SelectedIndex = 0;
        }
        #endregion

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Close();
        }
        int id = 0;
        //public void ShowBillPreView()
        //{
        //    DataTable dataTable = dtBase.DataReader("select D.Name [Tên dịch vụ],D.Price[Đơn giá],B.Count[Số lượng],B.TotalPrice[Thành tiền] from Bill A, BillDetails B, ReceiveRoom C, Service D where A.ID = b.IDBill and A.IDReceiveRoom = C.ID and B.IDService = D.ID and A.ID = '" + idbill + "'");
        //    CultureInfo cultureInfo = new CultureInfo("vi-vn");
        //    int _totalPrice = 0;
        //    foreach (DataRow item in dataTable.Rows)
        //    {
        //        ListViewItem listViewItem = new ListViewItem(id.ToString());
        //        id++;

        //        ListViewItem.ListViewSubItem subItem1 = new ListViewItem.ListViewSubItem(listViewItem, item["Tên dịch vụ"].ToString());
        //        ListViewItem.ListViewSubItem subItem2 = new ListViewItem.ListViewSubItem(listViewItem, ((int)item["Đơn giá"]).ToString("c0", cultureInfo));
        //        ListViewItem.ListViewSubItem subItem3 = new ListViewItem.ListViewSubItem(listViewItem, ((int)item["Số lượng"]).ToString());
        //        ListViewItem.ListViewSubItem subItem4 = new ListViewItem.ListViewSubItem(listViewItem, ((int)item["Thành tiền"]).ToString("c0", cultureInfo));


        //        _totalPrice += (int)item["Thành tiền"];

        //        listViewItem.SubItems.Add(subItem1);
        //        listViewItem.SubItems.Add(subItem2);
        //        listViewItem.SubItems.Add(subItem3);
        //        listViewItem.SubItems.Add(subItem4);

        //        listViewUseService.Items.Add(listViewItem);
        //    }

        //    ListViewItem listViewItemTotalPrice = new ListViewItem();
        //    ListViewItem.ListViewSubItem subItemTotalPrice = new ListViewItem.ListViewSubItem(listViewItemTotalPrice, _totalPrice.ToString("c0", cultureInfo));
        //    ListViewItem.ListViewSubItem _subItem1 = new ListViewItem.ListViewSubItem(listViewItemTotalPrice, "");
        //    ListViewItem.ListViewSubItem _subItem2 = new ListViewItem.ListViewSubItem(listViewItemTotalPrice, "");
        //    ListViewItem.ListViewSubItem _subItem3 = new ListViewItem.ListViewSubItem(listViewItemTotalPrice, "");
        //    listViewItemTotalPrice.SubItems.Add(_subItem1);
        //    listViewItemTotalPrice.SubItems.Add(_subItem2);
        //    listViewItemTotalPrice.SubItems.Add(_subItem3);
        //    listViewItemTotalPrice.SubItems.Add(subItemTotalPrice);
        //    listViewUseService.Items.Add(listViewItemTotalPrice);

        //    id = 1;
        //}
        public void LoaddataGridReport(string sql)
        {
            dataGridReport.DataSource = dtBase.DataReader(sql);
            dataGridReport.Columns[0].HeaderText = "Tên Loại Phòng";
            dataGridReport.Columns[1].HeaderText = "Tỷ lệ";
            dataGridReport.Columns[0].Width = 160;
            dataGridReport.Columns[2].Width = 180;
           
            BindingSource source = new BindingSource();
            source.DataSource = dtBase.DataReader(sql);
            dataGridReport.DataSource = source;
            bindingReport.BindingSource = source;
            DataTable table = dtBase.DataReader(sql);
            table.Columns.Add("Doanh Thu", typeof(string));
            source.DataSource = table;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                table.Rows[i]["Doanh Thu"] = ((int)table.Rows[i]["price"]).ToString("C0", CultureInfo.CreateSpecificCulture("vi-VN"));
            }
        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

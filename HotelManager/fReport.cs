
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HotelManager
{
    public partial class fReport : Form
    {
        private int month = 1;
        private int year = 1990;
        public fReport()
        {
            InitializeComponent();
            dataGridReport.Font = new System.Drawing.Font("Segoe UI", 9.75F);
        }


        #region Click
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
           
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

        }
        #endregion

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

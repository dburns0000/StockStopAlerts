using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace StockStopAlerts
{
    public partial class DeleteDialog : Form
    {
        private List<ViewData> list;
        private readonly string winPos = "Delete Window Position";
        private readonly string winSize = "Delete Window Size";

        public DeleteDialog()
        {
            InitializeComponent();
        }

        private void DeleteDialog_Load(object sender, EventArgs e)
        {
            Point position = Program.settings.GetPointValue(winPos);
            if (position.X != 0 || position.Y != 0)
                Location = position;
            Size size = Program.settings.GetSizeValue(winSize);
            if (size.Height != 0 && size.Width != 0)
                Size = size;
            
            if (Program.positionsTable.GetAllRecords(out list))
            {
                if (list.Count() == 0)
                {
                    MessageBox.Show("There are no records available in the database");
                    return;
                }
                foreach (ViewData data in list)
                {
                    ListViewItem lvi;
                    lvi = new ListViewItem(new string[] { data.symbol, data.buyDate.ToShortDateString(), data.buyPrice.ToString(), data.numShares.ToString() });
                    listView_delete.Items.Add(lvi);
                }
            }
        }

        private void Delete_button_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection items = listView_delete.SelectedIndices;
            foreach (int row in items)
            {
                ViewData data = list[row];
                Program.positionsTable.DeleteRecord(data.id);
            }
            Close();
        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DeleteDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.settings.SetPointValue(winPos, this.Location);
            if (this.WindowState == FormWindowState.Normal)
            {
                Program.settings.SetSizeValue(winSize, this.Size);
            }
            else
            {
                Program.settings.SetSizeValue(winSize, this.RestoreBounds.Size);
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace StockStopAlerts
{
    public partial class ViewDialog : Form
    {
        private List<ViewData> positionsList = new List<ViewData>();
        private int sortColumn = -1;
        private const string winPos = "View Window Position";
        private const string winSize = "View Window Size";

        public ViewDialog()
        {
            InitializeComponent();
        }

        private void RefreshView()
        {
            positionsList.Clear();
            listView.Items.Clear();
            listView.FullRowSelect = true;
            if (Program.positionsTable.GetAllRecords(out positionsList))
            {
                if (positionsList.Count() == 0)
                {
                    MessageBox.Show("There are no records available in the database");
                    return;
                }

                decimal totalValue = 0;
                int index = 1;
                foreach (ViewData data in positionsList)
                {
                    decimal currentValue = data.lastClose * (decimal)data.numShares;
                    decimal purchaseValue = data.buyPrice * (decimal)data.sharesBought;
                    decimal gain = currentValue / (purchaseValue == 0 ? 1 : purchaseValue);
                    ListViewItem lvi;
                    lvi = new ListViewItem(new string[]
                        { data.symbol, data.numShares.ToString(), data.lastClose.ToString("C2"), currentValue.ToString("C2"), data.buyDate.ToShortDateString(),
                          gain.ToString("F2"), data.buyPrice.ToString("C2"), data.highestClose.ToString("C2"),
                          data.dividends.ToString("C2"), data.options.ToString("C2"), data.id.ToString()
                        });
                    if (gain > 1)
                        lvi.ForeColor = Color.Green;
                    else if (gain < 1)
                        lvi.ForeColor = Color.Red;
                    listView.Items.Add(lvi);
                    totalValue += (decimal)data.numShares * data.lastClose;
                    index++;
                }

                currentValue_textBox.Text = totalValue.ToString("C2");
            }
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void ViewDialog_Load(object sender, EventArgs e)
        {
            Point position = Program.settings.GetPointValue(winPos);
            if (position.X > 0 || position.Y > 0)
                Location = position;
            Size size = Program.settings.GetSizeValue(winSize);
            if (size.Height > 0 && size.Width > 0)
                Size = size;
            RefreshView();
        }

        private void AddPosition_button_Click(object sender, EventArgs e)
        {
            EditDialog dlg = new EditDialog();
            dlg.ShowDialog(this);
            RefreshView();
        }

        private void EditPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = listView.SelectedItems;
            if (selectedItems.Count != 1)
            {
                MessageBox.Show("Select a single row to edit a position", "Edit Position");
                return;
            }
            ListViewItem lvi = selectedItems[0];
            // Get database ID of selected item from last column
            string itemindexString = (string)lvi.SubItems[lvi.SubItems.Count - 1].Text;
            int itemindex = Convert.ToInt32(itemindexString);
            // Match ID with its index in the positionsList
            foreach (ViewData data in positionsList)
            {
                if (data.id == itemindex)
                {
                    EditDialog dlg = new EditDialog(data);
                    dlg.ShowDialog(this);
                    RefreshView();
                    break;
                }
            }
        }

        private void DeletePositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool anyDeleted = false;
            ListView.SelectedListViewItemCollection selectedItems = listView.SelectedItems;
            foreach (ListViewItem lvi in selectedItems)
            {
                // Get database ID of selected item from last column
                string itemindexString = (string)lvi.SubItems[lvi.SubItems.Count - 1].Text;
                int itemindex = Convert.ToInt32(itemindexString);
                // Match ID with its index in the positionsList
                foreach (ViewData data in positionsList)
                {
                    if (data.id == itemindex)
                    {
                        DialogResult result = MessageBox.Show("Are you sure you want to delete position '" + data.symbol + "'?", "Delete Position", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            Program.positionsTable
                                .DeleteRecord(data.id);
                            anyDeleted = true;
                            break;  // out of positionsList loop
                        }
                    }
                }
            }
            if (anyDeleted)
            {
                RefreshView();
            }

        }

        private void YahooFinanceForPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = listView.SelectedItems;
            if (selectedItems.Count != 1)
            {
                MessageBox.Show("Select a single row to edit a position", "Edit Position");
                return;
            }
            ListViewItem lvi = selectedItems[0];
            // Get database ID of selected item from last column
            string itemindexString = (string)lvi.SubItems[lvi.SubItems.Count-1].Text;
            int itemindex = Convert.ToInt32(itemindexString);
            // Match ID with its index in the positionsList
            foreach (ViewData data in positionsList)
            {
                if (data.id == itemindex)
                {
                    string yahooUrl = "http://finance.yahoo.com/q?s=" + data.symbol;
                    System.Diagnostics.Process.Start(yahooUrl);
                }
            }
        }

        private void ViewDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                Program.settings.SetPointValue(winPos, this.Location);
                Program.settings.SetSizeValue(winSize, this.Size);
            }
        }

        private void ListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine whether the column is the same as the last column clicked.
            if (e.Column != sortColumn)
            {
                // Set the sort column to the new column.
                sortColumn = e.Column;
                // Set the sort order to ascending by default.
                listView.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Determine what the last sort order was and change it.
                if (listView.Sorting == SortOrder.Ascending)
                    listView.Sorting = SortOrder.Descending;
                else
                    listView.Sorting = SortOrder.Ascending;
            }

            // Call the sort method to manually sort.
            listView.Sort();
            // Set the ListViewItemSorter property to a new ListViewItemComparer object.
            this.listView.ListViewItemSorter = new ListViewItemComparer(e.Column, listView.Sorting);
        }
    }

    class ListViewItemComparer : IComparer
    {
        private readonly int _column;
        private readonly SortOrder _order;
        
        public ListViewItemComparer()
        {
            _column = 0;
            _order = SortOrder.Ascending;
        }
        
        public ListViewItemComparer(int column, SortOrder order)
        {
            _column = column;
            _order = order;
        }
        
        public int Compare(object x, object y) 
        {
            int returnVal;
            string first = ((ListViewItem)x).SubItems[_column].Text;
            string second = ((ListViewItem)y).SubItems[_column].Text;

            // Determine whether the type being compared is a date type.
            try
            {
                // Parse the two objects passed as a parameter as a DateTime.
                System.DateTime firstDate = DateTime.Parse(first);
                System.DateTime secondDate = DateTime.Parse(second);
                // Compare the two dates.
                returnVal = DateTime.Compare(firstDate, secondDate);
            }
            // If neither compared object has a valid date format, compare as a number or a string.
            catch
            {
                // Check if it is a dollar amount
                if (!string.IsNullOrEmpty(first) && !string.IsNullOrEmpty(second) && first[0] == '$' && second[0] == '$')
                {
                    first = first.Substring(1);
                    second = second.Substring(1);
                    decimal firstNumber = decimal.Parse(first);
                    decimal secondNumber = decimal.Parse(second);
                    returnVal = decimal.Compare(firstNumber, secondNumber);
                }
                else 
                {
                    // Try as a decimal value
                    if (decimal.TryParse(first, out decimal firstNumber) && decimal.TryParse(second, out decimal secondNumber))
                    {
                        returnVal = decimal.Compare(firstNumber, secondNumber);
                    }
                    else
                    {
                        // Compare the two items as a string.
                        returnVal = string.Compare(first, second);
                    }
                }
            }

            // Determine whether the sort order is descending.
            if (_order == SortOrder.Descending)
            // Invert the value returned by String.Compare.
                returnVal *= -1;
            return returnVal;
        }
    }
}

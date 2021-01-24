using System;
using System.Windows.Forms;
using System.IO;

namespace StockStopAlerts
{
    public partial class SettingsDialog : Form
    {
        public string DatabaseLocation { get; set; }
        public bool CreateNew { get; set; }

        public SettingsDialog(string dbLocation)
        {
            InitializeComponent();
            DatabaseLocation = dbLocation;
            textBox_dbLocation.Text = dbLocation;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox_dbLocation.Text))
            {
                DatabaseLocation = textBox_dbLocation.Text;
            }
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e) => Close();

        private void SelectButton_Click(object sender, EventArgs e)
        {
            string initialFolder = Path.GetDirectoryName(DatabaseLocation);
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Select a Sqlite database file";
                if (Directory.Exists(initialFolder))
                    dlg.InitialDirectory = initialFolder;
                dlg.Filter = "Sqlite Database Files|*.db";
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    textBox_dbLocation.Text = dlg.FileName;
                }
            }
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            string initialFolder = Path.GetDirectoryName(DatabaseLocation);
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Title = "Select a Sqlite database file";
                if (Directory.Exists(initialFolder))
                    dlg.InitialDirectory = initialFolder;
                dlg.Filter = "Sqlite Database Files|*.db";
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    DatabaseLocation = dlg.FileName;
                    CreateNew = true;
                }
            }
        }

    }
}

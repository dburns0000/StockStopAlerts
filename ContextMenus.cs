using System;
using System.Windows.Forms;
using StockStopAlerts.Properties;
using System.IO;

namespace StockStopAlerts
{
    /// <summary>
    /// 
    /// </summary>
    class ContextMenus
	{
		/// <summary>
		/// Is the About box displayed?
		/// </summary>
		bool isAboutLoaded = false;

		/// <summary>
		/// Creates this instance.
		/// </summary>
		/// <returns>ContextMenuStrip</returns>
		public ContextMenuStrip Create(bool newDatabase)
		{
			// Add the default menu options.
			ContextMenuStrip menu = new ContextMenuStrip();
			ToolStripMenuItem item;
			ToolStripSeparator sep;

            // Settings
            item = new ToolStripMenuItem();
            item.Text = "&Settings";
            item.Click += new EventHandler(Settings_Click);
            item.Image = Resources.settings;
            menu.Items.Add(item);

            // Add
			item = new ToolStripMenuItem();
			item.Text = "&Add symbol";
			item.Click += new EventHandler(Add_Click);
			item.Image = Resources.plus;
			menu.Items.Add(item);

            // Delete
            item = new ToolStripMenuItem();
            item.Text = "&Delete symbol(s)";
            item.Click += new EventHandler(Delete_Click);
            item.Image = Resources.minus;
            menu.Items.Add(item);

            // View
            item = new ToolStripMenuItem();
            item.Text = "&View all symbols";
            item.Click += new EventHandler(View_Click);
            item.Image = Resources.eye;
            menu.Items.Add(item);

            // Separator.
            sep = new ToolStripSeparator();
            menu.Items.Add(sep);

            // About.
			item = new ToolStripMenuItem();
			item.Text = "About";
			item.Click += new EventHandler(About_Click);
			item.Image = Resources.About;
			menu.Items.Add(item);

            // Exit.
			item = new ToolStripMenuItem();
			item.Text = "Exit";
			item.Click += new System.EventHandler(Exit_Click);
			item.Image = Resources.Exit;
			menu.Items.Add(item);

            if (newDatabase)
            {
                EditDialog dlg = new EditDialog();
                dlg.ShowDialog();
            }

			return menu;
		}

        /// <summary>
        /// Handles the Click event of the Settings control.
        /// </summary>
        void Settings_Click(object sender, EventArgs e)
        {
            string dbfile = Program.settings.GetStringValue("Database Filename");
            string username = Program.settings.GetProtected("Username");
            string password = Program.settings.GetProtected("Password");
            if (string.IsNullOrEmpty(dbfile))
            {
                dbfile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "StockStopAlerts.db";
            }

            SettingsDialog dlg = new SettingsDialog(dbfile);
            DialogResult rtn = dlg.ShowDialog();
            if (rtn == DialogResult.OK)
            {
                if (!String.IsNullOrEmpty(dlg.DatabaseLocation))
                {
                    Program.settings.SetStringValue("Database Filename", dlg.DatabaseLocation);
                    Program.positionsTable.SetDatabaseLocation(dlg.DatabaseLocation);
                    if (dlg.CreateNew || !File.Exists(dlg.DatabaseLocation))
                    {
                        Program.positionsTable.CreateDatabase();
                    }
                }
            }
        }

        /// <summary>
		/// Handles the Click event of the Add control.
		/// </summary>
		void Add_Click(object sender, EventArgs e)
		{
            EditDialog dlg = new EditDialog();
            dlg.ShowDialog();
        }

        /// <summary>
        /// Handles the Click event of the Add control.
        /// </summary>
        void Delete_Click(object sender, EventArgs e)
        {
            DeleteDialog dlg = new DeleteDialog();
            dlg.ShowDialog();
        }

        /// <summary>
        /// Handles the Click event of the View control.
        /// </summary>
        void View_Click(object sender, EventArgs e)
        {
            ViewDialog dlg = new ViewDialog();
            dlg.ShowDialog();
        }

        /// <summary>
		/// Handles the Click event of the About control.
		/// </summary>
		void About_Click(object sender, EventArgs e)
		{
			if (!isAboutLoaded)
			{
				isAboutLoaded = true;
				new AboutBox().ShowDialog();
				isAboutLoaded = false;
			}
		}

        /// <summary>
        /// Handles the Click event of the Exit control.
		/// </summary>
		void Exit_Click(object sender, EventArgs e)
		{
			// Quit without further ado.
			Application.Exit();
		}
	}
}
namespace StockStopAlerts
{
    partial class ViewDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader_Symbol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Shares = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Last = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_buyDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Gain = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_buyPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Highest = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Dividends = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Options = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.view_contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deletePositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yahooFinanceForPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPosition_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.currentValue_textBox = new System.Windows.Forms.TextBox();
            this.view_contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_Symbol,
            this.columnHeader_Shares,
            this.columnHeader_Last,
            this.columnHeader_Value,
            this.columnHeader_buyDate,
            this.columnHeader_Gain,
            this.columnHeader_buyPrice,
            this.columnHeader_Highest,
            this.columnHeader_Dividends,
            this.columnHeader_Options,
            this.columnHeader_ID});
            this.listView.ContextMenuStrip = this.view_contextMenu;
            this.listView.Location = new System.Drawing.Point(13, 13);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(635, 364);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListView_ColumnClick);
            // 
            // columnHeader_Symbol
            // 
            this.columnHeader_Symbol.Text = "Symbol";
            // 
            // columnHeader_Shares
            // 
            this.columnHeader_Shares.Text = "Shares";
            // 
            // columnHeader_Last
            // 
            this.columnHeader_Last.Text = "Last $";
            // 
            // columnHeader_Value
            // 
            this.columnHeader_Value.Text = "Value $";
            this.columnHeader_Value.Width = 70;
            // 
            // columnHeader_buyDate
            // 
            this.columnHeader_buyDate.Text = "Buy Date";
            this.columnHeader_buyDate.Width = 80;
            // 
            // columnHeader_Gain
            // 
            this.columnHeader_Gain.Text = "Gain";
            // 
            // columnHeader_buyPrice
            // 
            this.columnHeader_buyPrice.Text = "Buy $";
            // 
            // columnHeader_Highest
            // 
            this.columnHeader_Highest.Text = "High $";
            // 
            // columnHeader_Dividends
            // 
            this.columnHeader_Dividends.Text = "Dividends";
            // 
            // columnHeader_Options
            // 
            this.columnHeader_Options.Text = "Options";
            // 
            // columnHeader_ID
            // 
            this.columnHeader_ID.Text = "ID";
            this.columnHeader_ID.Width = 3;
            // 
            // view_contextMenu
            // 
            this.view_contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editPositionToolStripMenuItem,
            this.deletePositionToolStripMenuItem,
            this.yahooFinanceForPositionToolStripMenuItem});
            this.view_contextMenu.Name = "view_contextMenu";
            this.view_contextMenu.Size = new System.Drawing.Size(217, 70);
            // 
            // editPositionToolStripMenuItem
            // 
            this.editPositionToolStripMenuItem.Name = "editPositionToolStripMenuItem";
            this.editPositionToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.editPositionToolStripMenuItem.Text = "&Edit Position";
            this.editPositionToolStripMenuItem.Click += new System.EventHandler(this.EditPositionToolStripMenuItem_Click);
            // 
            // deletePositionToolStripMenuItem
            // 
            this.deletePositionToolStripMenuItem.Name = "deletePositionToolStripMenuItem";
            this.deletePositionToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.deletePositionToolStripMenuItem.Text = "&Delete Position";
            this.deletePositionToolStripMenuItem.Click += new System.EventHandler(this.DeletePositionToolStripMenuItem_Click);
            // 
            // yahooFinanceForPositionToolStripMenuItem
            // 
            this.yahooFinanceForPositionToolStripMenuItem.Name = "yahooFinanceForPositionToolStripMenuItem";
            this.yahooFinanceForPositionToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.yahooFinanceForPositionToolStripMenuItem.Text = "&Yahoo Finance for Position";
            this.yahooFinanceForPositionToolStripMenuItem.Click += new System.EventHandler(this.YahooFinanceForPositionToolStripMenuItem_Click);
            // 
            // addPosition_button
            // 
            this.addPosition_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addPosition_button.Location = new System.Drawing.Point(215, 385);
            this.addPosition_button.Name = "addPosition_button";
            this.addPosition_button.Size = new System.Drawing.Size(75, 23);
            this.addPosition_button.TabIndex = 2;
            this.addPosition_button.Text = "Add Position";
            this.addPosition_button.UseVisualStyleBackColor = true;
            this.addPosition_button.Click += new System.EventHandler(this.AddPosition_button_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 385);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Right-click on a row to edit or delete it.";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(312, 393);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Current value of all positions:";
            // 
            // currentValue_textBox
            // 
            this.currentValue_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.currentValue_textBox.Location = new System.Drawing.Point(457, 390);
            this.currentValue_textBox.Name = "currentValue_textBox";
            this.currentValue_textBox.ReadOnly = true;
            this.currentValue_textBox.Size = new System.Drawing.Size(88, 20);
            this.currentValue_textBox.TabIndex = 5;
            // 
            // ViewDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 418);
            this.Controls.Add(this.currentValue_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addPosition_button);
            this.Controls.Add(this.listView);
            this.Name = "ViewDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Current Positions";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewDialog_FormClosing);
            this.Load += new System.EventHandler(this.ViewDialog_Load);
            this.view_contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeader_Symbol;
        private System.Windows.Forms.ColumnHeader columnHeader_buyDate;
        private System.Windows.Forms.ColumnHeader columnHeader_buyPrice;
        private System.Windows.Forms.ColumnHeader columnHeader_Shares;
        private System.Windows.Forms.ColumnHeader columnHeader_Highest;
        private System.Windows.Forms.ColumnHeader columnHeader_Dividends;
        private System.Windows.Forms.ColumnHeader columnHeader_Options;
        private System.Windows.Forms.Button addPosition_button;
        private System.Windows.Forms.ContextMenuStrip view_contextMenu;
        private System.Windows.Forms.ToolStripMenuItem editPositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deletePositionToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader_Last;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox currentValue_textBox;
        private System.Windows.Forms.ColumnHeader columnHeader_Gain;
        private System.Windows.Forms.ColumnHeader columnHeader_ID;
        private System.Windows.Forms.ToolStripMenuItem yahooFinanceForPositionToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader_Value;
    }
}
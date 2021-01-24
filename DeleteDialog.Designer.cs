namespace StockStopAlerts
{
    partial class DeleteDialog
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
            this.delete_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.listView_delete = new System.Windows.Forms.ListView();
            this.columnHeader_symbol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_buyDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_buyPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_numShares = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // delete_button
            // 
            this.delete_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.delete_button.Location = new System.Drawing.Point(60, 243);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(144, 23);
            this.delete_button.TabIndex = 1;
            this.delete_button.Text = "Delete Selected Rows";
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.Delete_button_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel_button.Location = new System.Drawing.Point(230, 243);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(75, 23);
            this.cancel_button.TabIndex = 2;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.Cancel_button_Click);
            // 
            // listView_delete
            // 
            this.listView_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_delete.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_symbol,
            this.columnHeader_buyDate,
            this.columnHeader_buyPrice,
            this.columnHeader_numShares});
            this.listView_delete.Location = new System.Drawing.Point(13, 13);
            this.listView_delete.Name = "listView_delete";
            this.listView_delete.Size = new System.Drawing.Size(339, 211);
            this.listView_delete.TabIndex = 3;
            this.listView_delete.UseCompatibleStateImageBehavior = false;
            this.listView_delete.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader_symbol
            // 
            this.columnHeader_symbol.Text = "Symbol";
            // 
            // columnHeader_buyDate
            // 
            this.columnHeader_buyDate.Text = "Buy Date";
            this.columnHeader_buyDate.Width = 120;
            // 
            // columnHeader_buyPrice
            // 
            this.columnHeader_buyPrice.Text = "Buy Price";
            this.columnHeader_buyPrice.Width = 80;
            // 
            // columnHeader_numShares
            // 
            this.columnHeader_numShares.Text = "# Shares";
            // 
            // DeleteDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 281);
            this.Controls.Add(this.listView_delete);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.delete_button);
            this.MinimizeBox = false;
            this.Name = "DeleteDialog";
            this.Text = "Delete Symbols";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeleteDialog_FormClosing);
            this.Load += new System.EventHandler(this.DeleteDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.ListView listView_delete;
        private System.Windows.Forms.ColumnHeader columnHeader_symbol;
        private System.Windows.Forms.ColumnHeader columnHeader_buyDate;
        private System.Windows.Forms.ColumnHeader columnHeader_buyPrice;
        private System.Windows.Forms.ColumnHeader columnHeader_numShares;
    }
}
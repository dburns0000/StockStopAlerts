namespace SystemTrayApp
{
    partial class AddDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.symbol_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.stopLossPercentage_textBox = new System.Windows.Forms.TextBox();
            this.useTrailingStop_checkBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buy_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.shares_textBox = new System.Windows.Forms.TextBox();
            this.useDividends_checkBox = new System.Windows.Forms.CheckBox();
            this.useOptionSales_checkBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buyPrice_textBox = new System.Windows.Forms.TextBox();
            this.fixedPrice_radioButton = new System.Windows.Forms.RadioButton();
            this.percentage_radioButton = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.fixedStopPrice_textBox = new System.Windows.Forms.TextBox();
            this.ok_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Symbol:";
            // 
            // symbol_textBox
            // 
            this.symbol_textBox.Location = new System.Drawing.Point(67, 10);
            this.symbol_textBox.Name = "symbol_textBox";
            this.symbol_textBox.Size = new System.Drawing.Size(56, 20);
            this.symbol_textBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Stop loss percentage:";
            // 
            // stopLossPercentage_textBox
            // 
            this.stopLossPercentage_textBox.Location = new System.Drawing.Point(130, 190);
            this.stopLossPercentage_textBox.Name = "stopLossPercentage_textBox";
            this.stopLossPercentage_textBox.Size = new System.Drawing.Size(49, 20);
            this.stopLossPercentage_textBox.TabIndex = 8;
            // 
            // useTrailingStop_checkBox
            // 
            this.useTrailingStop_checkBox.AutoSize = true;
            this.useTrailingStop_checkBox.Location = new System.Drawing.Point(201, 192);
            this.useTrailingStop_checkBox.Name = "useTrailingStop_checkBox";
            this.useTrailingStop_checkBox.Size = new System.Drawing.Size(101, 17);
            this.useTrailingStop_checkBox.TabIndex = 9;
            this.useTrailingStop_checkBox.Text = "Use trailing stop";
            this.useTrailingStop_checkBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Buy date:";
            // 
            // buy_dateTimePicker
            // 
            this.buy_dateTimePicker.Location = new System.Drawing.Point(74, 47);
            this.buy_dateTimePicker.Name = "buy_dateTimePicker";
            this.buy_dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.buy_dateTimePicker.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(150, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Number of shares:";
            // 
            // shares_textBox
            // 
            this.shares_textBox.Location = new System.Drawing.Point(250, 10);
            this.shares_textBox.Name = "shares_textBox";
            this.shares_textBox.Size = new System.Drawing.Size(57, 20);
            this.shares_textBox.TabIndex = 2;
            // 
            // useDividends_checkBox
            // 
            this.useDividends_checkBox.AutoSize = true;
            this.useDividends_checkBox.Location = new System.Drawing.Point(13, 227);
            this.useDividends_checkBox.Name = "useDividends_checkBox";
            this.useDividends_checkBox.Size = new System.Drawing.Size(299, 17);
            this.useDividends_checkBox.TabIndex = 10;
            this.useDividends_checkBox.Text = "Use dividends (subtract from stock price to calculate stop)";
            this.useDividends_checkBox.UseVisualStyleBackColor = true;
            // 
            // useOptionSales_checkBox
            // 
            this.useOptionSales_checkBox.AutoSize = true;
            this.useOptionSales_checkBox.Location = new System.Drawing.Point(13, 259);
            this.useOptionSales_checkBox.Name = "useOptionSales_checkBox";
            this.useOptionSales_checkBox.Size = new System.Drawing.Size(384, 17);
            this.useOptionSales_checkBox.TabIndex = 11;
            this.useOptionSales_checkBox.Text = "Use option sales (subtract per share sales from stock price to calculate stop)";
            this.useOptionSales_checkBox.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Buy price (per share)";
            // 
            // buyPrice_textBox
            // 
            this.buyPrice_textBox.Location = new System.Drawing.Point(130, 83);
            this.buyPrice_textBox.Name = "buyPrice_textBox";
            this.buyPrice_textBox.Size = new System.Drawing.Size(66, 20);
            this.buyPrice_textBox.TabIndex = 4;
            // 
            // fixedPrice_radioButton
            // 
            this.fixedPrice_radioButton.AutoSize = true;
            this.fixedPrice_radioButton.Location = new System.Drawing.Point(76, 126);
            this.fixedPrice_radioButton.Name = "fixedPrice_radioButton";
            this.fixedPrice_radioButton.Size = new System.Drawing.Size(76, 17);
            this.fixedPrice_radioButton.TabIndex = 5;
            this.fixedPrice_radioButton.TabStop = true;
            this.fixedPrice_radioButton.Text = "Fixed price";
            this.fixedPrice_radioButton.UseVisualStyleBackColor = true;
            this.fixedPrice_radioButton.CheckedChanged += new System.EventHandler(this.fixedPrice_radioButton_CheckedChanged);
            // 
            // percentage_radioButton
            // 
            this.percentage_radioButton.AutoSize = true;
            this.percentage_radioButton.Location = new System.Drawing.Point(166, 126);
            this.percentage_radioButton.Name = "percentage_radioButton";
            this.percentage_radioButton.Size = new System.Drawing.Size(80, 17);
            this.percentage_radioButton.TabIndex = 6;
            this.percentage_radioButton.TabStop = true;
            this.percentage_radioButton.Text = "Percentage";
            this.percentage_radioButton.UseVisualStyleBackColor = true;
            this.percentage_radioButton.CheckedChanged += new System.EventHandler(this.percentage_radioButton_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Stop type:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Fixed stop price:";
            // 
            // fixedStopPrice_textBox
            // 
            this.fixedStopPrice_textBox.Location = new System.Drawing.Point(102, 156);
            this.fixedStopPrice_textBox.Name = "fixedStopPrice_textBox";
            this.fixedStopPrice_textBox.Size = new System.Drawing.Size(61, 20);
            this.fixedStopPrice_textBox.TabIndex = 7;
            // 
            // ok_button
            // 
            this.ok_button.Location = new System.Drawing.Point(114, 292);
            this.ok_button.Name = "ok_button";
            this.ok_button.Size = new System.Drawing.Size(75, 23);
            this.ok_button.TabIndex = 12;
            this.ok_button.Text = "OK";
            this.ok_button.UseVisualStyleBackColor = true;
            this.ok_button.Click += new System.EventHandler(this.ok_button_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.Location = new System.Drawing.Point(226, 292);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(75, 23);
            this.cancel_button.TabIndex = 13;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // AddDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 332);
            this.ControlBox = false;
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.ok_button);
            this.Controls.Add(this.fixedStopPrice_textBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.percentage_radioButton);
            this.Controls.Add(this.fixedPrice_radioButton);
            this.Controls.Add(this.buyPrice_textBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.useOptionSales_checkBox);
            this.Controls.Add(this.useDividends_checkBox);
            this.Controls.Add(this.shares_textBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buy_dateTimePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.useTrailingStop_checkBox);
            this.Controls.Add(this.stopLossPercentage_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.symbol_textBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Add Symbol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox symbol_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox stopLossPercentage_textBox;
        private System.Windows.Forms.CheckBox useTrailingStop_checkBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker buy_dateTimePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox shares_textBox;
        private System.Windows.Forms.CheckBox useDividends_checkBox;
        private System.Windows.Forms.CheckBox useOptionSales_checkBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox buyPrice_textBox;
        private System.Windows.Forms.RadioButton fixedPrice_radioButton;
        private System.Windows.Forms.RadioButton percentage_radioButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox fixedStopPrice_textBox;
        private System.Windows.Forms.Button ok_button;
        private System.Windows.Forms.Button cancel_button;
    }
}
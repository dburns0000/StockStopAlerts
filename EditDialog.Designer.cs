namespace StockStopAlerts
{
    partial class EditDialog
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
            this.sharesBought_textBox = new System.Windows.Forms.TextBox();
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
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dividends_textBox = new System.Windows.Forms.TextBox();
            this.options_textBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.currentShares_textBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.currentStopPrice_textBox = new System.Windows.Forms.TextBox();
            this.addDiv_button = new System.Windows.Forms.Button();
            this.addDiv_textBox = new System.Windows.Forms.TextBox();
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
            this.label2.Location = new System.Drawing.Point(13, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Stop loss percentage:";
            // 
            // stopLossPercentage_textBox
            // 
            this.stopLossPercentage_textBox.Location = new System.Drawing.Point(130, 222);
            this.stopLossPercentage_textBox.Name = "stopLossPercentage_textBox";
            this.stopLossPercentage_textBox.Size = new System.Drawing.Size(49, 20);
            this.stopLossPercentage_textBox.TabIndex = 9;
            // 
            // useTrailingStop_checkBox
            // 
            this.useTrailingStop_checkBox.AutoSize = true;
            this.useTrailingStop_checkBox.Location = new System.Drawing.Point(201, 225);
            this.useTrailingStop_checkBox.Name = "useTrailingStop_checkBox";
            this.useTrailingStop_checkBox.Size = new System.Drawing.Size(101, 17);
            this.useTrailingStop_checkBox.TabIndex = 10;
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
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "# Shares bought:";
            // 
            // sharesBought_textBox
            // 
            this.sharesBought_textBox.Location = new System.Drawing.Point(246, 10);
            this.sharesBought_textBox.Name = "sharesBought_textBox";
            this.sharesBought_textBox.Size = new System.Drawing.Size(57, 20);
            this.sharesBought_textBox.TabIndex = 2;
            // 
            // useDividends_checkBox
            // 
            this.useDividends_checkBox.AutoSize = true;
            this.useDividends_checkBox.Location = new System.Drawing.Point(13, 257);
            this.useDividends_checkBox.Name = "useDividends_checkBox";
            this.useDividends_checkBox.Size = new System.Drawing.Size(299, 17);
            this.useDividends_checkBox.TabIndex = 11;
            this.useDividends_checkBox.Text = "Use dividends (subtract from stock price to calculate stop)";
            this.useDividends_checkBox.UseVisualStyleBackColor = true;
            // 
            // useOptionSales_checkBox
            // 
            this.useOptionSales_checkBox.AutoSize = true;
            this.useOptionSales_checkBox.Location = new System.Drawing.Point(13, 309);
            this.useOptionSales_checkBox.Name = "useOptionSales_checkBox";
            this.useOptionSales_checkBox.Size = new System.Drawing.Size(384, 17);
            this.useOptionSales_checkBox.TabIndex = 12;
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
            this.fixedPrice_radioButton.Location = new System.Drawing.Point(76, 156);
            this.fixedPrice_radioButton.Name = "fixedPrice_radioButton";
            this.fixedPrice_radioButton.Size = new System.Drawing.Size(76, 17);
            this.fixedPrice_radioButton.TabIndex = 6;
            this.fixedPrice_radioButton.TabStop = true;
            this.fixedPrice_radioButton.Text = "Fixed price";
            this.fixedPrice_radioButton.UseVisualStyleBackColor = true;
            this.fixedPrice_radioButton.CheckedChanged += new System.EventHandler(this.FixedPrice_radioButton_CheckedChanged);
            // 
            // percentage_radioButton
            // 
            this.percentage_radioButton.AutoSize = true;
            this.percentage_radioButton.Location = new System.Drawing.Point(166, 156);
            this.percentage_radioButton.Name = "percentage_radioButton";
            this.percentage_radioButton.Size = new System.Drawing.Size(80, 17);
            this.percentage_radioButton.TabIndex = 7;
            this.percentage_radioButton.TabStop = true;
            this.percentage_radioButton.Text = "Percentage";
            this.percentage_radioButton.UseVisualStyleBackColor = true;
            this.percentage_radioButton.CheckedChanged += new System.EventHandler(this.Percentage_radioButton_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Stop type:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Fixed stop price:";
            // 
            // fixedStopPrice_textBox
            // 
            this.fixedStopPrice_textBox.Location = new System.Drawing.Point(102, 189);
            this.fixedStopPrice_textBox.Name = "fixedStopPrice_textBox";
            this.fixedStopPrice_textBox.Size = new System.Drawing.Size(61, 20);
            this.fixedStopPrice_textBox.TabIndex = 8;
            // 
            // ok_button
            // 
            this.ok_button.Location = new System.Drawing.Point(114, 406);
            this.ok_button.Name = "ok_button";
            this.ok_button.Size = new System.Drawing.Size(75, 23);
            this.ok_button.TabIndex = 14;
            this.ok_button.Text = "OK";
            this.ok_button.UseVisualStyleBackColor = true;
            this.ok_button.Click += new System.EventHandler(this.Ok_button_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.Location = new System.Drawing.Point(226, 406);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(75, 23);
            this.cancel_button.TabIndex = 15;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.Cancel_button_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 286);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Dividends:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 338);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Option Sales:";
            // 
            // dividends_textBox
            // 
            this.dividends_textBox.Location = new System.Drawing.Point(90, 283);
            this.dividends_textBox.Name = "dividends_textBox";
            this.dividends_textBox.Size = new System.Drawing.Size(62, 20);
            this.dividends_textBox.TabIndex = 18;
            // 
            // options_textBox
            // 
            this.options_textBox.Location = new System.Drawing.Point(90, 335);
            this.options_textBox.Name = "options_textBox";
            this.options_textBox.Size = new System.Drawing.Size(62, 20);
            this.options_textBox.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Current # of shares:";
            // 
            // currentShares_textBox
            // 
            this.currentShares_textBox.Location = new System.Drawing.Point(120, 121);
            this.currentShares_textBox.Name = "currentShares_textBox";
            this.currentShares_textBox.Size = new System.Drawing.Size(57, 20);
            this.currentShares_textBox.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Enabled = false;
            this.label11.Location = new System.Drawing.Point(16, 372);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Current stop price:";
            // 
            // currentStopPrice_textBox
            // 
            this.currentStopPrice_textBox.Location = new System.Drawing.Point(114, 369);
            this.currentStopPrice_textBox.Name = "currentStopPrice_textBox";
            this.currentStopPrice_textBox.ReadOnly = true;
            this.currentStopPrice_textBox.Size = new System.Drawing.Size(61, 20);
            this.currentStopPrice_textBox.TabIndex = 7;
            // 
            // addDiv_button
            // 
            this.addDiv_button.Location = new System.Drawing.Point(201, 282);
            this.addDiv_button.Name = "addDiv_button";
            this.addDiv_button.Size = new System.Drawing.Size(63, 23);
            this.addDiv_button.TabIndex = 21;
            this.addDiv_button.Text = "Add Div.";
            this.addDiv_button.UseVisualStyleBackColor = true;
            this.addDiv_button.Click += new System.EventHandler(this.AddDiv_button_Click);
            // 
            // addDiv_textBox
            // 
            this.addDiv_textBox.Location = new System.Drawing.Point(270, 283);
            this.addDiv_textBox.Name = "addDiv_textBox";
            this.addDiv_textBox.Size = new System.Drawing.Size(46, 20);
            this.addDiv_textBox.TabIndex = 22;
            // 
            // EditDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 441);
            this.ControlBox = false;
            this.Controls.Add(this.addDiv_textBox);
            this.Controls.Add(this.addDiv_button);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.options_textBox);
            this.Controls.Add(this.dividends_textBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.ok_button);
            this.Controls.Add(this.currentStopPrice_textBox);
            this.Controls.Add(this.fixedStopPrice_textBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.percentage_radioButton);
            this.Controls.Add(this.fixedPrice_radioButton);
            this.Controls.Add(this.buyPrice_textBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.useOptionSales_checkBox);
            this.Controls.Add(this.useDividends_checkBox);
            this.Controls.Add(this.currentShares_textBox);
            this.Controls.Add(this.sharesBought_textBox);
            this.Controls.Add(this.label10);
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
            this.Name = "EditDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Add / Edit Symbol";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditDialog_FormClosing);
            this.Load += new System.EventHandler(this.EditDialog_Load);
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
        private System.Windows.Forms.TextBox sharesBought_textBox;
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox dividends_textBox;
        private System.Windows.Forms.TextBox options_textBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox currentShares_textBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox currentStopPrice_textBox;
        private System.Windows.Forms.Button addDiv_button;
        private System.Windows.Forms.TextBox addDiv_textBox;
    }
}
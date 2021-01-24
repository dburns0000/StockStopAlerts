using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SystemTrayApp
{
    public partial class AddDialog : Form
    {
        public AddDialog()
        {
            InitializeComponent();
            fixedPrice_radioButton.Checked = true;
            fixedPrice_radioButton_CheckedChanged(null, null);
        }

        private void ok_button_Click(object sender, EventArgs e)
        {
            int numShares = 0;
            int stopPercentage = 0;
            decimal buyPrice = 0;
            decimal fixedStopPrice = 0;
            bool useTrailingStop = false;
            bool useDividends = false;
            bool useOptions = false;
            
            try
            {
                numShares = int.Parse(shares_textBox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Number of shares is not a valid number");
                return;
            }

            try
            {
                buyPrice = decimal.Parse(buyPrice_textBox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Buy price is not a valid number");
                return;
            }

            if (fixedPrice_radioButton.Checked)
            {
                try
                {
                    fixedStopPrice = decimal.Parse(fixedStopPrice_textBox.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Fixed stop price is not a valid number");
                    return;
                }

            }
            else
            {
                try
                {
                    stopPercentage = int.Parse(stopLossPercentage_textBox.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Stop loss percentage is not a valid number");
                    return;
                }
                useTrailingStop = useTrailingStop_checkBox.Checked;
                useDividends = useDividends_checkBox.Checked;
                useOptions = useOptionSales_checkBox.Checked;
            }


            // Add position to the database
            PositionsTable.AddRecord(
                symbol_textBox.Text,
                stopPercentage,
                useTrailingStop,
                buy_dateTimePicker.Value,
                numShares,
                buyPrice,
                useDividends,
                useOptions,
                fixedStopPrice
                );

            Close();
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fixedPrice_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            fixedStopPrice_textBox.Enabled = true;
            stopLossPercentage_textBox.Enabled = false;
            useTrailingStop_checkBox.Enabled = false;
            useDividends_checkBox.Enabled = false;
            useOptionSales_checkBox.Enabled = false;
        }

        private void percentage_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            fixedStopPrice_textBox.Enabled = false;
            stopLossPercentage_textBox.Enabled = true;
            useTrailingStop_checkBox.Enabled = true;
            useDividends_checkBox.Enabled = true;
            useOptionSales_checkBox.Enabled = true;
        }
    }
}

using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WendyMonahanC969.Database;
using WendyMonahanC969.Classes;
using static System.Net.Mime.MediaTypeNames;

namespace WendyMonahanC969
{
    public partial class AddCustomer : Form
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            int activeCheck = 0;

            if (activityCheckBox.Checked == true)
            {
                activeCheck = 1;
            }

            Regex regex = new Regex(@"^[0-9\-]+$");

            if (addressTextBox.Text.Length > 50)
            {
                MessageBox.Show("Please keep Address1 under 50 characters.");
            }
            else if (address2TextBox.Text.Length > 50)
            {
                MessageBox.Show("Please keep Address2 under 50 characters.");
            }
            else if (postalCodeTextBox.Text.Length > 10)
            {
                MessageBox.Show("Please keep Postal Code under 10 characters.");
            }
            else if (phoneTextBox.Text.Length > 20)
            {
                MessageBox.Show("Please keep Phone Number under 20 characters.");
            }
            else if (regex.IsMatch(phoneTextBox.Text) == false)
            {
                MessageBox.Show("Please only use dashes (-) and numbers for Phone Number.");
            }
            else
            {
                if (nameTextBox.Text == "")
                {
                    MessageBox.Show("Please ensure Name is not empty");
                }
                else if (addressTextBox.Text == "")
                {
                    MessageBox.Show("Please ensure Address is not empty");
                }
                else if (address2TextBox.Text == "")
                {
                    MessageBox.Show("Please ensure Address2 is not empty");
                }
                else if (countryTextBox.Text == "")
                {
                    MessageBox.Show("Please ensure Country is not empty");
                }
                else if (cityTextBox.Text == "")
                {
                    MessageBox.Show("Please ensure City is not empty");
                }
                else if (postalCodeTextBox.Text == "")
                {
                    MessageBox.Show("Please ensure Postal Code is not empty");
                }
                else if (phoneTextBox.Text == "")
                {
                    MessageBox.Show("Please ensure Phone is not empty");
                }
                else
                {
                    DBConnection.addCustomer(nameTextBox.Text, addressTextBox.Text, address2TextBox.Text, cityTextBox.Text, countryTextBox.Text, postalCodeTextBox.Text, phoneTextBox.Text, activeCheck);
                    Close();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WendyMonahanC969.Database;
using WendyMonahanC969.Classes;

namespace WendyMonahanC969
{
    public partial class UpdateAppointment : Form
    {
        int passAppointmentID = 0;
        int passCustomerID = 0;
        string passType = "";
        public UpdateAppointment(DisplayAppointment appointmentPass, string localTimeZone)
        {
            InitializeComponent();
            passAppointmentID = appointmentPass.AppointmentID;
            passCustomerID = appointmentPass.CustomerID;
            passType = appointmentPass.Type;
            string localTimeZoneUA = localTimeZone;
            startTimeZone.Text = localTimeZoneUA;
            endTimeZone.Text = localTimeZoneUA;

            customerIDTextBox.Text = passCustomerID.ToString();
            typeTextBox.Text = passType.ToString();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void updateBtn_Click_1(object sender, EventArgs e)
        {
            bool matchID = true;
            int customerID = 0;
            string date = DBConnection.getStringDate(datePicker.Value);
            string start = "";
            string end = "";

            try
            {
                Int32.Parse(customerIDTextBox.Text);
            }
            catch
            {
                matchID = false;
            }
            
            if (matchID == true)
            {
                if (Int32.Parse(customerIDTextBox.Text) >= DBConnection.getMaxID("customerId", "customer"))
                {
                    matchID = false;
                }
            }
            

            if (customerIDTextBox.Text == "")
            {
                MessageBox.Show("Please include a Customer ID.");
            }
            else if (matchID == false)
            {
                MessageBox.Show("Customer ID must be an existing customer's ID");
            }
            else if (titleTextBox.Text.Length > 255)
            {
                MessageBox.Show("Please keep Title under 255 characters.");
            }
            else if (urlTextBox.Text.Length > 255)
            {
                MessageBox.Show("Please keep URL under 255 characters.");
            }
            else if (typeTextBox.Text == "" || typeTextBox.Text == null)
            {
                MessageBox.Show("Please add Type of appointment.");
            }
            else
            {
                customerID = Int32.Parse(customerIDTextBox.Text);

                if (startAMPM.Text == "PM" && Int32.Parse(startDropDownHour.Text) < 12)
                {
                    int startHour = Int32.Parse(startDropDownHour.Text) + 12;
                    start = $"{date}" + " " + $"{startHour}:{startDropDownMin.Text}:00";
                }
                else if (startAMPM.Text == "AM" && Int32.Parse(startDropDownHour.Text) == 12)
                {
                    string startHour = "00";
                    start = $"{date}" + " " + $"{startHour}:{startDropDownMin.Text}:00";
                }
                else
                {
                    string startHour = startDropDownHour.Text;
                    start = $"{date}" + " " + $"{startHour}:{startDropDownMin.Text}:00";
                }


                if (endAMPM.Text == "PM" && Int32.Parse(endDropDownHour.Text) < 12)
                {
                    int endHour = Int32.Parse(endDropDownHour.Text) + 12;
                    end = $"{date}" + " " + $"{endHour}:{endDropDownMin.Text}:00";
                }
                else if (endAMPM.Text == "AM" && Int32.Parse(endDropDownHour.Text) == 12)
                {
                    string endHour = "00";
                    end = $"{date}" + " " + $"{endHour}:{endDropDownMin.Text}:00";
                }
                else
                {
                    string endHour = endDropDownHour.Text;
                    end = $"{date}" + " " + $"{endHour}:{endDropDownMin.Text}:00";
                }

                start = DBConnection.getConvertedDateTime(DateTime.Parse(start));
                end = DBConnection.getConvertedDateTime(DateTime.Parse(end));

                DateTime startDateTime = DateTime.Parse(start);
                DateTime endDateTime = DateTime.Parse(end);
                TimeSpan startOfDayTime = new TimeSpan(13,0,0);
                TimeSpan endOfDayTime = new TimeSpan(21, 0, 0);


                if (startDateTime.TimeOfDay < startOfDayTime || startDateTime.TimeOfDay > endOfDayTime || endDateTime.TimeOfDay < startOfDayTime || endDateTime.TimeOfDay > endOfDayTime)
                {
                    MessageBox.Show("Please keep appointment times between the hours of 9:00am and 5:00PM EST");
                }
                else if (datePicker.Value.DayOfWeek == DayOfWeek.Sunday || datePicker.Value.DayOfWeek == DayOfWeek.Saturday)
                {
                    MessageBox.Show("Please keep appointment date between Monday and Friday");
                }
                else
                {
                    int currentAppointmentSearch = 1;
                    bool isAppointmentValid = true;

                    while (currentAppointmentSearch < DBConnection.getMaxID("appointmentId", "appointment"))
                    {
                        string stringAppointmentSearch = currentAppointmentSearch.ToString();
                        DateTime currentAppointmentStart = DBConnection.singleDateTimeQuery("start", "appointment", "appointmentId", stringAppointmentSearch);
                        DateTime currentAppointmentEnd = DBConnection.singleDateTimeQuery("end", "appointment", "appointmentId", stringAppointmentSearch);

                        if (startDateTime.Day == currentAppointmentStart.Day || endDateTime.Day == currentAppointmentEnd.Day)
                        {
                            if (startDateTime.TimeOfDay >= currentAppointmentStart.TimeOfDay && startDateTime.TimeOfDay < currentAppointmentEnd.TimeOfDay)
                            {
                                if (currentAppointmentSearch != passAppointmentID)
                                {
                                    isAppointmentValid = false;
                                }
                            }
                            else if (endDateTime.TimeOfDay >= currentAppointmentStart.TimeOfDay && endDateTime.TimeOfDay <= currentAppointmentEnd.TimeOfDay)
                            {
                                if (currentAppointmentSearch != passAppointmentID)
                                {
                                    isAppointmentValid = false;
                                }
                            }
                        }
                        currentAppointmentSearch++;
                    }

                    if (isAppointmentValid == false)
                    {
                        MessageBox.Show("Appointment overlaps with existing appointment");
                    }
                    else
                    {
                    Appointment currentAppointment = DBConnection.createAppointment(
                    customerID,
                    titleTextBox.Text,
                    descriptionTextBox.Text,
                    locationTextBox.Text,
                    contactTextBox.Text,
                    typeTextBox.Text,
                    urlTextBox.Text,
                    start,
                    end
                    );

                    DBConnection.alterAppointment(passAppointmentID, currentAppointment);
                    Close();
                    }
                }
            }
        }
    }
}

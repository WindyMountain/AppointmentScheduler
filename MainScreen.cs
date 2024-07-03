using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WendyMonahanC969.Database;
using WendyMonahanC969.Classes;
using static WendyMonahanC969.Database.DBConnection;
using Org.BouncyCastle.Tls;
using System.IO;

namespace WendyMonahanC969
{
    public partial class MainScreen : Form
    {
        string localTimeZoneMS;
        public MainScreen(string localTimeZone)
        {
            InitializeComponent();
            getCustomerTable();
            getAppointmentTable();
            localTimeZoneMS = localTimeZone;
            if (DBConnection.checkImmediateAppointments(DBConnection.currentUser.currentUserID) != "")
            {
                string filePath = @"..\..\Login_History.txt";
                List<string> lines = new List<string>();
                lines = File.ReadAllLines(filePath).ToList();
                foreach (string line in lines)
                {
                    MessageBox.Show(line);
                }
                lines.Add($"User ID# {DBConnection.currentUser.currentUserID} logged in at {DateTime.UtcNow}");
                File.WriteAllLines(filePath, lines);
                MessageBox.Show(DBConnection.checkImmediateAppointments(DBConnection.currentUser.currentUserID));
            }
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Customers
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        public void getCustomerTable()
        {
            List<DisplayCustomer> customerDisplay = new List<DisplayCustomer>();
            int currentCustomerID = 1;
            
            while (currentCustomerID < DBConnection.getMaxID("customerId", "customer"))
            {
                string currentStringID = currentCustomerID.ToString();

                if (DBConnection.singleIntQuery("customerId", "customer", "customerId", currentStringID) == currentCustomerID)
                {
                    string newCustomerName = DBConnection.singleStringQuery("customerName", "customer", "customerId", $"{currentCustomerID}");
                    int newAddressID = DBConnection.singleIntQuery("addressId", "customer", "customerId", $"{currentCustomerID}");
                    string newAddress1 = DBConnection.singleStringQuery("address", "address", "addressId", $"{newAddressID}");
                    string newAddress2 = DBConnection.singleStringQuery("address2", "address", "addressId", $"{newAddressID}");
                    string newPhone = DBConnection.singleStringQuery("phone", "address", "addressId", $"{newAddressID}");

                    customerDisplay.Add(new DisplayCustomer() { ID = currentCustomerID, Name = newCustomerName, Address = newAddress1, Address2 = newAddress2, Phone = newPhone });
                }

                currentCustomerID++;
            }
            customerDataGrid.DataSource = customerDisplay;
        }

        private void customerAddBtn_Click(object sender, EventArgs e)
        {
            new AddCustomer().ShowDialog();
            getCustomerTable();
            getAppointmentTable();
        }

        private void customerUpdateBtn_Click(object sender, EventArgs e)
        {
            DisplayCustomer customerPass = (DisplayCustomer)customerDataGrid.CurrentRow.DataBoundItem;
            new UpdateCustomer(customerPass.ID).ShowDialog();
            getCustomerTable();
            getAppointmentTable();
        }

        private void customerDeleteBtn_Click(object sender, EventArgs e)
        {
            DisplayCustomer customerPass = (DisplayCustomer)customerDataGrid.CurrentRow.DataBoundItem;
            DBConnection.deleteCustomer(customerPass.ID);
            getCustomerTable();
            getAppointmentTable();
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Appointments
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        public void getAppointmentTable()
        {
            List<DisplayAppointment> appointmentDisplay = new List<DisplayAppointment>();
            int currentAppointmentID = 1;

            while (currentAppointmentID < DBConnection.getMaxID("appointmentId", "appointment"))
            {
                string currentStringID = currentAppointmentID.ToString();

                if (DBConnection.singleIntQuery("appointmentId", "appointment", "appointmentId", currentStringID) == currentAppointmentID)
                {
                    string newType = DBConnection.singleStringQuery("type", "appointment", "appointmentId", $"{currentAppointmentID}");
                    int newCustomerID = DBConnection.singleIntQuery("customerId", "appointment", "appointmentId", $"{currentAppointmentID}");
                    string newCustomerName = DBConnection.singleStringQuery("customerName", "customer", "customerId", $"{newCustomerID}");
                    DateTime newStart = DBConnection.singleDateTimeQuery("start", "appointment", "appointmentId", $"{currentAppointmentID}");
                    DateTime newEnd = DBConnection.singleDateTimeQuery("end", "appointment", "appointmentId", $"{currentAppointmentID}");

                    string newStartTemp = DBConnection.getUnconvertedDateTime(newStart);
                    string newEndTemp = DBConnection.getUnconvertedDateTime(newEnd);
                    newStart = DateTime.Parse(DBConnection.getUnconvertedDateTime(newStart));
                    newEnd = DateTime.Parse(DBConnection.getUnconvertedDateTime(newEnd));

                    appointmentDisplay.Add(new DisplayAppointment() { AppointmentID = currentAppointmentID, Type = newType, CustomerID = newCustomerID, CustomerName = newCustomerName, Start = newStart, End = newEnd });
                }

                currentAppointmentID++;
            }
            appointmentDataGrid.DataSource = appointmentDisplay;
        }

        public void sortAppointmentTable(DateTime currentDay)
        {
            List<DisplayAppointment> appointmentDisplay = new List<DisplayAppointment>();
            int currentAppointmentID = 1;

            while (currentAppointmentID < DBConnection.getMaxID("appointmentId", "appointment"))
            {
                string currentStringID = currentAppointmentID.ToString();

                if (DBConnection.singleIntQuery("appointmentId", "appointment", "appointmentId", currentStringID) == currentAppointmentID)
                {
                    string newType = DBConnection.singleStringQuery("type", "appointment", "appointmentId", $"{currentAppointmentID}");
                    int newCustomerID = DBConnection.singleIntQuery("customerId", "appointment", "appointmentId", $"{currentAppointmentID}");
                    string newCustomerName = DBConnection.singleStringQuery("customerName", "customer", "customerId", $"{newCustomerID}");
                    DateTime newStart = DBConnection.singleDateTimeQuery("start", "appointment", "appointmentId", $"{currentAppointmentID}");
                    DateTime newEnd = DBConnection.singleDateTimeQuery("end", "appointment", "appointmentId", $"{currentAppointmentID}");

                    string newStartTemp = DBConnection.getUnconvertedDateTime(newStart);
                    string newEndTemp = DBConnection.getUnconvertedDateTime(newEnd);
                    newStart = DateTime.Parse(DBConnection.getUnconvertedDateTime(newStart));
                    newEnd = DateTime.Parse(DBConnection.getUnconvertedDateTime(newEnd));

                    if (newStart.Day == currentDay.Day && newStart.Month == currentDay.Month && newStart.Year == currentDay.Year)
                    {
                        appointmentDisplay.Add(new DisplayAppointment() { AppointmentID = currentAppointmentID, Type = newType, CustomerID = newCustomerID, CustomerName = newCustomerName, Start = newStart, End = newEnd });
                    }
                }

                currentAppointmentID++;
            }
            appointmentDataGrid.DataSource = appointmentDisplay;
        }

        private void addAppointmentBtn_Click(object sender, EventArgs e)
        {
            new AddAppointment(localTimeZoneMS).ShowDialog();
            getCustomerTable();
            getAppointmentTable();
        }

        private void updateAppointmentBtn_Click(object sender, EventArgs e)
        {
            DisplayAppointment appointmentPass = (DisplayAppointment)appointmentDataGrid.CurrentRow.DataBoundItem;
            new UpdateAppointment(appointmentPass, localTimeZoneMS).ShowDialog();
            getCustomerTable();
            getAppointmentTable();
        }

        private void deleteAppointmentBtn_Click(object sender, EventArgs e)
        {
            DisplayAppointment appointmentPass = (DisplayAppointment)appointmentDataGrid.CurrentRow.DataBoundItem;
            DBConnection.deleteAppointment(appointmentPass.AppointmentID);
            getCustomerTable();
            getAppointmentTable();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Reports
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        private void reportsBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(getAppointmentTypesInMonth());
            MessageBox.Show(getCustomerSchedule());
            MessageBox.Show(getCustomerAlphabetized());
        }

        private void appointmentCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            sortAppointmentTable(appointmentCalendar.SelectionStart);
        }

        public static string getAppointmentTypesInMonth()
        {
            List<DisplayAppointment> appointmentDisplay = new List<DisplayAppointment>();
            int currentAppointmentID = 1;

            while (currentAppointmentID < DBConnection.getMaxID("appointmentId", "appointment"))
            {
                string currentStringID = currentAppointmentID.ToString();

                if (DBConnection.singleIntQuery("appointmentId", "appointment", "appointmentId", currentStringID) == currentAppointmentID)
                {
                    string newType = DBConnection.singleStringQuery("type", "appointment", "appointmentId", $"{currentAppointmentID}");
                    int newCustomerID = DBConnection.singleIntQuery("customerId", "appointment", "appointmentId", $"{currentAppointmentID}");
                    string newCustomerName = DBConnection.singleStringQuery("customerName", "customer", "customerId", $"{newCustomerID}");
                    DateTime newStart = DBConnection.singleDateTimeQuery("start", "appointment", "appointmentId", $"{currentAppointmentID}");
                    DateTime newEnd = DBConnection.singleDateTimeQuery("end", "appointment", "appointmentId", $"{currentAppointmentID}");

                    string newStartTemp = DBConnection.getUnconvertedDateTime(newStart);
                    string newEndTemp = DBConnection.getUnconvertedDateTime(newEnd);
                    newStart = DateTime.Parse(DBConnection.getUnconvertedDateTime(newStart));
                    newEnd = DateTime.Parse(DBConnection.getUnconvertedDateTime(newEnd));

                    appointmentDisplay.Add(new DisplayAppointment() { AppointmentID = currentAppointmentID, Type = newType, CustomerID = newCustomerID, CustomerName = newCustomerName, Start = newStart, End = newEnd });
                }

                currentAppointmentID++;
            }

            List<MonthsSimplified> monthsSimplified = appointmentDisplay.Select(a => new MonthsSimplified
            {
                AppointmentID = a.AppointmentID,
                AppointmentMonth = a.Start.Month,
                AppointmentType = a.Type
            }).ToList();

            List<TotalMonths> totalMonths = new List<TotalMonths>();
            List<TypesInMonth> typesInMonth = new List<TypesInMonth>();

            //Finding the number of months that have appointments

            foreach (MonthsSimplified x in  monthsSimplified)
            {
                bool isEmpty = !totalMonths.Any();

                if (isEmpty)
                {
                    totalMonths.Add(new TotalMonths() { Month = x.AppointmentMonth });
                }
                else
                {
                    bool currentMonthExists = false;

                    foreach (TotalMonths y in totalMonths)
                    {
                        if (x.AppointmentMonth == y.Month)
                        {
                            currentMonthExists = true;
                        }
                    }

                    if (currentMonthExists == false)
                    {
                        totalMonths.Add(new TotalMonths() { Month = x.AppointmentMonth });
                    }
                }
            }

            //Finding the total number of types, counting them, and adding them to the respective month
            
            foreach (TotalMonths y in totalMonths)
            {
                List<TotalTypes> totalTypes = new List<TotalTypes>();

                bool isEmpty = !totalTypes.Any();

                foreach (MonthsSimplified x in monthsSimplified)
                {
                    if (x.AppointmentMonth == y.Month)
                    {
                        if (isEmpty)
                        {
                            totalTypes.Add(new TotalTypes() { Type = x.AppointmentType });
                        }
                        else
                        {
                            bool currentTypeExists = false;

                            foreach (TotalTypes z in totalTypes)
                            {
                                if (x.AppointmentType == z.Type)
                                {
                                    currentTypeExists = true;
                                }
                            }

                            if (currentTypeExists == false)
                            {
                                totalTypes.Add(new TotalTypes() { Type = x.AppointmentType });
                            }
                        }
                    }
                }

                string currentMonth = "";

                switch (y.Month)
                {
                    case 1:
                        currentMonth = "January";
                        break;
                    case 2:
                        currentMonth = "February";
                        break;
                    case 3:
                        currentMonth = "March";
                        break;
                    case 4:
                        currentMonth = "April";
                        break;
                    case 5:
                        currentMonth = "May";
                        break;
                    case 6:
                        currentMonth = "June";
                        break;
                    case 7:
                        currentMonth = "July";
                        break;
                    case 8:
                        currentMonth = "August";
                        break;
                    case 9:
                        currentMonth = "September";
                        break;
                    case 10:
                        currentMonth = "October";
                        break;
                    case 11:
                        currentMonth = "November";
                        break;
                    case 12:
                        currentMonth = "December";
                        break;

                }

                typesInMonth.Add(new TypesInMonth() { Month = currentMonth, NumberOfTypes = totalTypes.Count });
            }

            string result = "Number of Appointment Types in Each Month \n";

            foreach (TypesInMonth x in typesInMonth)
            {
                result += $"\n {x.Month} : {x.NumberOfTypes}";
            }

            return result;
            
        }

        public static string getCustomerSchedule()
        {
            List<DisplayAppointment> appointmentDisplay = new List<DisplayAppointment>();
            int currentAppointmentID = 1;

            while (currentAppointmentID < DBConnection.getMaxID("appointmentId", "appointment"))
            {
                string currentStringID = currentAppointmentID.ToString();

                if (DBConnection.singleIntQuery("appointmentId", "appointment", "appointmentId", currentStringID) == currentAppointmentID)
                {
                    string newType = DBConnection.singleStringQuery("type", "appointment", "appointmentId", $"{currentAppointmentID}");
                    int newCustomerID = DBConnection.singleIntQuery("customerId", "appointment", "appointmentId", $"{currentAppointmentID}");
                    string newCustomerName = DBConnection.singleStringQuery("customerName", "customer", "customerId", $"{newCustomerID}");
                    DateTime newStart = DBConnection.singleDateTimeQuery("start", "appointment", "appointmentId", $"{currentAppointmentID}");
                    DateTime newEnd = DBConnection.singleDateTimeQuery("end", "appointment", "appointmentId", $"{currentAppointmentID}");

                    string newStartTemp = DBConnection.getUnconvertedDateTime(newStart);
                    string newEndTemp = DBConnection.getUnconvertedDateTime(newEnd);
                    newStart = DateTime.Parse(DBConnection.getUnconvertedDateTime(newStart));
                    newEnd = DateTime.Parse(DBConnection.getUnconvertedDateTime(newEnd));

                    appointmentDisplay.Add(new DisplayAppointment() { AppointmentID = currentAppointmentID, Type = newType, CustomerID = newCustomerID, CustomerName = newCustomerName, Start = newStart, End = newEnd });
                }

                currentAppointmentID++;
            }

            List<DisplayCustomer> customerDisplay = new List<DisplayCustomer>();
            int currentCustomerID = 1;

            while (currentCustomerID < DBConnection.getMaxID("customerId", "customer"))
            {
                string currentStringID = currentCustomerID.ToString();

                if (DBConnection.singleIntQuery("customerId", "customer", "customerId", currentStringID) == currentCustomerID)
                {
                    string newCustomerName = DBConnection.singleStringQuery("customerName", "customer", "customerId", $"{currentCustomerID}");
                    int newAddressID = DBConnection.singleIntQuery("addressId", "customer", "customerId", $"{currentCustomerID}");
                    string newAddress1 = DBConnection.singleStringQuery("address", "address", "addressId", $"{newAddressID}");
                    string newAddress2 = DBConnection.singleStringQuery("address2", "address", "addressId", $"{newAddressID}");
                    string newPhone = DBConnection.singleStringQuery("phone", "address", "addressId", $"{newAddressID}");

                    customerDisplay.Add(new DisplayCustomer() { ID = currentCustomerID, Name = newCustomerName, Address = newAddress1, Address2 = newAddress2, Phone = newPhone });
                }

                currentCustomerID++;

            }

            List<CustomersSimplified> customersSimplified = customerDisplay.Select(a => new CustomersSimplified
            {
                CustomerID = a.ID,
                CustomerName = a.Name,
            }).ToList();

            List<CustomerSchedule> customerSchedules = new List<CustomerSchedule>();

            foreach ( CustomersSimplified x in customersSimplified )
            {
                List<DisplayAppointment> currentAppointments = new List<DisplayAppointment>();

                foreach ( DisplayAppointment y in appointmentDisplay)
                {
                    if (x.CustomerID == y.CustomerID)
                    {
                        currentAppointments.Add(new DisplayAppointment() { AppointmentID =  y.AppointmentID, Type = y.Type, Start = y.Start, End = y.End});
                    }
                }
                customerSchedules.Add( new CustomerSchedule() { CustomerID = x.CustomerID, CustomerName = x.CustomerName, Appointments = currentAppointments });
            }

            string result = "Customer Schedules: \n";

            foreach (CustomerSchedule x in customerSchedules)
            {
                if (x.Appointments.Count >0)
                {
                    result += $"\n ID# {x.CustomerID} / {x.CustomerName}\n{x.getScheduleAppointments()}\n";
                }
            }

            return result;

        }

        public static string getCustomerAlphabetized()
        {
            List<DisplayCustomer> customerDisplay = new List<DisplayCustomer>();
            int currentCustomerID = 1;

            while (currentCustomerID < DBConnection.getMaxID("customerId", "customer"))
            {
                string currentStringID = currentCustomerID.ToString();

                if (DBConnection.singleIntQuery("customerId", "customer", "customerId", currentStringID) == currentCustomerID)
                {
                    string newCustomerName = DBConnection.singleStringQuery("customerName", "customer", "customerId", $"{currentCustomerID}");
                    int newAddressID = DBConnection.singleIntQuery("addressId", "customer", "customerId", $"{currentCustomerID}");
                    string newAddress1 = DBConnection.singleStringQuery("address", "address", "addressId", $"{newAddressID}");
                    string newAddress2 = DBConnection.singleStringQuery("address2", "address", "addressId", $"{newAddressID}");
                    string newPhone = DBConnection.singleStringQuery("phone", "address", "addressId", $"{newAddressID}");

                    customerDisplay.Add(new DisplayCustomer() { ID = currentCustomerID, Name = newCustomerName, Address = newAddress1, Address2 = newAddress2, Phone = newPhone });
                }

                currentCustomerID++;

            }

            string result = "Customer's Listed Alphabetically: \n";

            var customersAlphabetized = customerDisplay.OrderBy(customer => customer.Name);

            new List<DisplayCustomer>(customersAlphabetized).ForEach(customer => result += $"\n{customer.Name}");

            return result;

        }
    }
}

using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WendyMonahanC969.Classes;
using System.Globalization;
using Mysqlx.Session;
using System.Text.RegularExpressions;

namespace WendyMonahanC969.Database
{
    public class DBConnection
    {

        // Database Connection

        public static MySqlConnection conn { get; set; }
        public static void startConnection()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["JavaConnection"].ConnectionString;
                conn = new MySqlConnection(constr);
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void stopConnection()
        {
            try
            {
                if (conn != null)
                {
                    conn.Close();
                }
                conn = null;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        // Storing the info of the user who logged in




        public class DBUser
        {
            public string currentUserName { get; set; }
            public int currentUserID { get; set; }

            public void setDBUserInfo(int iD, string userName)
            {
                currentUserID = iD;
                currentUserName = userName;
            }

            public string getDBUserName()
            {
                return currentUserName;
            }

            public int getDBUserID()
            {
                return currentUserID;
            }
        }

        public static DBUser currentUser = new DBUser();



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Universal Queries
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        public static string singleStringQuery(string select, string from, string where, string equals)
        {
            string stringQuery = $"Select {select} from {from} where {where} = '{equals}'";

            MySqlCommand stringCheck = new MySqlCommand(stringQuery, conn);

            using (MySqlDataReader stringReader = stringCheck.ExecuteReader())
            {
                string stringResult = "";

                while (stringReader.Read())
                {
                    stringResult = stringReader.GetString(0);
                }

                return stringResult;
            }
        }

        public static int singleIntQuery(string select, string from, string where, string equals)
        {
            string intQuery = $"Select {select} from {from} where {where} = '{equals}'";

            MySqlCommand intCheck = new MySqlCommand(intQuery, conn);

            using (MySqlDataReader intReader = intCheck.ExecuteReader())
            {
                int intResult = 0;

                while (intReader.Read())
                {
                    intResult = intReader.GetInt32(0);
                }

                return intResult;
            }
        }

        public static DateTime singleDateTimeQuery(string select, string from, string where, string equals)
        {
            string dateTimeQuery = $"Select {select} from {from} where {where} = '{equals}'";

            MySqlCommand dateTimeCheck = new MySqlCommand(dateTimeQuery, conn);

            using (MySqlDataReader dateTimeReader = dateTimeCheck.ExecuteReader())
            {
                DateTime dateTimeResult = DateTime.UtcNow;

                while (dateTimeReader.Read())
                {
                    dateTimeResult = dateTimeReader.GetDateTime(0);
                }

                return dateTimeResult;
            }
        }

        public static int getNewID(string select, string from)
        {
            string maxQuery = $"Select {select}, MAX({select}) from {from} GROUP BY {select}";

            MySqlCommand maxCheck = new MySqlCommand(maxQuery, conn);

            int maxResult = 0;
            int currentResult = 1;

            using (MySqlDataReader maxReader = maxCheck.ExecuteReader())
            {
                while (maxReader.Read())
                {
                    maxResult = maxReader.GetInt32(0) + 1;
                }
            }

            while (currentResult < maxResult)
            {
                int x = singleIntQuery(select, from, select, currentResult.ToString());
                if (x != currentResult)
                {
                    break;
                }
                currentResult++;
            }

            return currentResult;
        }

        public static int getMaxID(string select, string from)
        {
            string maxQuery = $"Select {select}, MAX({select}) from {from} GROUP BY {select}";

            MySqlCommand maxCheck = new MySqlCommand(maxQuery, conn);

            int maxResult = 0;

            using (MySqlDataReader maxReader = maxCheck.ExecuteReader())
            {
                while (maxReader.Read())
                {
                    maxResult = maxReader.GetInt32(0) + 1;
                }
                return maxResult;
            }
        }

        public static string getStringDateTime(DateTime currentDateTime)
        {
            string stringDateTime = currentDateTime.ToString("s");
            string replacedDateTime = stringDateTime.Replace("T", " ");
            return replacedDateTime;
        }

        public static string getStringDate(DateTime currentDateTime)
        {
            string stringDateTime = currentDateTime.ToString("s");
            string replacedDateTime = stringDateTime.Replace("T", " ");
            int index = replacedDateTime.IndexOf(" ");

            if (index >= 0)
            {
                replacedDateTime = replacedDateTime.Substring(0, index);
            }
            
            return replacedDateTime;
        }

        public static string getConvertedTime(DateTime currentDateTime)
        {
            TimeZoneInfo timeZone = TimeZoneInfo.Local;
            DateTime utcTime = TimeZoneInfo.ConvertTimeToUtc(currentDateTime, timeZone);
            string stringDateTime = utcTime.ToString("s");
            string replacedDateTime = stringDateTime.Replace("T", " ");
            int index = replacedDateTime.IndexOf(" ");

            if (index >= 0)
            {
                int start = index + 1;

                replacedDateTime = replacedDateTime.Substring(start);
            }

            return replacedDateTime;
        }

        public static string getConvertedDateTime(DateTime currentDateTime)
        {
            TimeZoneInfo timeZone = TimeZoneInfo.Local;
            DateTime utcTime = TimeZoneInfo.ConvertTimeToUtc(currentDateTime, timeZone);
            string stringDateTime = utcTime.ToString("s");
            string replacedDateTime = stringDateTime.Replace("T", " ");
            return replacedDateTime;
        }

        public static string getUnconvertedDateTime(DateTime currentDateTime)
        {
            TimeZoneInfo timeZone = TimeZoneInfo.Local;
            DateTime utcTime = TimeZoneInfo.ConvertTimeFromUtc(currentDateTime, timeZone);
            string stringDateTime = utcTime.ToString("s");
            string replacedDateTime = stringDateTime.Replace("T", " ");
            return replacedDateTime;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Country Queries
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static Country createCountry(string countryName)
        {
            if (singleStringQuery("country", "country", "country", countryName) == countryName)
            {
                Country country = new Country();

                country.countryID = singleIntQuery("countryId", "country", "country", countryName);
                country.country = countryName;
                country.createDate = DateTime.UtcNow;
                country.createdBy = currentUser.getDBUserName();
                country.lastUpdate = DateTime.UtcNow;
                country.lastUpdateBy = currentUser.getDBUserName();

                return country;
            }
            else
            {
                Country country = new Country();

                country.countryID = getNewID("countryId", "country");
                country.country = countryName;
                country.createDate = DateTime.UtcNow;
                country.createdBy = currentUser.getDBUserName();
                country.lastUpdate = DateTime.UtcNow;
                country.lastUpdateBy = currentUser.getDBUserName();

                return country;
            }
        }

        public static bool checkCountry(Country city)
        {
            var result = false;

            if (city.country.Length > 50)
            {
                MessageBox.Show("Please keep Country under 50 characters.");
            }
            else
            {
                result = true;
            }

            return result;
        }

        public static void insertCountry(Country country)
        {
            if (checkCountry(country) == true)
            {
                string columns = 
                    $"countryID," +
                    $"country," +
                    $"createDate," +
                    $"createdBy," +
                    $"lastUpdate," +
                    $"lastUpdateBy";

                string values =
                    $"\'{country.countryID}\'," +
                    $"\'{country.country}\'," +
                    $"\'{getStringDateTime(country.createDate)}\'," +
                    $"\'{country.createdBy}\'," +
                    $"\'{getStringDateTime(country.lastUpdate)}\'," +
                    $"\'{country.lastUpdateBy}\'";

                string insertCountryQuery = $"INSERT INTO country ({columns}) VALUES ({values});";

                MySqlCommand insertCountry = new MySqlCommand(insertCountryQuery, conn);
                using (MySqlDataReader insertCountryDataReader = insertCountry.ExecuteReader())
                {
                    while (insertCountryDataReader.Read()) { }
                }
            }
        }

        public static void updateCountry(Country country)
        {
            if (checkCountry(country) == true)
            {
                string sets = $"countryId = \'{country.countryID}\',country = \'{country.country}\',createDate = \'{getStringDateTime(country.createDate)}\',createdBy = \'{country.createdBy}\',lastUpdate = \'{getStringDateTime(country.lastUpdate)}\',lastUpdateBy = \'{country.lastUpdateBy}\'";
                string updateCountryQuery = $"UPDATE country SET {sets} WHERE countryId = {country.countryID};";

                MySqlCommand updateCountry = new MySqlCommand(updateCountryQuery, conn);
                using (MySqlDataReader updateCountryDataReader = updateCountry.ExecuteReader())
                {
                    while (updateCountryDataReader.Read()) { }
                }
            }
        }

        public static void deleteCountry(Country country)
        {
            string deleteCountryQuery = $"DELETE FROM country WHERE countryId = {country.countryID};";

            MySqlCommand deleteCountry = new MySqlCommand(deleteCountryQuery, conn);
            using (MySqlDataReader deleteCountryDataReader = deleteCountry.ExecuteReader())
            {
                while (deleteCountryDataReader.Read()) { }
            }
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // City Queries
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static City createCity(string cityName, int countryID)
        {
            City city = new City();

            DateTime currentDateTime = DateTime.UtcNow;
            string currentTime = currentDateTime.ToString();

            city.cityID = getNewID("cityId", "city");
            city.city = cityName;
            city.countryID = countryID;
            city.createDate = DateTime.UtcNow;
            city.createdBy = currentUser.getDBUserName();
            city.lastUpdate = DateTime.UtcNow;
            city.lastUpdateBy = currentUser.getDBUserName();



            return city;
        }

        public static bool checkCity(City city)
        {
            var result = false;

            if (city.city.Length > 50)
            {
                MessageBox.Show("Please keep City under 50 characters.");
            }
            else
            {
                result = true;
            }

            return result;
        }

        public static void insertCity(City city)
        {
            if (checkCity(city) == true)
            {
                string columns = 
                    "cityID," +
                    "city," +
                    "countryID," +
                    "createDate," +
                    "createdBy," +
                    "lastUpdate," +
                    "lastUpdateBy";

                string values =
                    $"\'{city.cityID}\'," +
                    $"\'{city.city}\'," +
                    $"\'{city.countryID}\'," +
                    $"\'{getStringDateTime(city.createDate)}\'," +
                    $"\'{city.createdBy}\'," +
                    $"\'{getStringDateTime(city.lastUpdate)}\'," +
                    $"\'{city.lastUpdateBy}\'";

                string insertCityQuery = $"INSERT INTO city ({columns}) VALUES ({values});";

                MySqlCommand insertCity = new MySqlCommand(insertCityQuery, conn);
                using (MySqlDataReader insertCityDataReader = insertCity.ExecuteReader())
                {
                    while (insertCityDataReader.Read()) { }
                }
            }
        }
        public static void updateCity(City city)
        {
            if (checkCity(city) == true)
            {
                string sets = $"cityId = \'{city.cityID}\',city = \'{city.city}\',countryID = \'{city.countryID}\',createDate = \'{getStringDateTime(city.createDate)}\',createdBy = \'{city.createdBy}\',lastUpdate = \'{getStringDateTime(city.lastUpdate)}\',lastUpdateBy = \'{city.lastUpdateBy}\'";
                string updateCityQuery = $"UPDATE city SET {sets} WHERE cityId = {city.cityID};";

                MySqlCommand updateCity = new MySqlCommand(updateCityQuery, conn);
                using (MySqlDataReader updateCityDataReader = updateCity.ExecuteReader())
                {
                    while (updateCityDataReader.Read()) { }
                }
            }
        }

        public static void deleteCity(City city)
        {
            string deleteCityQuery = $"DELETE FROM city WHERE cityId = {city.cityID};";

            MySqlCommand deleteCity = new MySqlCommand(deleteCityQuery, conn);
            using (MySqlDataReader deleteCityDataReader = deleteCity.ExecuteReader())
            {
                while (deleteCityDataReader.Read()) { }
            }
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Address Queries
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static Address createAddress(string address1, string address2, string postalCode, string phone, int cityID)
        {
            Address address = new Address();

            address.addressID = getNewID("addressId", "address");
            address.address1 = address1;
            address.address2 = address2;
            address.cityID = cityID;
            address.postalCode = postalCode;
            address.phone = phone;
            address.createDate = DateTime.UtcNow;
            address.createdBy = currentUser.getDBUserName();
            address.lastUpdate = DateTime.UtcNow;
            address.lastUpdateBy = currentUser.getDBUserName();

            return address;
        }

        public static void insertAddress(Address address)
        { 
            string columns = 
                "addressID," +
                "address," +
                "address2," +
                "cityID," +
                "postalCode," +
                "phone," +
                "createDate," +
                "createdBy," +
                "lastUpdate," +
                "lastUpdateBy";

            string values =
                $"\'{address.addressID}\'," +
                $"\'{address.address1}\'," +
                $"\'{address.address2}\'," +
                $"\'{address.cityID}\'," +
                $"\'{address.postalCode}\'," +
                $"\'{address.phone}\'," +
                $"\'{getStringDateTime(address.createDate)}\'," +
                $"\'{address.createdBy}\'," +
                $"\'{getStringDateTime(address.lastUpdate)}\'," +
                $"\'{address.lastUpdateBy}\'";

            string insertAddressQuery = $"INSERT INTO address ({columns}) VALUES ({values});";

            MySqlCommand insertAddress = new MySqlCommand(insertAddressQuery, conn);
            using (MySqlDataReader insertAddressDataReader = insertAddress.ExecuteReader())
            {
                while (insertAddressDataReader.Read()) { }
            }
        }

        public static void updateAddress(Address address)
        {
            string sets = $"addressId = \'{address.addressID}\',address = \'{address.address1}\',address2 = \'{address.address2}\',cityId = \'{address.cityID}\',postalCode = \'{address.postalCode}\', phone = \'{address.phone}\',createDate = \'{getStringDateTime(address.createDate)}\',createdBy = \'{address.createdBy}\',lastUpdate = \'{getStringDateTime(address.lastUpdate)}\',lastUpdateBy = \'{address.lastUpdateBy}\'";
            string updateAddressQuery = $"UPDATE address SET {sets} WHERE addressId = {address.addressID};";

            MySqlCommand updateAddress = new MySqlCommand(updateAddressQuery, conn);
            using (MySqlDataReader updateAddressDataReader = updateAddress.ExecuteReader())
            {
                while (updateAddressDataReader.Read()) { }
            }
        }

        public static void deleteAddress(Address address)
        {
            string deleteAddressQuery = $"DELETE FROM address WHERE addressId = {address.addressID};";

            MySqlCommand deleteAddress = new MySqlCommand(deleteAddressQuery, conn);
            using (MySqlDataReader deleteAddressDataReader = deleteAddress.ExecuteReader())
            {
                while (deleteAddressDataReader.Read()) { }
            }
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Customer
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        

        public static Customer createCustomer (string customerName,int addressID, int active)
        {
            Customer customer = new Customer();

            customer.customerID = getNewID("customerId", "customer");
            customer.customerName = customerName;
            customer.addressID = addressID;
            customer.active = active;
            customer.createDate = DateTime.UtcNow;
            customer.createdBy = currentUser.getDBUserName();
            customer.lastUpdate = DateTime.UtcNow;
            customer.lastUpdateBy = currentUser.getDBUserName();

            return customer;
        }

        public static Customer preUpdateCustomer(int customerID, string customerName, int addressID, int active)
        {
            Customer customer = new Customer();

            customer.customerID = customerID;
            customer.customerName = customerName;
            customer.addressID = addressID;
            customer.active = active;
            customer.createDate = DateTime.UtcNow;
            customer.createdBy = currentUser.getDBUserName();
            customer.lastUpdate = DateTime.UtcNow;
            customer.lastUpdateBy = currentUser.getDBUserName();

            return customer;
        }

        public static bool checkCustomer(Customer customer)
        {
            var result = false;

            if (customer.customerName.Length > 45)
            {
                MessageBox.Show("Please keep Name under 45 characters.");
            }
            else
            {
                result = true;
            }

            return result;
        }

        public static void insertCustomer(Customer customer)
        {
            if (checkCustomer(customer) == true)
            {
                string columns = 
                    "customerId," +
                    "customerName," +
                    "addressId," +
                    "active," +
                    "createDate," +
                    "createdBy," +
                    "lastUpdate," +
                    "lastUpdateBy";

                string values =
                    $"\'{customer.customerID}\'," +
                    $"\'{customer.customerName}\'," +
                    $"\'{customer.addressID}\'," +
                    $"\'{customer.active}\'," +
                    $"\'{getStringDateTime(customer.createDate)}\'," +
                    $"\'{customer.createdBy}\'," +
                    $"\'{getStringDateTime(customer.lastUpdate)}\'," +
                    $"\'{customer.lastUpdateBy}\'";

                string insertCustomerQuery = $"INSERT INTO customer ({columns}) VALUES ({values});";

                MySqlCommand insertCustomer = new MySqlCommand(insertCustomerQuery, conn);
                using (MySqlDataReader insertCustomerDataReader = insertCustomer.ExecuteReader())
                {
                    while (insertCustomerDataReader.Read()) { }
                }
            }
        }

        public static void updateCustomer(Customer customer)
        {
            if (checkCustomer(customer) == true)
            {
                string sets = 
                    $"customerId = \'{customer.customerID}\'," +
                    $"customerName = \'{customer.customerName}\'," +
                    $"addressId = \'{customer.addressID}\'," +
                    $"active = \'{customer.active}\'," +
                    $"createDate = \'{getStringDateTime(customer.createDate)}\'," +
                    $"createdBy = \'{customer.createdBy}\'," +
                    $"lastUpdate = \'{getStringDateTime(customer.lastUpdate)}\'," +
                    $"lastUpdateBy = \'{customer.lastUpdateBy}\'";
                
                string updateCustomerQuery = $"UPDATE customer SET {sets} WHERE customerId = {customer.customerID};";

                MySqlCommand updateCustomer = new MySqlCommand(updateCustomerQuery, conn);
                using (MySqlDataReader updateCustomerDataReader = updateCustomer.ExecuteReader())
                {
                    while (updateCustomerDataReader.Read()) { }
                }
            }
        }

        public static void deleteCustomer(int customerID)
        {
            string deleteCustomerQuery = $"DELETE FROM customer WHERE customerId = {customerID};";
            string stringCustomerID = customerID.ToString();

            while (singleIntQuery("customerId", "appointment", "customerId", stringCustomerID) == customerID)
            {
                int appointmentID = singleIntQuery("appointmentId", "appointment", "customerId", stringCustomerID);
                deleteAppointment(appointmentID);
            }

            MySqlCommand deleteCustomer = new MySqlCommand(deleteCustomerQuery, conn);
            using (MySqlDataReader deleteCustomerDataReader = deleteCustomer.ExecuteReader())
            {
                while (deleteCustomerDataReader.Read()) { }
            }
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Customer - Create, Update, Delete
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void addCustomer(string customerName, string address1, string address2, string city, string country, string postalCode, string phone, int active)
        {
            if (singleStringQuery("country", "country", "country", country) == country)
            {
                if (singleStringQuery("city", "city", "city", city) == city)
                {
                    if(singleStringQuery("address", "address", "address", address1) == address1 && singleStringQuery("address2", "address", "address2", address2) == address2)
                    {
                        int addressID = singleIntQuery("addressId", "address", "address", address1);
                        Customer newCustomer = createCustomer(customerName, addressID, active);

                        insertCustomer(newCustomer);
                    }
                    else
                    {
                        int cityID = singleIntQuery("cityId", "city", "city", city);
                        Address newAddress = createAddress(address1, address2, postalCode, phone, cityID);
                        Customer newCustomer = createCustomer(customerName, newAddress.addressID, active);

                        insertAddress(newAddress);
                        insertCustomer(newCustomer);
                    }
                }
                else
                {
                    int countryID = singleIntQuery("countryId", "country", "country", country);
                    City newCity = createCity(city, countryID);
                    Address newAddress = createAddress(address1, address2, postalCode, phone, newCity.cityID);
                    Customer newCustomer = createCustomer(customerName, newAddress.addressID, active);

                    insertCity(newCity);
                    insertAddress(newAddress);
                    insertCustomer(newCustomer);
                }
            }
            else
            {
                Country newCountry = createCountry(country);
                City newCity = createCity(city, newCountry.countryID);
                Address newAddress = createAddress(address1, address2, postalCode, phone, newCity.cityID);
                Customer newCustomer = createCustomer(customerName, newAddress.addressID, active);

                insertCountry(newCountry);
                insertCity(newCity);
                insertAddress(newAddress);
                insertCustomer(newCustomer);
            }
        }


        public static void alterCustomer(int customerID,string customerName, string address1, string address2, string city, string country, string postalCode, string phone, int active)
        {
            if (singleStringQuery("country", "country", "country", country) == country)
            {
                if (singleStringQuery("city", "city", "city", city) == city)
                {
                    if (singleStringQuery("address", "address", "address", address1) == address1 && singleStringQuery("address2", "address", "address2", address2) == address2)
                    {
                        int addressID = singleIntQuery("addressId", "address", "address", address1);
                        Customer updatedCustomer = preUpdateCustomer(customerID, customerName, addressID, active);

                        updateCustomer(updatedCustomer);
                    }
                    else
                    {
                        int cityID = singleIntQuery("cityId", "city", "city", city);
                        Address newAddress = createAddress(address1, address2, postalCode, phone, cityID);
                        Customer updatedCustomer = preUpdateCustomer(customerID, customerName, newAddress.addressID, active);

                        insertAddress(newAddress);
                        updateCustomer(updatedCustomer);
                    }
                }
                else
                {
                    int countryID = singleIntQuery("countryId", "country", "country", country);
                    City newCity = createCity(city, countryID);
                    Address newAddress = createAddress(address1, address2, postalCode, phone, newCity.cityID);
                    Customer updatedCustomer = preUpdateCustomer(customerID, customerName, newAddress.addressID, active);

                    insertCity(newCity);
                    insertAddress(newAddress);
                    updateCustomer(updatedCustomer);
                }
            }
            else
            {
                Country newCountry = createCountry(country);
                City newCity = createCity(city, newCountry.countryID);
                Address newAddress = createAddress(address1, address2, postalCode, phone, newCity.cityID);
                Customer updatedCustomer = preUpdateCustomer(customerID, customerName, newAddress.addressID, active);

                insertCountry(newCountry);
                insertCity(newCity);
                insertAddress(newAddress);
                updateCustomer(updatedCustomer);
            }
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Appointment
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        public static Appointment createAppointment(int customerID, string title, string description, string location, string contact, string type, string url, string start, string end)
        {
            Appointment appointment = new Appointment();

            appointment.appointmentID = getNewID("appointmentId", "appointment");
            appointment.customerID = customerID;
            appointment.userID = currentUser.getDBUserID();
            appointment.title = title;
            appointment.description = description;
            appointment.location = location;
            appointment.contact = contact;
            appointment.type = type;
            appointment.url = url;
            appointment.start = start;
            appointment.end = end;
            appointment.createDate = DateTime.UtcNow;
            appointment.createdBy = currentUser.getDBUserName();
            appointment.lastUpdate = DateTime.UtcNow;
            appointment.lastUpdateBy = currentUser.getDBUserName();

            return appointment;
        }

        public static void insertAppointment(Appointment appointment)
        {
            
            string columns = 
                "appointmentId," +
                "customerId," +
                "userId," +
                "title," +
                "description," +
                "location," +
                "contact," +
                "type," +
                "url," +
                "start," +
                "end," +
                "createDate," +
                "createdBy," +
                "lastUpdate," +
                "lastUpdateBy";

            string values =
                $"\'{appointment.appointmentID}\'," +
                $"\'{appointment.customerID}\'," +
                $"\'{appointment.userID}\'," +
                $"\'{appointment.title}\'," +
                $"\'{appointment.description}\'," +
                $"\'{appointment.location}\'," +
                $"\'{appointment.contact}\'," +
                $"\'{appointment.type}\'," +
                $"\'{appointment.url}\'," +
                $"\'{appointment.start}\'," +
                $"\'{appointment.end}\'," +
                $"\'{getStringDateTime(appointment.createDate)}\'," +
                $"\'{appointment.createdBy}\'," +
                $"\'{getStringDateTime(appointment.lastUpdate)}\'," +
                $"\'{appointment.lastUpdateBy}\'";

            string insertAppointmentQuery = $"INSERT INTO appointment ({columns}) VALUES ({values});";

            MySqlCommand insertAppointment = new MySqlCommand(insertAppointmentQuery, conn);
            using (MySqlDataReader insertAppointmentDataReader = insertAppointment.ExecuteReader())
            {
                while (insertAppointmentDataReader.Read()) { }
            }
            
        }

        public static void deleteAppointment(int appointmentID)
        {
            string deleteAppointmentQuery = $"DELETE FROM appointment WHERE appointmentId = {appointmentID};";

            MySqlCommand deleteAppointment = new MySqlCommand(deleteAppointmentQuery, conn);
            using (MySqlDataReader deleteAppointmentDataReader = deleteAppointment.ExecuteReader())
            {
                while (deleteAppointmentDataReader.Read()) { }
            }
        }

        public static void addAppointment(Appointment appointment)
        {
            insertAppointment(appointment);
        }
        public static void updateAppointment(int appointmentID, Appointment appointment)
        {
            string sets = 
                $"appointmentId = \'{appointmentID}\'," +
                $"customerId = \'{appointment.customerID}\'," +
                $"userId = \'{currentUser.getDBUserID()}\'," +
                $"title = \'{appointment.title}\'," +
                $"description = \'{appointment.description}\'," +
                $"location = '{appointment.location}'," +
                $"contact = '{appointment.contact}'," +
                $"type = '{appointment.type}'," +
                $"url = '{appointment.url}'," +
                $"start = '{appointment.start}'," +
                $"end = '{appointment.end}'," +
                $"createDate = \'{getStringDateTime(appointment.createDate)}\'," +
                $"createdBy = \'{appointment.createdBy}\'," +
                $"lastUpdate = \'{getStringDateTime(appointment.lastUpdate)}\'," +
                $"lastUpdateBy = \'{appointment.lastUpdateBy}\'";

            string updateAppointmentQuery = $"UPDATE appointment SET {sets} WHERE appointmentId = {appointmentID};";

            MySqlCommand updateAppointment = new MySqlCommand(updateAppointmentQuery, conn);
            using (MySqlDataReader updateAppointmentDataReader = updateAppointment.ExecuteReader())
            {
                while (updateAppointmentDataReader.Read()) { }
            }
        }

        public static void alterAppointment(int appointmentID, Appointment appointment)
        {
            updateAppointment(appointmentID, appointment);
        }

        public static string checkImmediateAppointments(int userID)
        {
            int currentAppointmentID = 1;
            int maxAppointmentID = getMaxID("appointmentId", "appointment");
            string result = "";
            
            TimeSpan zero = new TimeSpan(0, 0, 0);
            TimeSpan fifteen = new TimeSpan(0, 15, 0);


            while (currentAppointmentID < maxAppointmentID)
            {
                string stringAppointmentID = currentAppointmentID.ToString();
                TimeSpan timeDifference =singleDateTimeQuery("start", "appointment", "appointmentID", stringAppointmentID) - DateTime.UtcNow;
                if (timeDifference >= zero && timeDifference <= fifteen)
                {
                    if (singleIntQuery("userId", "appointment", "appointmentID", stringAppointmentID) == userID)
                    {
                        result = $"Appointment will begin within 15 minutes! (Appointment ID# {currentAppointmentID})";
                    }
                }
                currentAppointmentID++;
            }

            return result;
        }
    }
}
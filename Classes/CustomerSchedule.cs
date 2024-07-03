using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WendyMonahanC969.Classes
{
    public class CustomerSchedule
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public List<DisplayAppointment> Appointments { get; set; }

        public string getScheduleAppointments()
        {
            string result = "";
            int appointmentCounter = 1;
            string timeZone = TimeZoneInfo.Local.Id;

            foreach (DisplayAppointment appointment in Appointments)
            {
                result += $"\nAppointment# {appointmentCounter}: ({appointment.Start} {timeZone}) to ({appointment.End} {timeZone}) \n";
                appointmentCounter++;
            }

            return result;

        }
    }
}
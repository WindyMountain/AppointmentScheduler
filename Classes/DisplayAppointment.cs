using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WendyMonahanC969.Classes
{
    public class DisplayAppointment
    {
        public int AppointmentID { get; set; }
        public string Type { get; set; }

        public int CustomerID { get; set; }

        public string CustomerName { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}

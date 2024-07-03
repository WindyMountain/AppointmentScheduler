using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WendyMonahanC969.Classes
{
    public class Appointment    
    {
        //Int(10) for appointmentID and customerID
        public int appointmentID { get; set; }
        public int customerID { get; set; }

        //Int for userID
        public int userID { get; set; }

        //Varchar(255) for title
        public string title { get; set; }

        //Text for description, location, contact, and type
        public string description { get; set; }
        public string location { get; set; }
        public string contact { get; set; }
        public string type { get; set; }

        //Varchar(255) for url
        public string url { get; set; }

        //DATETIME for start and end
        public string start { get; set; }
        public string end { get; set; }

        //DATETIME for createDate
        public DateTime createDate { get; set; }

        //Varchar(40) for createdBy
        public string createdBy { get; set; }

        //TIMESTAMP for lastUpdate
        public DateTime lastUpdate { get; set; }

        //Varchar(40) for lastUpdateBy
        public string lastUpdateBy { get; set; }
    }
}

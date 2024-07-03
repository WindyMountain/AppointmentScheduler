using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WendyMonahanC969.Classes
{
    public class Customer
    {
        //Int(10) for customerID
        public int customerID { get; set; }

        //Varchar(45) for customerName
        public string customerName { get; set; }

        //Int(10) for addressID
        public int addressID { get; set; }

        //TinyInt(1) for active
        public int active { get; set; }

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

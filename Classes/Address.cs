using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WendyMonahanC969.Classes
{
    public class Address
    {
        //Int(10) for addressID
        public int addressID { get; set; }

        //Varchar(50) for address1 and address2 
        public string address1 { get; set; }
        public string address2 { get; set; }

        //Int(10) for cityID
        public int cityID { get; set; }

        //Varchar(10) for postalCode
        public string postalCode { get; set; }

        //Varchar(20) for phone
        public string phone { get; set; }

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

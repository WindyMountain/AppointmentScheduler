using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WendyMonahanC969.Classes
{
    public class Country
    {
        //Int(10) for countryID
        public int countryID { get; set; }

        //Varchar(50) for country
        public string country { get; set; }

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

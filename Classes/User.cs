using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WendyMonahanC969.Classes
{
    public class User
    {
        //Int for userID
        public int userID { get; set; }

        //Varchar(50) for userName and password
        public string userName { get; set; }
        public string password { get; set; }

        //TinyInt for active
        public int active { get; set; }

        //DATETIME for createDate
        public string createDate { get; set; }

        //Varchar(40) for createdBy
        public string createdBy { get; set; }

        //TIMESTAMP for lastUpdate
        public string lastUpdate { get; set; }

        //Varchar(40) for lastUpdateBy
        public string lastUpdateBy { get; set; }
    }
}

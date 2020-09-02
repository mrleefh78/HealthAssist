using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthAssist.AppClass
{
    public class FacilityModel : BaseModel 
    {
        public string FacilityName { get; set; }
        public string ContactPerson { get; set; }
        public string Designation { get; set; }
        public string FacilityType { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateAccredit { get; set; }
        public DateTime DateExpire { get; set; }
        public string Province { get; set; }
        public double CashBond { get; set; }
        public string StatusID { get; set; }
        public string Notes { get; set; }
    }
}
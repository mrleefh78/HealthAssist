using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthAssist.AppClass
{
    public class InsuranceCompanyModel : BaseModel
    {
        public string Code { get; set; }
        public string CompanyName { get; set; }
        public string ContactPerson { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CountryCode { get; set; }
        public DateTime DateAccredit { get; set; }
        public DateTime DateExpire { get; set; }
    }
}
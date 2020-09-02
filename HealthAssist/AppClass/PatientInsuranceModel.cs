using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthAssist.AppClass
{
    public class PatientInsuranceModel : BaseModel
    {
        public string PatientNo { get; set; }
        public int InsuranceID { get; set; }
        public string PolicyNo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string MembershipType { get; set; }
        public string PrincipalPatientNo { get; set; }
        public string EmployeeNo { get; set; }
        public string Company { get; set; }
        public string Notes { get; set; }
    }
}
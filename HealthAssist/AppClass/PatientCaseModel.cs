using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthAssist.AppClass
{
    public class PatientCaseModel : PatientEncounterBaseModel
    {
  
        public string CaseNo { get; set; }
        public DateTime CaseDate { get; set; }
        public string ServiceType { get; set; }
        public int InsuranceCompanyID { get; set; }
        public string InsuranceNo { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int HospitalID { get; set; }
        public int PhysicianID { get; set; }
        public string Remarks { get; set; }
        public int StatusID { get; set; }
    }
}
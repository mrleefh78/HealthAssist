using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthAssist.AppClass
{
    public class PatientEncounterModel : PatientEncounterBaseModel
    {
        public DateTime EncounterDate { get; set; }
        public string EncounterType { get; set; }
        public string CaseNo { get; set; }
        public int InsuranceCompanyID { get; set; }
        public string InsuranceNo { get; set; }
        public int HospitalID { get; set; }
        public int PhysicianID { get; set; }
        public string Remarks { get; set; }
        public int StatusID { get; set; }
        public int DispositionID { get; set; }
        public int NoOfDays { get; set; }

        public DateTime? FollowUpDate { get; set; }

        public string WorkRestriction { get; set; }

        
    }
}
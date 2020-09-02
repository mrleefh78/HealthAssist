using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthAssist.AppClass
{
    public class PatientAppointmentModel : PatientEncounterBaseModel 
    {
        public string CaseNo { get; set; }     
        public string AppointmentType { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int HospitalID { get; set; }
        public int PhysicianID { get; set; }
        public int StatusID { get; set; }
        public string Remarks { get; set; }
    }
}
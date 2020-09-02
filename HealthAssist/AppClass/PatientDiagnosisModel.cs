using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthAssist.AppClass
{
    public class PatientDiagnosisModel : PatientEncounterBaseModel 
    {
        public string CaseNo { get; set; }
public DateTime StartDate { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
    }
}
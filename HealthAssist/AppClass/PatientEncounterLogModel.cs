using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthAssist.AppClass
{
    public class PatientEncounterLogModel : PatientEncounterBaseModel
    {
        public int StatusID { get; set; }
        public DateTime LogDate { get; set; }
    }
}
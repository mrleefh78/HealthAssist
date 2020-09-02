using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthAssist.AppClass
{
    public class PatientMedicationModel : PatientDiagnosisModel
    {
        public string Dosage { get; set; }

    }
}
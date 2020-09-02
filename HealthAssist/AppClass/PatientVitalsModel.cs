using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthAssist.AppClass
{
    public class PatientVitalsModel: PatientEncounterBaseModel
    {
        public double Temperature { get; set; }
        public double Systolic { get; set; }
        public double Diastolic { get; set; }
        public double PulseRate { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public double BloodSugar { get; set; }
        public string Notes { get; set; }
    }
}
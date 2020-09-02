using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthAssist.AppClass
{
    public class PhysicianPrescriptionTemplateModel: PatientMedicationModel
    {
        public int PhysicianID { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthAssist.AppClass
{
    public class PatientAssessmentModel: PatientEncounterBaseModel
    {
        public string ChiefComplaint { get; set; }
        public string HPI { get; set; }
        public string ROS { get; set; }
        public string PFSC { get; set; }
        public string PhysicalExam { get; set; }
        public string PhysicianNote { get; set; }

    }
}
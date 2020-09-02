using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthAssist.AppClass
{
    public class PatientAttachmentModel : PatientEncounterBaseModel
    {
        public string CaseNo { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }

        public byte BlobFile { get; set; }

        public string Notes { get; set; }
    }
}
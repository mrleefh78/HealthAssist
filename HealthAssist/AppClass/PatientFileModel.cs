using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthAssist.AppClass
{
    public class PatientFileModel : BaseModel
    {
        public string ReferenceNo { get; set; }
        public string PatientNo { get; set; }
        public string SourceModule { get; set; }
        public string FormName { get; set; }
        public string FileName { get; set; }
        public byte SourceFile { get; set; }
        public string Notes { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthAssist.AppClass
{
    public class MedicineModel: BaseModel 
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
    }
}
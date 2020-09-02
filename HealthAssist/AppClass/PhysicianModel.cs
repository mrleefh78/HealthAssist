using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthAssist.AppClass
{
    public class PhysicianModel : BaseModel 
    {
        public string Title { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Suffix { get; set; }
        public string Specialty { get; set; }
        public string LicenseNo { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int HospitalID { get; set; }

        public int UserID { get; set; }

        public double Rate { get; set; }
    }

    public class PhysicianFacilityModel: BaseModel
    {
        public int PhysicianID { get; set; }
        public int HospitalID { get; set; }
    }
}
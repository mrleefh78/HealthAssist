using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthAssist.AppClass
{
    public class InvoiceModel : BaseModel 
    {
        public string InvoiceNo { get; set; }
        public string PatientNo { get; set; }
        public string CaseNo { get; set; }
        public string InsuranceCompanyID { get; set; }        
        public DateTime InvoiceDate { get; set; }
        public decimal Medex { get; set; }
        public decimal CaseFee { get; set; }
        public decimal TotalBilled { get; set; }
        public DateTime DateBilled { get; set; }
        public DateTime DatePaid { get; set; }
        public string Remarks { get; set; }
        public string StatusID { get; set; }
    }
}
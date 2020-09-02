using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthAssist.AppClass
{
    public class TxnClass
    {
       
        #region tblTxnReferrals

        private string sID = string.Empty;
        private DateTime dDate;
        private string sReferralType;
        private string sPatientID;
        private string sStatus;
        private string sReferBy;
        private string sApproveBy;
        private string sNotes;

        private string sAdmitDate;
        private string sDischargeDate;
        private string sPhysician;
      

        public string Physician
        {
            get { return sPhysician; }
            set { sPhysician = value; }
        }

        public string AdmitDate
        {
            get { return sAdmitDate; }
            set { sAdmitDate = value; }
        }

        public string DischargeDate
        {
            get { return sDischargeDate; }
            set { sDischargeDate = value; }
        }

        public string ID
        {
            get { return sID; }
            set { sID = value; }
        }

        public DateTime DOS
        {
            get { return dDate; }
            set { dDate = value; }
        }

        public string ReferralType
        {
            get { return sReferralType; }
            set { sReferralType = value; }
        }

        public string PatientID
        {
            get { return sPatientID; }
            set { sPatientID = value; }
        }

        public string Status
        {
            get { return sStatus; }
            set { sStatus = value; }
        }

        public string ReferBy
        {
            get { return sReferBy; }
            set { sReferBy = value; }
        }

        public string ApproveBy
        {
            get { return sApproveBy; }
            set { sApproveBy = value; }
        }

        public string Notes
        {
            get { return sNotes; }
            set { sNotes = value; }
        }

        #endregion

        #region tblTxnEms

        private string sCallType = string.Empty;
        private string dStartTime;
        private string dEndTime;
        private string sDriver;
        private string sAttendant;
        private DateTime dEnroute;
        private DateTime dOnScene;
        private DateTime dTransporting;
        private DateTime dAtDestination;
        private DateTime dInService;
        private string sCC;
        private string sStretch;

        private byte[] bSign;

        public string CallType
        {
            get { return sCallType; }
            set { sCallType = value; }
        }

        public string StartTime
        {
            get { return dStartTime; }
            set { dStartTime = value; }
        }

        public string EndTime
        {
            get { return dEndTime; }
            set { dEndTime = value; }
        }

        public string Driver
        {
            get { return sDriver; }
            set { sDriver = value; }
        }

        public string Attendant
        {
            get { return sAttendant; }
            set { sAttendant = value; }
        }

        public DateTime Enroute
        {
            get { return dEnroute; }
            set { dEnroute = value; }
        }

        public DateTime OnScene
        {
            get { return dOnScene; }
            set { dOnScene = value; }
        }

        public DateTime Transporting
        {
            get { return dTransporting; }
            set { dTransporting = value; }
        }

        public DateTime AtDestination
        {
            get { return dAtDestination; }
            set { dAtDestination = value; }
        }

        public DateTime InService
        {
            get { return dInService; }
            set { dInService = value; }
        }

        public string CC
        {
            get { return sCC; }
            set { sCC = value; }
        }

        public string Stretcher
        {
            get { return sStretch; }
            set { sStretch = value; }
        }

        #endregion

        #region tblTxnNecessity

        private string sFormName = string.Empty;
        private string sFileName = string.Empty;
        private byte[] bPicture;

        public string FormName
        {
            get { return sFormName; }
            set { sFormName = value; }
        }

        public string FileName
        {
            get { return sFileName; }
            set { sFileName = value; }
        }

        public byte[] SourceFile
        {
            get { return bPicture; }
            set { bPicture = value; }
        }

        public byte[] Sign
        {
            get { return bSign; }
            set { bSign = value; }
        }
     

        #endregion

        #region tblTxnVitalSign

        private string sBP = string.Empty;
        private string sPulse = string.Empty;
        private string sResp = string.Empty;
        private string sPulseOx = string.Empty;
        private string sGlucose = string.Empty;
      

        public string BP
        {
            get { return sBP; }
            set { sBP = value; }
        }

        public string Pulse
        {
            get { return sPulse; }
            set { sPulse = value; }
        }

        public string Resp
        {
            get { return sResp; }
            set { sResp = value; }
        }

        public string PulseOx
        {
            get { return sPulseOx; }
            set { sPulseOx = value; }
        }
        public string Glucose
        {
            get { return sGlucose; }
            set { sGlucose = value; }
        }

       

        #endregion

        #region tblTxnIV

        private string sOxygen = string.Empty;
        private string sLMP = string.Empty;
        private string sDevice = string.Empty;
        private string sGcs = string.Empty;

        private string sWlbs = string.Empty;
        private string sWkls = string.Empty;

        public string Oxygen
        {
            get { return sOxygen; }
            set { sOxygen = value; }
        }

        public string LMP
        {
            get { return sLMP; }
            set { sLMP = value; }
        }

        public string Device
        {
            get { return sDevice; }
            set { sDevice = value; }
        }

        public string Gcs
        {
            get { return sGcs; }
            set { sGcs = value; }
        }

        public string Wlbs
        {
            get { return sWlbs; }
            set { sWlbs = value; }
        }

        public string Wkls
        {
            get { return sWkls; }
            set { sWkls = value; }
        }

        #endregion

        #region tblTxnEmsInsurance

        private string sInsuranceID = string.Empty;
        private string sMedicareNo = string.Empty;
        private string sMedicaidNo = string.Empty;
        private string sPolicyNo = string.Empty;
        private string sGroupNo = string.Empty;
        private string sPhoneNo = string.Empty;

        public string InsuranceID
        {
            get { return sInsuranceID; }
            set { sInsuranceID = value; }
        }

        public string MedicareNo
        {
            get { return sMedicareNo; }
            set { sMedicareNo = value; }
        }

        public string MedicaidNo
        {
            get { return sMedicaidNo; }
            set { sMedicaidNo = value; }
        }

        public string PolicyNo
        {
            get { return sPolicyNo; }
            set { sPolicyNo = value; }
        }

        public string GroupNo
        {
            get { return sGroupNo; }
            set { sGroupNo = value; }
        }

        public string PhoneNo
        {
            get { return sPhoneNo; }
            set { sPhoneNo = value; }
        }

        #endregion

    }
}
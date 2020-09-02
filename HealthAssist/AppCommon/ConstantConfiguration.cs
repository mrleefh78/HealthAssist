using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthAssist.AppCommon
{
    public class ConstantConfiguration
    {
        public ConstantConfiguration()
        {

        }

        #region "Patient"
        public static string TABLE_PATIENT = "patient";
        public static string COLUMN_ID = "id";
        public static string COLUMN_PATIENT_NO = "PatientNo";
        public static string COLUMN_DATE_REG = "DateReg";
        public static string COLUMN_LASTNAME = "LastName";
        public static string COLUMN_FIRSTNAME = "FirstName";
        public static string COLUMN_MIDDLENAME = "MiddleName";
        public static string COLUMN_DOB = "dob";
        public static string COLUMN_GENDER = "gender";
        public static string COLUMN_PHONE = "phone";
        public static string COLUMN_MOBILE = "mobile";
        public static string COLUMN_EMAIL = "email";
        public static string COLUMN_ADDRESS = "address";
        public static string COLUMN_NATIONALITY = "nationality";
        #endregion

        #region "Patient Dependent"
        public static string TABLE_PATIENT_DEPENDENT = "patient_dependent";
        #endregion

        #region "Patient Insurance"
        public static string TABLE_PATIENT_INSURANCE = "patient_insurance";
        public static string COLUMN_INSURANCE_ID = "InsuranceID";
        //public static string COLUMN_START_DATE = "StartDate";
        public static string COLUMN_EXPIRATION_DATE = "ExpirationDate";
        public static string COLUMN_POLICY_NO = "PolicyNo";
        public static string COLUMN_MEMBERSHIP_TYPE = "MembershipType";
        public static string COLUMN_PRINCIPAL_PATIENT_NO = "PrincipalPatientNo";
        public static string COLUMN_EMPLOYEE_NO = "EmployeeNo";
        public static string COLUMN_COMPANY = "CompanyName";
        #endregion

        #region "Patient Case"
        public static string TABLE_PATIENT_CASE = "patient_case";
        public static string COLUMN_CASE_NO = "CaseNo";
        public static string COLUMN_CASE_DATE = "CaseDate";
        public static string COLUMN_TYPE = "ServiceType";
        public static string COLUMN_INSURANCE = "InsuranceCompanyID";
        public static string COLUMN_INSURANCE_NO = "InsuranceNo";
        public static string COLUMN_START_DATE = "StartDate";
        public static string COLUMN_END_DATE = "EndDate";
        public static string COLUMN_PHYSICIAN_ID = "PhysicianID";
        public static string COLUMN_FACILITY_ID = "FacilityID";
        public static string COLUMN_STATUS = "StatusID";
        public static string COLUMN_REMARKS = "Remarks";
        #endregion

        #region "Patient Encounter"
        public static string TABLE_PATIENT_ENCOUNTER = "patient_encounter";
        public static string COLUMN_ENCOUNTER_NO = "EncounterNo";
        public static string COLUMN_ENCOUNTER_DATE = "EncounterDate";
        public static string COLUMN_ENCOUNTER_TYPE = "EncounterType";
        public static string COLUMN_DISPOSITION_ID = "DispositionID";
        public static string COLUMN_REST_DAYS = "RestForDays";
        public static string COLUMN_FOLLOW_UP_DATE = "FollowUpDate";
        public static string COLUMN_WORK_RESTRICTION = "WorkRestriction";
        
        #endregion

        #region "Patient Vitals"
        public static string TABLE_PATIENT_VITALS = "patient_vitals";
        public static string COLUMN_TEMPERATURE = "Temperature";
        public static string COLUMN_SYSTOLIC = "Systolic";
        public static string COLUMN_DIASTOLIC = "Diastolic";
        public static string COLUMN_PULSE_RATE = "PulseRate";
        public static string COLUMN_HEIGHT = "Height";
        public static string COLUMN_WEIGHT = "Weight";
        public static string COLUMN_BLOOD_SUGAR = "BloodSugar";
        #endregion region

        #region "Patient Assessment"
        public static string TABLE_PATIENT_ASSESSMENT = "patient_assessment";
        public static string COLUMN_CHIEF_COMPLAINT = "ChiefComplaint";
        public static string COLUMN_HPI = "HPI";
        public static string COLUMN_ROS = "ROS";
        public static string COLUMN_PFSH = "PFSH";
        public static string COLUMN_PHYSICAL_EXAM = "PhysicalExam";
        public static string COLUMN_PHYSICIAN_NOTE = "PhysicianNote";
        #endregion region

        #region "Patient Appointment"
        public static string TABLE_PATIENT_APPOINTMENT = "patient_appointment";
        public static string COLUMN_APPOINTMENT_DATE = "AppointmentDate";
        public static string COLUMN_APPOINTMENT_TYPE = "AppointmentType";
        #endregion

        #region "Patient Diagnosis"
        public static string TABLE_PATIENT_DIAGNOSIS = "patient_diagnosis";
        public static string COLUMN_CODE = "Code";
        public static string COLUMN_DESCRIPTION = "Description";
        public static string COLUMN_NOTES = "Notes";
        #endregion

        #region "Patient Procedures"
        public static string TABLE_PATENT_PROCEDURE = "patient_cpt";
        #endregion

        #region "Patient Medications"
        public static string TABLE_PATENT_MEDICATION = "patient_meds";
        public static string COLUMN_DOSAGE = "Dosage";
        #endregion

        #region "Patient Encounter Log"
        public static string TABLE_PATENT_ENCOUNTER_LOG = "patient_encounter_log";
        public static string COLUMN_LOG_DATE = "LogDate";
        #endregion

        #region "Patient Files"
        public static string TABLE_PATENT_FORMS = "patient_forms";
        public static string COLUMN_REFERENCE_NO = "ReferenceNo";
        public static string COLUMN_SOURCE_MODULE = "SourceModule";
        public static string COLUMN_FORM_NAME = "FormName";
        public static string COLUMN_FILE_NAME = "FileName";
        public static string COLUMN_SOURCE_FILE= "SourceFile";
        #endregion

        #region "Invoice"
        public static string TABLE_INVOICE = "invoice";
        public static string COLUMN_INVOICE_NO = "InvoiceNo";
        public static string COLUMN_INVOICE_DATE = "InvoiceDate";
        public static string COLUMN_MEDEX = "Medex";
        public static string COLUMN_CASE_FEE = "CaseFee";
        public static string COLUMN_TOTAL_BILLED = "TotalBilled";
        public static string COLUMN_DATE_BILLED = "DateBilled";
        public static string COLUMN_DATE_PAID = "DatePaid";
        #endregion

        #region "Physician"
        public static string TABLE_PHYSICIAN = "physician";
        public static string TABLE_PHYSICIAN_FACILITY = "PhysicianFacility";
        public static string COLUMN_NAME_TITLE = "Title";
        public static string COLUMN_SUFFIX = "Suffix";
        public static string COLUMN_SPECIALTY = "Specialty";
        public static string COLUMN_LICENSE_NO = "LicenseNo";
        public static string COLUMN_USER_ID = "UserID";
        public static string COLUMN_RATE = "rate";

        public static string TABLE_PHYSICIAN_PRESCRIPTION_TEMPLATE = "  physician_prescription_template";
      

        #endregion

        #region "Facility"
        public static string TABLE_FACILITY = "facility";
        public static string COLUMN_FACILITY_NAME = "FacilityName";
        public static string COLUMN_CONTACT_PERSON = "ContactPerson";
        public static string COLUMN_DESIGNATION = "Position";
        public static string COLUMN_FACILITY_TYPE = "FacilityType";
        public static string COLUMN_DATE_ACCREDIT = "DateAccredit";
        public static string COLUMN_DATE_EXPIRE = "DateExpire";
        public static string COLUMN_PROVINCE = "Province";
        public static string COLUMN_CASH_BOND = "CashBond";
        public static string COLUMN_STATUS_ID = "StatusID";
        #endregion

        #region "Insurance Company"
        public static string TABLE_INSURANCE = "insurance_company";
        public static string COLUMN_COMPANY_NAME = "CompanyName";
        public static string COLUMN_COUNTRY_CODE = "countrycode";
        #endregion

        #region "Status"
        public static string TABLE_CASE_STATUS = "lkpstatus";
        public static string TABLE_CONTACT_STATUS = "lkpstatusnetwork";
        public static string TABLE_INVOICE_STATUS = "lkpstatusbill";
        public static string COLUMN_REF_NAME = "dname";
        #endregion

        #region "Country"
        public static string TABLE_COUNTRY = "Country";
        #endregion

        #region "Province"
        public static string TABLE_PROVINCE = "lkpprovinces";
        #endregion

        #region "Medicine"
        public static string TABLE_MEDICINE = "lkpmedlist";
        public static string COLUMN_ITEM_CODE = "code";
        #endregion

        #region "CPT"
        public static string TABLE_CPT = "lkpcpt";
      
        #endregion

        #region "Users"
        public static string TABLE_USERS = "users";
        public static string COLUMN_USER_NAME = "user_name";
        public static string COLUMN_USER_PASSWORD = "user_password";
        public static string COLUMN_ACCOUNT_TYPE = "account_type";

        #endregion

        #region"Disposition"
        public static string TABLE_DISPOSITION = "lkpDispositionList"; 
        #endregion




    }
}
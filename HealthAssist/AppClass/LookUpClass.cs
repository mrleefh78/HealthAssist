using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthAssist.AppClass
{
    class LookUpClass
    {
        #region Patient Profile

        private string _patientID = string.Empty;
        public string PatientID
        {
            get { return _patientID; }
            set { _patientID = value; }
        }

        private DateTime _registrationDate;
        public DateTime RegDate
        {
            get { return _registrationDate; }
            set { _registrationDate = value; }
        }

        private string _lastName = string.Empty;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        private string _firstName = string.Empty;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        private string _middleName = string.Empty;
        public string MiddleName
        {
            get { return _middleName; }
            set { _middleName = value; }
        }
      
        private DateTime _dOB;
        public DateTime DOB
        {
            get { return _dOB; }
            set { _dOB = value; }
        }

        private string _gender = string.Empty;
        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
                
        private string _address = string.Empty;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _city = string.Empty;
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        
        private string _state = string.Empty;
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }
        private string _zip = string.Empty;
        public string Zip
        {
            get { return _zip; }
            set { _zip = value; }
        }
               
        private string _nationality = string.Empty;

        public string Nationality
        {
            get { return _nationality; }
            set { _nationality = value; }
        }

        private string _phone = string.Empty;
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        private string _mobile = string.Empty;
        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }

        private string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _contactPerson = string.Empty;

        private byte[] _picture;
        public byte[] Picture
        {
            get { return _picture; }
            set { _picture = value; }
        }
        private bool _isDeleted = false;
        public bool IsDeleted
        {
            get { return _isDeleted; }
            set { _isDeleted = value; }
        }

        private string _reasonDelete = string.Empty;
        public string ReasonDelete
        {
            get { return _reasonDelete; }
            set { _reasonDelete = value; }
        }





























        #endregion

        #region Insurance

        private string sCompany = string.Empty;
        private string sContactPerson = string.Empty;
        private string sPosition = string.Empty;
       

        public string Company
        {
            get { return sCompany; }
            set { sCompany = value; }
        }

        public string ContactPerson
        {
            get { return sContactPerson; }
            set { sContactPerson = value; }
        }

        public string Position
        {
            get { return sPosition; }
            set { sPosition = value; }
        }
             
        #endregion

        #region Physician

        private string sSpecialty = string.Empty;

        public string Specialty
        {
            get { return sSpecialty; }
            set { sSpecialty = value; }
        }


        #endregion

        #region ref tables

        private string sID = string.Empty;
        private string sCode = string.Empty;
        private string sDesc = string.Empty;

        public string Province { get; set; }
        public string CashBond { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
        public DateTime DateAcc { get; set; }
        public DateTime DateExpire { get; set; }

        public string ID
        {
            get { return sID; }
            set { sID = value; }
        }

        public string Code
        {
            get { return sCode; }
            set { sCode = value; }
        }

        public string Desc
        {
            get { return sDesc; }
            set { sDesc = value; }
        }

      
        #endregion
    }
}

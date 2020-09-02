using System;
using System.Collections.Generic;
////using System.Linq;
using System.Web;

namespace HealthAssist.AppClass
{
    #region UserProfile
    public class UserClass
    {
        private string sUserID = string.Empty;
        private string sFirstName = string.Empty;
        private string sLastName = string.Empty;
        private string sUserEmail = string.Empty;
        private string sUserName = string.Empty;
        private string sPassword = string.Empty;
        private string sAccountType = string.Empty;
        private string sPositionID = string.Empty;
        private bool bIsActive;
        private byte[] bSign;
      
        public string UserID
        {
            get { return sUserID; }
            set { sUserID = value; }
        }

        public string LastName
        {
            get { return sLastName; }
            set { sLastName = value; }
        }

        public string FirstName
        {
            get { return sFirstName; }
            set { sFirstName = value; }
        }

        public string UserEmail
        {
            get { return sUserEmail; }
            set { sUserEmail = value; }
        }

        public string UserName
        {
            get { return sUserName; }
            set { sUserName = value; }
        }

        public string Password
        {
            get { return sPassword; }
            set { sPassword = value; }
        }

        public string AccountType
        {
            get { return sAccountType; }
            set { sAccountType = value; }
        }

      
        public bool IsActive
        {
            get { return bIsActive; }
            set { bIsActive = value; }
        }

        public string PositionID
        {
            get { return sPositionID; }
            set { sPositionID = value; }
        }

        public byte[] Sign
        {
            get { return bSign; }
            set { bSign = value; }
        }
    }
    #endregion
}

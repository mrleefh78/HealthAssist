using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using HealthAssist.AppCommon;
using HealthAssist.AppClass;
using System.Configuration;


namespace HealthAssist.AppDal
{
    public class TxnDAL
    {
        private DALConnectionClass oConnection;
        private MySqlConnection myCon;
        public MySqlDataAdapter myDataAdapter;
        private string strSql;

        public TxnDAL()
        {
            oConnection = new DALConnectionClass();
        }

        public DataSet Select()
        {
            DataSet myDataset = new DataSet();
            myCon = new MySqlConnection();
            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(strSql, myCon);
                    myDataAdapter.Fill(myDataset);
                    return myDataset;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                myDataAdapter = null;
            }
        }

      
        #region tblTxnReferrals
        private static string TABLE_PATIENT = "patientregistry";
        private static string TABLE_STATUS = "lkpStatus";
        private static string TABLE_LOCATION = "lkpfacility";
        private static string TABLE_AMBULANCE = "lkpambulance";
        private static string TABLE_USERS = "users";
        private static string TABLE_PHYSICIAN = "lkpdoctor";
        private static string LOOKTABLE_INSURANCE = "lkpinsurance";
        private static string TABLE_SERVICES = "lkpservices";

        private static string TABLE_TXN_REFERRALS = "txnreferrals";
        private static string COLUMN_TXN_NO = "txn_no";
        private static string COLUMN_TXN_DATE = "txndate";
        private static string COLUMN_REFERRAL_TYPE = "referral_type";
        private static string COLUMN_STATUS = "status";
        private static string COLUMN_PATIENT = "patient_id";
        private static string COLUMN_REFER_BY = "refer_by";
        private static string COLUMN_APPROVE_BY = "approve_by";
        private static string COLUMN_NOTES = "notes";
        private static string COLUMN_PTYPE = "patient_type";
        private static string COLUMN_ADMIT_DATE = "admit_date";
        private static string COLUMN_DISCHARGE_DATE = "discharge_date";
        private static string COLUMN_PHYSICIAN_ID = "physician_id";
            
        public DataSet SelectAllReferrals()
        {

            strSql = "SELECT a.txn_no, a.txndate, a.patient_id, Concat(b.last_name, ', ', b.first_name) as patient_name, b.dob, b.medicaid_no, " +
                " Concat(e.last_name, ', ', e.first_name) as physician," +
                " g.dname as referral_type, a.created_by, c.dname as facility, a.patient_type, d.dname as status, f.company as insurance, f.code as InsCode  " +
                     "FROM " + TABLE_TXN_REFERRALS + " a left outer join " + TABLE_PATIENT + " b on b.id= a.patient_id " +
                      "left outer join " + TABLE_LOCATION + " c on a.refer_by= c.id " +
                      " left outer join " + TABLE_STATUS + " d on d.id= a.status " +
                      " left outer join " + TABLE_PHYSICIAN + " e on e.physician_id= a.physician_id " +
                      " left outer join " + LOOKTABLE_INSURANCE + " f on f.insurance_id= a.insurance_id " +
                       " left outer join " + TABLE_SERVICES + " g on g.id= a.referral_type " +
                    " order by a.txndate desc";

            return Select();
        }

        public DataSet SelectReferralsByID(TxnClass oClass)
        {

            strSql = "SELECT a.txn_no, a.txndate, b.id as patient_id, Concat(b.last_name, ', ', b.first_name) as patient_name,a.status, " +
                "a.referral_type, a.refer_by, a.approve_by, a.created_by, a.notes, a.patient_type, a.physician_id, a.admit_date, a.discharge_date  " +
                     "FROM " + TABLE_TXN_REFERRALS + " a left outer join " + TABLE_PATIENT + " b on b.id= a.patient_id " +
                     " left outer join " + TABLE_STATUS + " c on c.id= a.status " +
                     "WHERE a.txn_no = '" + oClass.ID + "' ";
                  
            return Select();
        }

        public DataSet SelectReferralsByName(TxnClass oClass)
        {

            //strSql = "SELECT a.txn_no, a.txndate, Concat(b.last_name, ', ', b.first_name) as patient_name,a.status, " +
            //    "a.referral_type, c.dname as refer_by, a.approve_by, a.created_by  " +
            //         "FROM " + TABLE_TXN_REFERRALS + " a left outer join " + TABLE_PATIENT + " b on b.id= a.patient_id " +
            //         " left outer join lkpfacility c on c.id = a.refer_by " +
            //         " WHERE Concat(b.last_name, ', ', b.first_name) like '%" + oClass.FileName + "%' " +
            //        " order by a.txndate desc";
               strSql = "SELECT a.txn_no, a.txndate, Concat(b.last_name, ', ', b.first_name) as patient_name,  Concat(e.last_name, ', ', e.first_name) as physician," +
                "g.dname as referral_type, a.created_by, c.dname as facility, a.patient_type, d.dname as status,  f.company as insurance  " +
                     "FROM " + TABLE_TXN_REFERRALS + " a left outer join " + TABLE_PATIENT + " b on b.id= a.patient_id " +
                      "left outer join " + TABLE_LOCATION + " c on a.refer_by= c.id " +
                      " left outer join " + TABLE_STATUS + " d on d.id= a.status " +
                      " left outer join " + TABLE_PHYSICIAN + " e on e.physician_id= a.physician_id " +
                       " left outer join " + LOOKTABLE_INSURANCE + " f on f.insurance_id= a.insurance_id " +
                         " left outer join " + TABLE_SERVICES + " g on g.id= a.referral_type " +
                      " WHERE Concat(b.last_name, ', ', b.first_name) like '%" + oClass.FileName + "%' " +
                    " order by a.txndate desc";

            return Select();
        }

        public DataSet SelectReferralsByCriteria(string fname, string lname, string ssn)
        {

            //strSql = "SELECT a.txn_no, a.txndate, Concat(b.last_name, ', ', b.first_name) as patient_name,a.status, " +
            //    "a.referral_type, c.dname as refer_by, a.approve_by, a.created_by  " +
            //         "FROM " + TABLE_TXN_REFERRALS + " a left outer join " + TABLE_PATIENT + " b on b.id= a.patient_id " +
            //         " left outer join lkpfacility c on c.id = a.refer_by " +
            //         " WHERE Concat(b.last_name, ', ', b.first_name) like '%" + oClass.FileName + "%' " +
            //        " order by a.txndate desc";
            strSql = "SELECT a.txn_no, a.txndate, a.patient_id, Concat(b.last_name, ', ', b.first_name) as patient_name,  Concat(e.last_name, ', ', e.first_name) as physician," +
             "g.dname as referral_type, a.created_by, c.dname as facility, a.patient_type, d.dname as status,  f.company as insurance, f.code as InsCode  " +
                  "FROM " + TABLE_TXN_REFERRALS + " a left outer join " + TABLE_PATIENT + " b on b.id= a.patient_id " +
                   "left outer join " + TABLE_LOCATION + " c on a.refer_by= c.id " +
                   " left outer join " + TABLE_STATUS + " d on d.id= a.status " +
                   " left outer join " + TABLE_PHYSICIAN + " e on e.physician_id= a.physician_id " +
                   " left outer join " + LOOKTABLE_INSURANCE + " f on f.insurance_id= a.insurance_id " +
                   " left outer join " + TABLE_SERVICES + " g on g.id= a.referral_type " +
                   " WHERE 1=1 ";
                 
                   if (fname != "")
            {
                strSql = strSql + "AND b.first_name like '%" +fname+ "%' ";
            }
            if (lname != "")
            {
                strSql = strSql + "AND b.last_name like '%" + lname + "%' ";
            }
            if (ssn != "")
            {
                strSql = strSql + "AND a.txn_no = '" + ssn + "' ";
            }

            return Select();
        }

        public DataSet SelectReferralsByPatID(TxnClass oClass)
        {

            //strSql = "SELECT a.txn_no, a.txndate, Concat(b.last_name, ', ', b.first_name) as patient_name,a.status, " +
            //    "a.referral_type, c.dname as refer_by, a.approve_by, a.created_by  " +
            //         "FROM " + TABLE_TXN_REFERRALS + " a left outer join " + TABLE_PATIENT + " b on b.id= a.patient_id " +
            //         " left outer join lkpfacility c on c.id = a.refer_by " +
            //         " WHERE Concat(b.last_name, ', ', b.first_name) like '%" + oClass.FileName + "%' " +
            //        " order by a.txndate desc";
            strSql = "SELECT a.txn_no, a.txndate, a.patient_id, Concat(b.last_name, ', ', b.first_name) as patient_name,  Concat(e.last_name, ', ', e.first_name) as physician," +
              "g.dname as referral_type, a.created_by, c.dname as facility, a.patient_type, d.dname as status,  f.company as insurance  " +
                   "FROM " + TABLE_TXN_REFERRALS + " a left outer join " + TABLE_PATIENT + " b on b.id= a.patient_id " +
                    "left outer join " + TABLE_LOCATION + " c on a.refer_by= c.id " +
                    " left outer join " + TABLE_STATUS + " d on d.id= a.status " +
                    " left outer join " + TABLE_PHYSICIAN + " e on e.physician_id= a.physician_id " +
                    " left outer join " + LOOKTABLE_INSURANCE + " f on f.insurance_id= a.insurance_id " +
                    " left outer join " + TABLE_SERVICES + " g on g.id= a.referral_type " +
                   " WHERE a.patient_id  = '" + oClass.PatientID  + "' " +
                 " order by a.txndate desc";

            return Select();
        }

        public DataSet SelectReferralsByInsID(TxnClass oClass)
        {

            //strSql = "SELECT a.txn_no, a.txndate, Concat(b.last_name, ', ', b.first_name) as patient_name,a.status, " +
            //    "a.referral_type, c.dname as refer_by, a.approve_by, a.created_by  " +
            //         "FROM " + TABLE_TXN_REFERRALS + " a left outer join " + TABLE_PATIENT + " b on b.id= a.patient_id " +
            //         " left outer join lkpfacility c on c.id = a.refer_by " +
            //         " WHERE Concat(b.last_name, ', ', b.first_name) like '%" + oClass.FileName + "%' " +
            //        " order by a.txndate desc";
            strSql = "SELECT a.txn_no, a.txndate, a.patient_id, Concat(b.last_name, ', ', b.first_name) as patient_name,  Concat(e.last_name, ', ', e.first_name) as physician," +
              "g.dname as referral_type, a.created_by, c.dname as facility, a.patient_type, d.dname as status,  f.company as insurance  " +
                   "FROM " + TABLE_TXN_REFERRALS + " a left outer join " + TABLE_PATIENT + " b on b.id= a.patient_id " +
                    "left outer join " + TABLE_LOCATION + " c on a.refer_by= c.id " +
                    " left outer join " + TABLE_STATUS + " d on d.id= a.status " +
                    " left outer join " + TABLE_PHYSICIAN + " e on e.physician_id= a.physician_id " +
                    " left outer join " + LOOKTABLE_INSURANCE + " f on f.insurance_id= a.insurance_id " +
                    " left outer join " + TABLE_SERVICES + " g on g.id= a.referral_type " +
                   " WHERE a.insurance_id  = '" + oClass.InsuranceID + "' " +
                 " order by a.txndate desc";

            return Select();
        }
             
        public DataSet GetReferralID(string FirstNo)
        {
            strSql = "SELECT right(" + COLUMN_TXN_NO + ",4) " +
                     "FROM " + TABLE_TXN_REFERRALS + " " +
                     "WHERE left(" + COLUMN_TXN_NO + ",8) = '" + FirstNo + "' " +
                     "ORDER BY right(" + COLUMN_TXN_NO + ",4) desc ";

            return Select();
        }

        public DataSet SelectTxnReferralID(TxnClass oClass)
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_TXN_REFERRALS + " " +
                     "WHERE txn_no = '" + oClass.ID + "' ";

            return Select();
        }
      
        public DataSet SearchDataOptions(string trno, string txnDate, string trno2, string loc, string agent, string office, string sender, string ben, string paymethod, string purpose)
        {

            strSql = "SELECT * " +
                     "FROM txnprint " +
                       "WHERE 1 =1 ";

            if (trno != "")
            {
                strSql = strSql + " and txnid = '" + trno + "' " ;
            }
            if (txnDate != "")
            {
                strSql = strSql + " and txdate = '" + Convert.ToDateTime(txnDate).ToString("yyyy-MM-d HH:MM:ss") + "' ";
            }
            if (trno2 != "")
            {
                strSql = strSql + " and txn_no = '" + trno2 + "' ";
            }
            if (loc != "")
            {
                strSql = strSql + " and location = '" + loc + "' ";
            }
            if (agent != "")
            {
                strSql = strSql + " and agent = '" + agent + "' ";
            }
            if (office != "")
            {
                strSql = strSql + " and officename = '" + office + "' ";
            }
            if ((sender != "") && (sender != null))
            {
                strSql = strSql + " and sendername = '" + sender + "' ";
            }
            if (ben != "")
            {
                strSql = strSql + " and benname = '" + ben + "' ";
            }
            if (paymethod != "")
            {
                strSql = strSql + " and pay_method = '" + paymethod + "' ";
            }
            if (purpose != "")
            {
                strSql = strSql + " and reason = '" + purpose + "' ";
            }

            return Select();
        }
       
        public void InsertTxnReferral(string currUser, TxnClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "INSERT INTO " + TABLE_TXN_REFERRALS + " (" +
                        COLUMN_TXN_NO + ", " +
                        COLUMN_TXN_DATE + ", " +
                        COLUMN_REFERRAL_TYPE + ", " +
                        COLUMN_STATUS + ", " +
                        COLUMN_PATIENT + ", " +
                        COLUMN_REFER_BY + ", " +
                        COLUMN_APPROVE_BY + ", " +
                        COLUMN_NOTES + ", " +
                        COLUMN_PTYPE + ", " +
                        COLUMN_ADMIT_DATE + ", " +
                        COLUMN_DISCHARGE_DATE + ", " +
                        COLUMN_PHYSICIAN_ID + ", " +
                         COLUMN_INSURANCE_ID + ", " +
                          "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.ID + "', '" +
                    oClass.DOS.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                    oClass.ReferralType + "', '" +
                    oClass.Status + "', '" +
                    oClass.PatientID + "', '" +
                    oClass.ReferBy + "', '" +
                    oClass.ApproveBy + "', '" +
                    oClass.Notes.Replace("'", "") + "', '" +
                     oClass.CallType  + "', '" +
                     oClass.AdmitDate  + "', '" +
                     oClass.DischargeDate  + "', '" +
                      oClass.Physician  + "', '" +
                        oClass.InsuranceID  + "', '" +
                       currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    ") ";
            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }
        
        public void UpdateTxnReferral(string user, TxnClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "UPDATE " + TABLE_TXN_REFERRALS + " SET " +
                 COLUMN_TXN_DATE + " = '" + oClass.DOS.ToString("yyyy-MM-d HH:MM:ss") + "', " +
                 COLUMN_REFERRAL_TYPE + " = '" + oClass.ReferralType + "', " +
                 COLUMN_STATUS + " = '" + oClass.Status + "', " +
                 COLUMN_PATIENT + " = '" + oClass.PatientID + "', " +
                 COLUMN_REFER_BY + " = '" + oClass.ReferBy + "', " +
                 COLUMN_APPROVE_BY + " = '" + oClass.ApproveBy + "', " +
                 COLUMN_NOTES + " = '" + oClass.Notes.Replace("'", "") + "', " +
                 COLUMN_PTYPE + " = '" + oClass.CallType  + "', " +
                 COLUMN_PHYSICIAN_ID + " = '" + oClass.Physician  + "', " +
                 COLUMN_ADMIT_DATE + " = '" + oClass.AdmitDate  + "', " +
                 COLUMN_DISCHARGE_DATE + " = '" + oClass.DischargeDate  + "', " +
                  COLUMN_INSURANCE_ID + " = '" + oClass.InsuranceID  + "', " +
                 " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_TXN_NO + " = '" + oClass.ID + "' ";


            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void UpdateTxnReferralStatus(string user, TxnClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "UPDATE " + TABLE_TXN_REFERRALS + " SET " +
                 COLUMN_STATUS + " = '" + oClass.Status + "', " +
                 " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_TXN_NO + " = '" + oClass.ID + "' ";


            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void UpdateTxnReferralDischarges(string user, TxnClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "UPDATE " + TABLE_TXN_REFERRALS + " SET " +
                 COLUMN_DISCHARGE_DATE + " = '" + oClass.DischargeDate  + "', " +
                 COLUMN_STATUS + " = '" + oClass.Status + "', " +
                 " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_TXN_NO + " = '" + oClass.ID + "' ";


            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeleteTxnReferral(TxnClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_TXN_REFERRALS + " " +
                    " WHERE " + COLUMN_TXN_NO + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        #endregion

        #region tblTxnEMS
        private static string TABLE_EMS = "txnems";

        private static string COLUMN_TYPE_CALL = "type_call";
        private static string COLUMN_START_TIME = "start_time";
        private static string COLUMN_END_TIME = "end_time";
        private static string COLUMN_DRIVER = "driver";
        private static string COLUMN_ATTENDANT = "attendant";
        private static string COLUMN_ENROUTE = "en_route";
        private static string COLUMN_ONSCENE = "on_scene";
        private static string COLUMN_TRANSPORTING = "transporting";
        private static string COLUMN_ATDESTINATION = "at_destination";
        private static string COLUMN_INSERVICE = "in_service";
        private static string COLUMN_CC = "chief_complaint";
        private static string COLUMN_STRETCH = "stretcher";

        public DataSet SelectAllEms()
        {

            strSql = "SELECT a.txn_no, a.txndate, a.patient_id, Concat(b.last_name, ', ', b.first_name) as patient_name, " +
                "d.dname as Origin, e.dname as Destination, a.attendant, Concat(g.last_name, ', ', g.first_name) as driver, f.dname as Ambulance, a.created_by  " +
                     "FROM " + TABLE_EMS + " a left outer join " + TABLE_PATIENT + " b on b.id= a.patient_id " +
                     "left outer join " + TABLE_LOCATION + " d on a.loc_orig_id = d.id " +
                     "left outer join " + TABLE_LOCATION + " e on a.loc_des_id = e.id  " +
                      "left outer join " + TABLE_USERS + " g on g.user_id = a.driver  " +
                     "left outer join " + TABLE_AMBULANCE + " f on a.ambulance_id = f.id  order by a.txndate desc";

            return Select();
        }

        public DataSet SelectAllEmsByDte(DateTime dfr, DateTime dto)
        {
            strSql = "SELECT a.txn_no, a.txndate, a.patient_id, Concat(b.last_name, ', ', b.first_name) as patient_name, " +
               "d.dname as Origin, e.dname as Destination, a.attendant, Concat(g.last_name, ', ', g.first_name) as driver, f.dname as Ambulance, a.created_by  " +
                    "FROM " + TABLE_EMS + " a left outer join " + TABLE_PATIENT + " b on b.id= a.patient_id " +
                    "left outer join " + TABLE_LOCATION + " d on a.loc_orig_id = d.id " +
                    "left outer join " + TABLE_LOCATION + " e on a.loc_des_id = e.id  " +
                     "left outer join " + TABLE_USERS + " g on g.user_id = a.driver  " +
                    "left outer join " + TABLE_AMBULANCE + " f on a.ambulance_id = f.id  " +
                      " WHERE a.txndate >= '" + dfr.ToString("yyyy-MM-dd ") + "' " +
                    " AND a.txndate <= '" + dto.ToString("yyyy-MM-dd ") + "'  ";
              


            //strSql = "SELECT a.txn_no, a.txndate, (b.last_name + ', ' + b.first_name) as patient_name, b.id as patient_id, " +
            //    "d.dname as Origin, e.dname as Destination, a.attendant, f.dname as Ambulance,(g.last_name + ', ' + g.first_name) as driver, a.created_by  " +
            //         "FROM (((((" + TABLE_EMS + " a left outer join " + TABLE_PATIENT + " b on b.id= a.patient_id) " +
            //         "left outer join " + TABLE_LOCATION + " d on a.loc_orig_id = d.id) " +
            //         "left outer join " + TABLE_LOCATION + " e on a.loc_des_id = e.id)  " +
            //          "left outer join " + TABLE_AMBULANCE + " f on a.ambulance_id = f.id) " +
            //         "left outer join " + TABLE_USERS + " g on a.driver = g.user_id)  " +
            //             " WHERE a.txndate >= '" + dfr.ToString("yyyy-MM-dd ") + "' " +
            //        " AND a.txndate <= '" + dto.ToString("yyyy-MM-dd ") + "'  ";

            //if (lname != "")
            //{
            //    strSql = strSql + " and b.last_name like '" + lname + "' ";
            //}

            //if (fname != "")
            //{
            //    strSql = strSql + " and b.first_name like '" + fname + "' ";
            //}

            strSql = strSql + "  order by a.txndate desc ";


            //strSql = "SELECT a.txn_no, a.txndate, (b.last_name + ', ' + b.first_name) as patient_name " +
            //         "FROM " + TABLE_EMS + " a left outer join " + TABLE_PATIENT + " b on b.id= a.patient_id ";


            return Select();
        }

        public DataSet SelectAllEmsByPatNAme(string lname, string fname)
        {

            strSql = "SELECT a.txn_no, a.txndate, a.patient_id, Concat(b.last_name, ', ', b.first_name) as patient_name, " +
               "d.dname as Origin, e.dname as Destination, a.attendant, Concat(g.last_name, ', ', g.first_name) as driver, f.dname as Ambulance, a.created_by  " +
                    "FROM " + TABLE_EMS + " a left outer join " + TABLE_PATIENT + " b on b.id= a.patient_id " +
                    "left outer join " + TABLE_LOCATION + " d on a.loc_orig_id = d.id " +
                    "left outer join " + TABLE_LOCATION + " e on a.loc_des_id = e.id  " +
                     "left outer join " + TABLE_USERS + " g on g.user_id = a.driver  " +
                    "left outer join " + TABLE_AMBULANCE + " f on a.ambulance_id = f.id  " +
                    " WHERE 1=1 ";

            //strSql = "SELECT a.txn_no, a.txndate, (b.last_name + ', ' + b.first_name) as patient_name, b.id as patient_id, " +
            //    "d.dname as Origin, e.dname as Destination, a.attendant, f.dname as Ambulance,(g.last_name + ', ' + g.first_name) as driver, a.created_by  " +
            //         "FROM (((((" + TABLE_EMS + " a left outer join " + TABLE_PATIENT + " b on b.id= a.patient_id) " +
            //         "left outer join " + TABLE_LOCATION + " d on a.loc_orig_id = d.id) " +
            //         "left outer join " + TABLE_LOCATION + " e on a.loc_des_id = e.id)  " +
            //          "left outer join " + TABLE_AMBULANCE + " f on a.ambulance_id = f.id) " +
            //         "left outer join " + TABLE_USERS + " g on a.driver = g.user_id)  " +
            //             " WHERE 1=1 ";

            if (lname != "")
            {
                strSql = strSql + " and b.last_name like '%" + lname + "%' ";
            }

            if (fname != "")
            {
                strSql = strSql + " and b.first_name like '%" + fname + "%' ";
            }

            strSql = strSql + "  order by a.txndate desc ";


            //strSql = "SELECT a.txn_no, a.txndate, (b.last_name + ', ' + b.first_name) as patient_name " +
            //         "FROM " + TABLE_EMS + " a left outer join " + TABLE_PATIENT + " b on b.id= a.patient_id ";


            return Select();
        }

        public DataSet SelectAllTxEmsByLocationOrigin(TxnClass oClass)
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_EMS + " a left outer join " + TABLE_PATIENT + " b on b.id= a.patient_id " +
                     "left outer join " + TABLE_STATUS + " c on c.id= a.status_id left outer join " + TABLE_LOCATION + " d on a.loc_orig_id = d.id " +
                     "left outer join " + TABLE_LOCATION + " e on a.loc_des_id = e.id  " +
                       "WHERE d.dname like '%" + oClass.ReferBy + "%' order by a.txndate desc";

            return Select();
        }

        public DataSet SelectAllTxEmsByLocationDestiny(TxnClass oClass)
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_EMS + " a left outer join " + TABLE_PATIENT + " b on b.id= a.patient_id " +
                     "left outer join " + TABLE_STATUS + " c on c.id= a.status_id left outer join " + TABLE_LOCATION + " d on a.loc_orig_id = d.id " +
                     "left outer join " + TABLE_LOCATION + " e on a.loc_des_id = e.id  " +
                       "WHERE e.dname like '%" + oClass.ReferBy + "%' order by a.txndate desc";

            return Select();
        }

        public DataSet GetEmsID(string FirstNo)
        {
            strSql = "SELECT right(" + COLUMN_TXN_NO + ",4) " +
                     "FROM " + TABLE_EMS + " " +
                     "WHERE left(" + COLUMN_TXN_NO + ",8) = '" + FirstNo + "' " +
                     "ORDER BY right(" + COLUMN_TXN_NO + ",4) desc ";

            return Select();
        }

        public DataSet SelectTxnEmsByPatientID(TxnClass oClass)
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_EMS + " " +
                     "WHERE patient_id = '" + oClass.PatientID + "' ";

            return Select();
        }

        public DataSet SelectTxnEmsID(TxnClass oClass)
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_EMS + " " +
                     "WHERE txn_no = '" + oClass.ID + "' ";

            return Select();
        }

        public DataSet SearchDataOption(string trno, string txnDate, string trno2, string loc, string agent, string office, string sender, string ben, string paymethod, string purpose)
        {

            strSql = "SELECT * " +
                     "FROM txnprint " +
                       "WHERE 1 =1 ";

            if (trno != "")
            {
                strSql = strSql + " and txnid = '" + trno + "' ";
            }
            if (txnDate != "")
            {
                strSql = strSql + " and txdate = '" + Convert.ToDateTime(txnDate).ToString("yyyy-MM-d HH:MM:ss") + "' ";
            }
            if (trno2 != "")
            {
                strSql = strSql + " and txn_no = '" + trno2 + "' ";
            }
            if (loc != "")
            {
                strSql = strSql + " and location = '" + loc + "' ";
            }
            if (agent != "")
            {
                strSql = strSql + " and agent = '" + agent + "' ";
            }
            if (office != "")
            {
                strSql = strSql + " and officename = '" + office + "' ";
            }
            if ((sender != "") && (sender != null))
            {
                strSql = strSql + " and sendername = '" + sender + "' ";
            }
            if (ben != "")
            {
                strSql = strSql + " and benname = '" + ben + "' ";
            }
            if (paymethod != "")
            {
                strSql = strSql + " and pay_method = '" + paymethod + "' ";
            }
            if (purpose != "")
            {
                strSql = strSql + " and reason = '" + purpose + "' ";
            }

            return Select();
        }

        public void InsertTxnEms(string currUser, TxnClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "INSERT INTO " + TABLE_EMS + " (" +
                        COLUMN_TXN_NO + ", " +
                        COLUMN_TXN_DATE + ", " +
                        COLUMN_TYPE_CALL + ", " +
                        COLUMN_START_TIME + ", " +
                        COLUMN_END_TIME + ", " +
                        COLUMN_DRIVER + ", " +
                        COLUMN_ATTENDANT + ", " +
                        COLUMN_ENROUTE + ", " +
                        COLUMN_ONSCENE + ", " +
                        COLUMN_TRANSPORTING + ", " +
                        COLUMN_ATDESTINATION + ", " +
                        COLUMN_INSERVICE + ", " +
                        COLUMN_PATIENT + ", " +
                        COLUMN_CC + ", " +
                        COLUMN_NOTES + ", " +
                          "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.ID + "', '" +
                    oClass.DOS.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                    oClass.CallType + "', '" +
                    oClass.StartTime + "', '" +
                    oClass.EndTime + "', '" +
                    oClass.Driver + "', '" +
                    oClass.Attendant + "', '" +
                    oClass.Enroute.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                    oClass.OnScene.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                    oClass.Transporting.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                    oClass.AtDestination.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                    oClass.InService.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                    oClass.PatientID + "', '" +
                    oClass.CC.Replace("'", "") + "', '" +
                    oClass.Notes.Replace("'", "") + "', '" +
                       currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    ") ";
            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void InsertTxnEms1(string currUser, TxnClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "INSERT INTO " + TABLE_EMS + " (" +
                        COLUMN_TXN_NO + ", " +
                        COLUMN_TXN_DATE + ", " +
                        COLUMN_TYPE_CALL + ", " +
                        COLUMN_START_TIME + ", " +
                        COLUMN_END_TIME + ", " +
                        COLUMN_DRIVER + ", " +
                        COLUMN_ATTENDANT + ", " +
                        COLUMN_ENROUTE + ", " +
                        COLUMN_ONSCENE + ", " +
                        COLUMN_TRANSPORTING + ", " +
                        COLUMN_ATDESTINATION + ", " +
                        COLUMN_INSERVICE + ", " +
                        COLUMN_PATIENT + ", " +
                        COLUMN_CC + ", " +
                        COLUMN_STRETCH + ", " +
                        COLUMN_NOTES + ", " +
                          "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.ID + "', '" +
                    oClass.DOS.ToString("yyyy-MM-dd HH:MM:ss") + "', '" +
                    oClass.CallType + "', '" +
                    oClass.StartTime + "', '" +
                    oClass.EndTime + "', '" +
                    oClass.Driver + "', '" +
                    oClass.Attendant + "', '" +
                    oClass.Enroute.ToString("yyyy-MM-dd HH:MM:ss") + "', '" +
                    oClass.OnScene.ToString("yyyy-MM-dd HH:MM:ss") + "', '" +
                    oClass.Transporting.ToString("yyyy-MM-dd HH:MM:ss") + "', '" +
                    oClass.AtDestination.ToString("yyyy-MM-dd HH:MM:ss") + "', '" +
                    oClass.InService.ToString("yyyy-MM-dd HH:MM:ss") + "', '" +
                    oClass.PatientID + "', '" +
                    oClass.CC.Replace("'", "") + "', '" +
                    oClass.Stretcher.Replace("'", "") + "', '" +
                    oClass.Notes.Replace("'", "") + "', '" +
                      currUser + "', '" +
                     DateTime.Today.ToString("yyyy-MM-dd HH:MM:ss") + "', '" +
                    currUser + "', '" +
                   DateTime.Today.ToString("yyyy-MM-dd HH:MM:ss") + "' " +
                    ") ";
            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void UpdateTxnEms(string user, TxnClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "UPDATE " + TABLE_EMS + " SET " +
                 COLUMN_TXN_DATE + " = '" + oClass.DOS.ToString("yyyy-MM-d HH:MM:ss") + "', " +
                 COLUMN_TYPE_CALL + " = '" + oClass.CallType + "', " +
                 COLUMN_START_TIME + " = '" + oClass.StartTime + "', " +
                 COLUMN_END_TIME + " = '" + oClass.EndTime + "', " +
                 COLUMN_DRIVER + " = '" + oClass.Driver + "', " +
                 COLUMN_ATTENDANT + " = '" + oClass.AtDestination + "', " +
                 COLUMN_ENROUTE + " = '" + oClass.Enroute.ToString("yyyy-MM-d HH:MM:ss") + "', " +
                 COLUMN_ONSCENE + " = '" + oClass.OnScene.ToString("yyyy-MM-d HH:MM:ss") + "', " +
                 COLUMN_TRANSPORTING + " = '" + oClass.Transporting.ToString("yyyy-MM-d HH:MM:ss") + "', " +
                 COLUMN_ATDESTINATION + " = '" + oClass.AtDestination.ToString("yyyy-MM-d HH:MM:ss") + "', " +
                 COLUMN_INSERVICE + " = '" + oClass.InService.ToString("yyyy-MM-d HH:MM:ss") + "', " +
                 COLUMN_PATIENT + " = '" + oClass.PatientID + "', " +
                 COLUMN_CC + " = '" + oClass.CC.Replace("'", "") + "', " +
                 COLUMN_NOTES + " = '" + oClass.Notes.Replace("'", "") + "', " +
                 " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_TXN_NO + " = '" + oClass.ID + "' ";


            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void UpdateTxnEmsStatus(string user, TxnClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "UPDATE " + TABLE_EMS + " SET " +
                 COLUMN_STATUS + " = '" + oClass.Status + "', " +
                 " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_TXN_NO + " = '" + oClass.ID + "' ";


            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeleteTxnEms(TxnClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_EMS + " " +
                    " WHERE " + COLUMN_TXN_NO + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        #endregion

        #region tblTxnNecessity
        private static string TABLE_NECESSITY = "txnforms";
        private static string COLUMN_SOURCE = "source_file";
        private static string COLUMN_FORMNAME = "dname";
        private static string COLUMN_FILENAME = "file_name";

        public DataSet SelectAllNecessity()
        {

            strSql = "SELECT a.id, a.dname, a.file_name, a.notes, Concat(b.last_name, ', ', b.first_name) as patient_name " +
                  "FROM " + TABLE_NECESSITY + " a left outer join " + TABLE_PATIENT + " b on b.id= a.patient_id ";

            return Select();
        }

        public DataSet SelectAllNecessityByPatID(TxnClass oClass)
        {

            strSql = "SELECT a.id, a.dname, a.file_name, a.notes, Concat(b.last_name, ', ', b.first_name) as patient_name " +
                  "FROM " + TABLE_NECESSITY + " a left outer join " + TABLE_PATIENT + " b on b.id= a.patient_id " +
                    "WHERE a." + COLUMN_PATIENT + " = '" + oClass.PatientID + "' ";

            return Select();
        }

        public DataSet SelectAllNecessityByPatIDTxNo(TxnClass oClass)
        {

            strSql = "SELECT a.id, a.dname, a.file_name, a.notes, Concat(b.last_name, ', ', b.first_name) as patient_name " +
                  "FROM " + TABLE_NECESSITY + " a left outer join " + TABLE_PATIENT + " b on b.id= a.patient_id " +
                    "WHERE a." + COLUMN_PATIENT + " = '" + oClass.PatientID + "' " +
                     "AND a." + COLUMN_TXN_NO + " = '" + oClass.ID  + "' ";

            return Select();
        }

        public DataSet SelectAllNecessityByPat(TxnClass oClass)
        {

            strSql = "SELECT  a.*, (b.last_name + ', ' + b.first_name) as patient_name " +
                  "FROM " + TABLE_NECESSITY + " a left outer join " + TABLE_PATIENT + " b on b.id= a.patient_id " +
                   "WHERE a." + COLUMN_PATIENT + " = '" + oClass.PatientID + "' ";

            return Select();
        }

        public DataSet SelectAllNecessityByLocationOrigin(TxnClass oClass)
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_NECESSITY + " a left outer join " + TABLE_PATIENT + " b on b.id= a.patient_id " +
                     "left outer join " + TABLE_STATUS + " c on c.id= a.status_id left outer join " + TABLE_LOCATION + " d on a.loc_orig_id = d.id " +
                     "left outer join " + TABLE_LOCATION + " e on a.loc_des_id = e.id  " +
                       "WHERE d.dname like '%" + oClass.ReferBy + "%' order by a.txndate desc";

            return Select();
        }

        public DataSet SelectAllTxNecessityByLocationDestiny(TxnClass oClass)
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_NECESSITY + " a left outer join " + TABLE_PATIENT + " b on b.id= a.patient_id " +
                     "left outer join " + TABLE_STATUS + " c on c.id= a.status_id left outer join " + TABLE_LOCATION + " d on a.loc_orig_id = d.id " +
                     "left outer join " + TABLE_LOCATION + " e on a.loc_des_id = e.id  " +
                       "WHERE e.dname like '%" + oClass.ReferBy + "%' order by a.txndate desc";

            return Select();
        }

        public DataSet GetNecessityID(string FirstNo)
        {
            strSql = "SELECT right(" + COLUMN_TXN_NO + ",4) " +
                     "FROM " + TABLE_NECESSITY + " " +
                     "WHERE left(" + COLUMN_TXN_NO + ",8) = '" + FirstNo + "' " +
                     "ORDER BY right(" + COLUMN_TXN_NO + ",4) desc ";

            return Select();
        }

        public DataSet SelectNecessityID(TxnClass oClass)
        {

            strSql = "SELECT a.*, (b.last_name + ', ' + b.first_name) as patient_name " +
                    "FROM " + TABLE_NECESSITY + " a left outer join " + TABLE_PATIENT + " b on b.id= a.patient_id " +
                     "WHERE a.id = " + oClass.ID + " ";

            return Select();
        }

        public DataSet SelectNecessityByEmsID(TxnClass oClass)
        {

            strSql = "SELECT a.dname, a.file_name, a.notes, (b.last_name + ', ' + b.first_name) as patient_name " +
                    "FROM " + TABLE_NECESSITY + " a left outer join " + TABLE_PATIENT + " b on b.id= a.patient_id " +
                     "WHERE a.txn_no = '" + oClass.ID + "' ";

            return Select();
        }

        public DataSet SearchNecessityDataOptions(string trno, string txnDate, string trno2, string loc, string agent, string office, string sender, string ben, string paymethod, string purpose)
        {

            strSql = "SELECT * " +
                     "FROM txnprint " +
                       "WHERE 1 =1 ";

            if (trno != "")
            {
                strSql = strSql + " and txnid = '" + trno + "' ";
            }
            if (txnDate != "")
            {
                strSql = strSql + " and txdate = '" + Convert.ToDateTime(txnDate).ToString("yyyy-MM-d HH:MM:ss") + "' ";
            }
            if (trno2 != "")
            {
                strSql = strSql + " and txn_no = '" + trno2 + "' ";
            }
            if (loc != "")
            {
                strSql = strSql + " and location = '" + loc + "' ";
            }
            if (agent != "")
            {
                strSql = strSql + " and agent = '" + agent + "' ";
            }
            if (office != "")
            {
                strSql = strSql + " and officename = '" + office + "' ";
            }
            if ((sender != "") && (sender != null))
            {
                strSql = strSql + " and sendername = '" + sender + "' ";
            }
            if (ben != "")
            {
                strSql = strSql + " and benname = '" + ben + "' ";
            }
            if (paymethod != "")
            {
                strSql = strSql + " and pay_method = '" + paymethod + "' ";
            }
            if (purpose != "")
            {
                strSql = strSql + " and reason = '" + purpose + "' ";
            }

            return Select();
        }

        public void InsertNecessity(string currUser, TxnClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "INSERT INTO " + TABLE_NECESSITY + " (" +
                        COLUMN_TXN_NO + ", " +
                        COLUMN_PATIENT + ", " +
                        COLUMN_SOURCE + ", " +
                        COLUMN_FORMNAME + ", " +
                        COLUMN_FILENAME + ", " +
                        COLUMN_NOTES + ", " +
                          "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.ID + "', '" +
                    oClass.PatientID + "', " +
                    "@image" + ", '" +
                    oClass.FormName + "', '" +
                    oClass.FileName + "', '" +
                    oClass.Notes.Replace("'", "") + "', '" +
                    currUser + "', '" +
                     DateTime.Today.ToString("yyyy-MM-dd") + "', '" +
                    currUser + "', '" +
                   DateTime.Today.ToString("yyyy-MM-dd") + "' " +
                    ") ";
            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    MySqlParameter param = cmd.Parameters.Add("@image", MySqlDbType.Blob);
                    param.Value = oClass.SourceFile;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        //public void InsertNecessityServer(string currUser, TxnClass oClass)
        //{
        //    MySqlCommand cmd = new MySqlCommand();

        //    strSql = "INSERT INTO " + TABLE_NECESSITY + " (" +
        //                 COLUMN_TXN_NO + ", " +
        //                 COLUMN_PATIENT + ", " +
        //                 COLUMN_SOURCE + ", " +
        //                 COLUMN_FORMNAME + ", " +
        //                 COLUMN_FILENAME + ", " +
        //                 COLUMN_NOTES + ", " +
        //                   "created_by, created_date, updated_by, updated_date) ";
        //    strSql = strSql + "values ('" +
        //            oClass.ID + "', '" +
        //            oClass.PatientID + "', " +
        //            "@image" + ", '" +
        //            oClass.FormName + "', '" +
        //            oClass.FileName + "', '" +
        //            oClass.Notes.Replace("'", "") + "', '" +
        //            currUser + "', '" +
        //            "CurDate(), '" +
        //            currUser + "', " +
        //            "CurDate() " +
        //            ") ";
        //    try
        //    {
        //        if (oConnection.OpenMySQLConnection())
        //        {
        //            myCon2 = oConnection.ConnectionObject2;
        //            MySqlParameter param = cmd.Parameters.Add("@image", MySqlDbType.LongBlob);
        //            param.Value = oClass.SourceFile;
        //            cmd.Connection = myCon2;
        //            cmd.CommandText = strSql;
        //            cmd.ExecuteNonQuery();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        if (myCon2.State == ConnectionState.Open)
        //        {
        //            myCon2.Close();
        //        }
        //        myCon2.Dispose();
        //        cmd.Dispose();
        //    }
        //}

        public void UpdateNecessity(string user, TxnClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "UPDATE " + TABLE_NECESSITY + " SET " +
                 COLUMN_PATIENT + " = '" + oClass.PatientID + "', " +
                 COLUMN_SOURCE + " = @image, " +
                 COLUMN_FORMNAME + " = '" + oClass.FormName + "', " +
                 COLUMN_FILENAME + " = '" + oClass.FileName + "', " +
                 COLUMN_NOTES + " = '" + oClass.Notes.Replace("'", "") + "', " +
                 " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE id = '" + oClass.ID + "' ";


            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    MySqlParameter param = cmd.Parameters.Add("@image", MySqlDbType.Blob);
                    param.Value = oClass.SourceFile;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }


        public void DeleteNecessity(TxnClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_NECESSITY + " " +
                    " WHERE id = " + oClass.ID + " ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        #endregion

        #region tblTxnVital
        private static string TABLE_VITAL = "txnems_vital";
        private static string COLUMN_TIME = "Time_";
        private static string COLUMN_BP = "bp";
        private static string COLUMN_PULSE = "pulse";
        private static string COLUMN_RESP = "resp";
        private static string COLUMN_PULSEOX = "pulseox";
        private static string COLUMN_GLUCOSE = "glucose";

        public DataSet SelectAllVital()
        {

            strSql = "SELECT * " +
                  "FROM " + TABLE_VITAL + " ";

            return Select();
        }

        public DataSet SelectAllVitalByEms(TxnClass oClass)
        {

            strSql = "SELECT  * " +
                  "FROM " + TABLE_VITAL + " " +
                   "WHERE " + COLUMN_TXN_NO + " = '" + oClass.ID + "' ";

            return Select();
        }

        public void InsertVital(string currUser, TxnClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "INSERT INTO " + TABLE_VITAL + " (" +
                        COLUMN_TXN_NO + ", " +
                        COLUMN_TIME + ", " +
                        COLUMN_BP + ", " +
                        COLUMN_PULSE + ", " +
                        COLUMN_RESP + ", " +
                         COLUMN_PULSEOX + ", " +
                        COLUMN_GLUCOSE + ", " +
                        COLUMN_NOTES + ", " +
                          "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.ID + "', '" +
                    oClass.DOS.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                    oClass.BP + "', '" +
                    oClass.Pulse + "', '" +
                    oClass.Resp + "', '" +
                     oClass.PulseOx + "', '" +
                      oClass.Glucose + "', '" +
                    oClass.Notes.Replace("'", "") + "', '" +
                    currUser + "', '" +
                     DateTime.Today + "', '" +
                    currUser + "', '" +
                   DateTime.Today + "' " +
                    ") ";
            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        //public void InsertVitalServer(string currUser, TxnClass oClass)
        //{
        //    MySqlCommand cmd = new MySqlCommand();

        //    strSql = "INSERT INTO " + TABLE_VITAL + " (" +
        //                 COLUMN_TXN_NO + ", " +
        //                 COLUMN_TIME + ", " +
        //                 COLUMN_BP + ", " +
        //                 COLUMN_PULSE + ", " +
        //                 COLUMN_RESP + ", " +
        //                 COLUMN_PULSEOX + ", " +
        //                 COLUMN_GLUCOSE + ", " +
        //                 COLUMN_NOTES + ", " +
        //                   "created_by, created_date, updated_by, updated_date) ";
        //    strSql = strSql + "values ('" +
        //            oClass.ID + "', '" +
        //            oClass.DOS.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
        //            oClass.BP + "', '" +
        //            oClass.Pulse + "', '" +
        //            oClass.Resp + "', '" +
        //            oClass.PulseOx + "', '" +
        //            oClass.Glucose + "', '" +
        //            oClass.Notes.Replace("'", "") + "', '" +
        //            currUser + "', '" +
        //            "CurDate(), '" +
        //            currUser + "', " +
        //            "CurDate() " +
        //            ") ";
        //    try
        //    {
        //        if (oConnection.OpenMySQLConnection())
        //        {
        //            myCon2 = oConnection.ConnectionObject2;
        //            cmd.Connection = myCon2;
        //            cmd.CommandText = strSql;
        //            cmd.ExecuteNonQuery();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        if (myCon2.State == ConnectionState.Open)
        //        {
        //            myCon2.Close();
        //        }
        //        myCon2.Dispose();
        //        cmd.Dispose();
        //    }
        //}

        public void UpdateVital(string user, TxnClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "UPDATE " + TABLE_VITAL + " SET " +
                 COLUMN_TIME + " = '" + oClass.DOS.ToString("yyyy-MM-d HH:MM:ss") + "', " +
                 COLUMN_BP + " = '" + oClass.BP + "', " +
                 COLUMN_PULSE + " = '" + oClass.Pulse + "', " +
                 COLUMN_RESP + " = '" + oClass.Resp + "', " +
                 COLUMN_PULSEOX + " = '" + oClass.PulseOx + "', " +
                 COLUMN_GLUCOSE + " = '" + oClass.Glucose + "', " +
                 COLUMN_NOTES + " = '" + oClass.Notes.Replace("'", "") + "', " +
                 " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE id = '" + oClass.ID + "' ";


            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeleteVitalByEMS(TxnClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_VITAL + " " +
                      "WHERE " + COLUMN_TXN_NO + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeleteVital(TxnClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_VITAL + " " +
                    " WHERE id = " + oClass.ID + " ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        #endregion

        #region tblTxnIV
        private static string TABLE_IV = "txnems_iv";
        private static string COLUMN_OXYGEN = "oxygen";
        private static string COLUMN_LMP = "lmp";
        private static string COLUMN_DEVICE = "device";
        private static string COLUMN_GCS = "gcs";
        private static string COLUMN_WLBS = "wlbs";
        private static string COLUMN_WKLS = "wkls";

        public DataSet SelectAllIV()
        {

            strSql = "SELECT * " +
                  "FROM " + TABLE_IV + " ";

            return Select();
        }

        public DataSet SelectAllIVByEms(TxnClass oClass)
        {

            strSql = "SELECT  * " +
                  "FROM " + TABLE_IV + " " +
                   "WHERE " + COLUMN_TXN_NO + " = '" + oClass.ID + "' ";

            return Select();
        }

        public void InsertIV(string currUser, TxnClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "INSERT INTO " + TABLE_IV + " (" +
                        COLUMN_TXN_NO + ", " +
                        COLUMN_OXYGEN + ", " +
                        COLUMN_LMP + ", " +
                        COLUMN_DEVICE + ", " +
                        COLUMN_GCS + ", " +
                        COLUMN_WLBS + ", " +
                        COLUMN_WKLS + ", " +
                        COLUMN_NOTES + ", " +
                          "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.ID + "', '" +
                    oClass.Oxygen + "', '" +
                    oClass.LMP + "', '" +
                    oClass.Device + "', '" +
                    oClass.Gcs + "', '" +
                    oClass.Wlbs + "', '" +
                    oClass.Wkls + "', '" +
                    oClass.Notes.Replace("'", "") + "', '" +
                    currUser + "', '" +
                     DateTime.Today + "', '" +
                    currUser + "', '" +
                   DateTime.Today + "' " +
                    ") ";
            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        //public void InsertIVServer(string currUser, TxnClass oClass)
        //{
        //    MySqlCommand cmd = new MySqlCommand();

        //    strSql = "INSERT INTO " + TABLE_IV + " (" +
        //                COLUMN_TXN_NO + ", " +
        //                COLUMN_OXYGEN + ", " +
        //                COLUMN_LMP + ", " +
        //                COLUMN_DEVICE + ", " +
        //                COLUMN_GCS + ", " +
        //                COLUMN_WLBS + ", " +
        //                COLUMN_WKLS + ", " +
        //                COLUMN_NOTES + ", " +
        //                  "created_by, created_date, updated_by, updated_date) ";
        //    strSql = strSql + "values ('" +
        //            oClass.ID + "', '" +
        //            oClass.Oxygen + "', '" +
        //            oClass.LMP + "', '" +
        //            oClass.Device + "', '" +
        //            oClass.Gcs + "', '" +
        //            oClass.Wlbs + "', '" +
        //            oClass.Wkls + "', '" +
        //            oClass.Notes.Replace("'", "") + "', '" +
        //            currUser + "', '" +
        //            "CurDate(), '" +
        //            currUser + "', " +
        //            "CurDate() " +
        //            ") ";
        //    try
        //    {
        //        if (oConnection.OpenMySQLConnection())
        //        {
        //            myCon2 = oConnection.ConnectionObject2;
        //            cmd.Connection = myCon2;
        //            cmd.CommandText = strSql;
        //            cmd.ExecuteNonQuery();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        if (myCon2.State == ConnectionState.Open)
        //        {
        //            myCon2.Close();
        //        }
        //        myCon2.Dispose();
        //        cmd.Dispose();
        //    }
        //}

        public void UpdateIV(string user, TxnClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "UPDATE " + TABLE_IV + " SET " +
                 COLUMN_OXYGEN + " = '" + oClass.Oxygen + "', " +
                 COLUMN_LMP + " = '" + oClass.LMP + "', " +
                 COLUMN_DEVICE + " = '" + oClass.Device + "', " +
                 COLUMN_GCS + " = '" + oClass.Gcs + "', " +
                 COLUMN_WLBS + " = '" + oClass.Wlbs + "', " +
                 COLUMN_WKLS + " = '" + oClass.Wkls + "', " +
                 COLUMN_NOTES + " = '" + oClass.Notes.Replace("'", "") + "', " +
                 " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE id = '" + oClass.ID + "' ";


            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeleteIVByEMS(TxnClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_IV + " " +
                      "WHERE " + COLUMN_TXN_NO + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeleteIV(TxnClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_IV + " " +
                    " WHERE id = " + oClass.ID + " ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        #endregion

        #region tblTxnEmsInsurance
        private static string TABLE_INSURANCE = "txnems_insurance";
        private static string COLUMN_MEDICARE = "medicare_no";
        private static string COLUMN_MEDICAID = "medicaid_no";
        private static string COLUMN_INSURANCE_ID = "insurance_id";
        private static string COLUMN_POLICY = "policy_no";
        private static string COLUMN_GROUP = "group_no";
        private static string COLUMN_PHONE = "phone_no";

        public DataSet SelectAllIns()
        {

            strSql = "SELECT * " +
                  "FROM " + TABLE_INSURANCE + " ";

            return Select();
        }

        public DataSet SelectAllInsByEms(TxnClass oClass)
        {

            strSql = "SELECT  * " +
                  "FROM " + TABLE_INSURANCE + " " +
                   "WHERE " + COLUMN_TXN_NO + " = '" + oClass.ID + "' ";

            return Select();
        }

        public void InsertIns(string currUser, TxnClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "INSERT INTO " + TABLE_INSURANCE + " (" +
                        COLUMN_TXN_NO + ", " +
                        COLUMN_MEDICARE + ", " +
                        COLUMN_MEDICAID + ", " +
                        COLUMN_INSURANCE_ID + ", " +
                        COLUMN_POLICY + ", " +
                        COLUMN_GROUP + ", " +
                        COLUMN_PHONE + ", " +
                        COLUMN_NOTES + ", " +
                          "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.ID + "', '" +
                    oClass.MedicareNo + "', '" +
                    oClass.MedicaidNo + "', '" +
                    oClass.InsuranceID + "', '" +
                    oClass.PolicyNo + "', '" +
                    oClass.GroupNo + "', '" +
                    oClass.PhoneNo + "', '" +
                    oClass.Notes.Replace("'", "") + "', '" +
                    currUser + "', '" +
                     DateTime.Today + "', '" +
                    currUser + "', '" +
                   DateTime.Today + "' " +
                    ") ";
            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        //public void InsertInsServer(string currUser, TxnClass oClass)
        //{
        //    MySqlCommand cmd = new MySqlCommand();

        //    strSql = "INSERT INTO " + TABLE_INSURANCE + " (" +
        //               COLUMN_TXN_NO + ", " +
        //               COLUMN_MEDICARE + ", " +
        //               COLUMN_MEDICAID + ", " +
        //               COLUMN_INSURANCE_ID + ", " +
        //               COLUMN_POLICY + ", " +
        //               COLUMN_GROUP + ", " +
        //               COLUMN_PHONE + ", " +
        //               COLUMN_NOTES + ", " +
        //                 "created_by, created_date, updated_by, updated_date) ";
        //    strSql = strSql + "values ('" +
        //          oClass.ID + "', '" +
        //          oClass.MedicareNo + "', '" +
        //          oClass.MedicaidNo + "', '" +
        //          oClass.InsuranceID + "', '" +
        //          oClass.PolicyNo + "', '" +
        //          oClass.GroupNo + "', '" +
        //          oClass.PhoneNo + "', '" +
        //          oClass.Notes.Replace("'", "") + "', '" +
        //          currUser + "', '" +
        //            "CurDate(), '" +
        //            currUser + "', " +
        //            "CurDate() " +
        //            ") ";
        //    try
        //    {
        //        if (oConnection.OpenMySQLConnection())
        //        {
        //            myCon2 = oConnection.ConnectionObject2;
        //            MySqlParameter param = cmd.Parameters.Add("@image", MySqlDbType.LongBlob);
        //            param.Value = oClass.Sign;
        //            cmd.Connection = myCon2;
        //            cmd.CommandText = strSql;
        //            cmd.ExecuteNonQuery();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        if (myCon2.State == ConnectionState.Open)
        //        {
        //            myCon2.Close();
        //        }
        //        myCon2.Dispose();
        //        cmd.Dispose();
        //    }
        //}

        public void UpdateInsurance(string user, TxnClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "UPDATE " + TABLE_INSURANCE + " SET " +
                 COLUMN_MEDICARE + " = '" + oClass.MedicareNo + "', " +
                 COLUMN_MEDICAID + " = '" + oClass.MedicaidNo + "', " +
                 COLUMN_INSURANCE_ID + " = '" + oClass.InsuranceID + "', " +
                 COLUMN_POLICY + " = '" + oClass.PolicyNo + "', " +
                 COLUMN_GROUP + " = '" + oClass.GroupNo + "', " +
                 COLUMN_PHONE + " = '" + oClass.PhoneNo + "', " +
                 COLUMN_NOTES + " = '" + oClass.Notes.Replace("'", "") + "', " +
                 " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE id = '" + oClass.ID + "' ";


            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeleteInsuranceByEMS(TxnClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_INSURANCE + " " +
                      "WHERE " + COLUMN_TXN_NO + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeleteInsurance(TxnClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_INSURANCE + " " +
                    " WHERE id = " + oClass.ID + " ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        #endregion

        #region tblTxnMessages
        private static string TABLE_MESSAGES = "txnmessages";
        private static string COLUMN_DATE_MSG = "date_msg";
        private static string COLUMN_FROM = "mfrom";
       
        public DataSet SelectAllMessage()
        {

            strSql = "SELECT a.id, a.date_msg, a.mfrom, a.notes, Concat(b.last_name, ', ', b.first_name) as patient_name " +
                  "FROM " + TABLE_MESSAGES + " a left outer join " + TABLE_PATIENT + " b on b.id= a.patient_id ";

            return Select();
        }

        public DataSet SelectAllMessageByPatID(TxnClass oClass)
        {

            strSql = "SELECT a.id, a.date_msg, a.mfrom, a.notes, Concat(b.last_name, ', ', b.first_name) as patient_name " +
                  "FROM " + TABLE_MESSAGES + " a left outer join " + TABLE_PATIENT + " b on b.id= a.patient_id " +
                    "WHERE a." + COLUMN_PATIENT + " = '" + oClass.PatientID + "' ";

            return Select();
        }

        public DataSet SelectAllMessageByPat(TxnClass oClass)
        {

            strSql = "SELECT  a.*, (b.last_name + ', ' + b.first_name) as patient_name " +
                  "FROM " + TABLE_MESSAGES + " a left outer join " + TABLE_PATIENT + " b on b.id= a.patient_id " +
                   "WHERE a." + COLUMN_PATIENT + " = '" + oClass.PatientID + "' ";

            return Select();
        }

        public DataSet GetMessageID(string FirstNo)
        {
            strSql = "SELECT right(" + COLUMN_TXN_NO + ",4) " +
                     "FROM " + TABLE_MESSAGES + " " +
                     "WHERE left(" + COLUMN_TXN_NO + ",8) = '" + FirstNo + "' " +
                     "ORDER BY right(" + COLUMN_TXN_NO + ",4) desc ";

            return Select();
        }

        public DataSet SelectMessageID(TxnClass oClass)
        {

            strSql = "SELECT a.*, (b.last_name + ', ' + b.first_name) as patient_name " +
                    "FROM " + TABLE_MESSAGES + " a left outer join " + TABLE_PATIENT + " b on b.id= a.patient_id " +
                     "WHERE a.id = " + oClass.ID + " ";

            return Select();
        }

        public void InsertMessage(string currUser, TxnClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "INSERT INTO " + TABLE_MESSAGES + " (" +
                        COLUMN_TXN_NO + ", " +
                        COLUMN_PATIENT + ", " +
                        COLUMN_FROM + ", " +
                        COLUMN_DATE_MSG + ", " +
                        COLUMN_NOTES + ", " +
                          "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.ID + "', '" +
                    oClass.PatientID + "', '" +
                     oClass.FileName + "', '" +
                    oClass.DOS.ToString("yyyy-MM-dd") + "', '" +
                    oClass.Notes.Replace("'", "") + "', '" +
                    currUser + "', '" +
                     DateTime.Today.ToString("yyyy-MM-dd") + "', '" +
                    currUser + "', '" +
                   DateTime.Today.ToString("yyyy-MM-dd") + "' " +
                    ") ";
            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        //public void InsertNecessityServer(string currUser, TxnClass oClass)
        //{
        //    MySqlCommand cmd = new MySqlCommand();

        //    strSql = "INSERT INTO " + TABLE_NECESSITY + " (" +
        //                 COLUMN_TXN_NO + ", " +
        //                 COLUMN_PATIENT + ", " +
        //                 COLUMN_SOURCE + ", " +
        //                 COLUMN_FORMNAME + ", " +
        //                 COLUMN_FILENAME + ", " +
        //                 COLUMN_NOTES + ", " +
        //                   "created_by, created_date, updated_by, updated_date) ";
        //    strSql = strSql + "values ('" +
        //            oClass.ID + "', '" +
        //            oClass.PatientID + "', " +
        //            "@image" + ", '" +
        //            oClass.FormName + "', '" +
        //            oClass.FileName + "', '" +
        //            oClass.Notes.Replace("'", "") + "', '" +
        //            currUser + "', '" +
        //            "CurDate(), '" +
        //            currUser + "', " +
        //            "CurDate() " +
        //            ") ";
        //    try
        //    {
        //        if (oConnection.OpenMySQLConnection())
        //        {
        //            myCon2 = oConnection.ConnectionObject2;
        //            MySqlParameter param = cmd.Parameters.Add("@image", MySqlDbType.LongBlob);
        //            param.Value = oClass.SourceFile;
        //            cmd.Connection = myCon2;
        //            cmd.CommandText = strSql;
        //            cmd.ExecuteNonQuery();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        if (myCon2.State == ConnectionState.Open)
        //        {
        //            myCon2.Close();
        //        }
        //        myCon2.Dispose();
        //        cmd.Dispose();
        //    }
        //}

        public void UpdateMessage(string user, TxnClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "UPDATE " + TABLE_MESSAGES + " SET " +
                 COLUMN_PATIENT + " = '" + oClass.PatientID + "', " +
                 COLUMN_FROM + " = '" + oClass.FileName  + "', " +
                 COLUMN_DATE_MSG + " = '" + oClass.DOS.ToString("yyyy-MM-d HH:MM:ss") + "', " +
                 COLUMN_NOTES + " = '" + oClass.Notes.Replace("'", "") + "', " +
                 " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE id = '" + oClass.ID + "' ";


            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }


        public void DeleteMessage(TxnClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_MESSAGES + " " +
                    " WHERE id = " + oClass.ID + " ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        #endregion

       
    }
}
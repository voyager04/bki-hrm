using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using BKI_HRM.US;
using BKI_HRM.DS;
using IP.Core.IPCommon;

namespace BKI_HRM
{
    class ControllerHTUSER
    {
        private SqlDataAdapter myAdapter;
        private SqlConnection conn;

        public ControllerHTUSER()
        {
            string server = ConfigurationSettings.AppSettings["SERVER"];
            string database = ConfigurationSettings.AppSettings["INITIAL_DATABASE"];
            string user = ConfigurationSettings.AppSettings["INITIAL_USER"];
            string password = ConfigurationSettings.AppSettings["PASS_WORD"];
            string connectionString = "Data Source=" + server + ";Initial Catalog=" + database + ";User ID=" + user + ";Password=" + password;
            conn = new SqlConnection(connectionString);
        }

        private SqlConnection openConnection()
        {
            if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
            {
                conn.Open();
            }
            return conn;
        }

        private SqlConnection closeConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return conn;
        }

        public DataTable executeSelectQuery(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            DataTable dataTable = new DataTable();
            myAdapter = new SqlDataAdapter();
            dataTable = null;
            DataSet ds = new DataSet();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myCommand.ExecuteNonQuery();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(ds);
                dataTable = ds.Tables[0];
            }
            catch (SqlException e)
            {
                return null;
            }
            finally
            {

            }
            return dataTable;
        }

        public bool executeInsertQuery(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.AddRange(sqlParameter);myCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                return false;
            }
            finally
            {
                myCommand.Connection = closeConnection();
            }
            return true;
        }

        public bool executeUpdateQuery(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.AddRange(sqlParameter);
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                return false;
            }
            finally
            {
                myCommand.Connection = closeConnection();
            }
            return true;
        }
    }

    public class HT_USER_DataAccess
    {
        ControllerHTUSER conn;

        public HT_USER_DataAccess()
        {
            conn = new ControllerHTUSER();
        }

        public List<US_HT_USER> GetAllUsers()
        {
            string query = string.Format("select * from [HT_USER]");
            SqlParameter[] sqlParameters = new SqlParameter[0];
            DataTable dataTable = conn.executeSelectQuery(query, sqlParameters);
            List<US_HT_USER> listUsers = new List<US_HT_USER>();
            foreach (DataRow dr in dataTable.Rows)
            {
                US_HT_USER user = new US_HT_USER();
                Guid id = new Guid(dr["ID"].ToString());
                user.ID = id;
                user.BHYT = dr["BHYT"].ToString();
                user.CMND = dr["CMND"].ToString();
                user.MSBN = dr["MSBN"].ToString();
                user.USERNAME = dr["USERNAME"].ToString();
                user.PASSWORD = dr["PASSWORD"].ToString();
                user.HO = dr["HO"].ToString();
                user.TEN = dr["TEN"].ToString();
                user.IS_ACTIVE = bool.Parse(dr["IS_ACTIVE"].ToString());
                Guid idGroup = new Guid(dr["ID_USER_GROUP"].ToString());
                user.ID_USER_GROUP = idGroup;
                listUsers.Add(user);
            }
            return listUsers;
        }

        public void Insert(US_HT_USER ip_us)
        {
            SqlParameter[] sqlParameters = new SqlParameter[10];
            sqlParameters[0] = new SqlParameter("@ID", SqlDbType.UniqueIdentifier) {Value = ip_us.ID};
            sqlParameters[1] = new SqlParameter("@BHYT", SqlDbType.NVarChar) {Value = ip_us.BHYT};
            sqlParameters[2]= new SqlParameter("CMND", SqlDbType.NVarChar) {Value = ip_us.CMND};
            sqlParameters[3]= new SqlParameter("MSBN", SqlDbType.NVarChar) {Value = ip_us.MSBN};
            sqlParameters[4]= new SqlParameter("USERNAME", SqlDbType.NVarChar) {Value = ip_us.USERNAME};
            sqlParameters[5]= new SqlParameter("PASSWORD", SqlDbType.NVarChar) {Value = ip_us.PASSWORD};
            sqlParameters[6]= new SqlParameter("HO", SqlDbType.NVarChar) {Value = ip_us.HO};
            sqlParameters[7]= new SqlParameter("TEN", SqlDbType.NVarChar) {Value = ip_us.TEN};
            sqlParameters[8]= new SqlParameter("IS_ACTIVE", SqlDbType.Bit) {Value = ip_us.IS_ACTIVE};
            sqlParameters[9]= new SqlParameter("ID_USER_GROUP", SqlDbType.UniqueIdentifier) {Value = ip_us.ID_USER_GROUP};

            //string query =
            //    "INSERT HT_USER ([ID], [BHYT], [CMND], [MSBN], [USERNAME], [PASSWORD], [HO], [TEN], [IS_ACTIVE], [ID_USER_GROUP]) "
            //+ "VALUES ('" + ip_us.ID + "', '" + ip_us.BHYT + "', '" + ip_us.CMND + "', '" + ip_us.MSBN + "', '" + ip_us.USERNAME + "', '" + ip_us.PASSWORD + "', '" + ip_us.HO + "', '" + ip_us.TEN + "', " + ip_us.IS_ACTIVE + ", '" + ip_us.ID_USER_GROUP + "')";

            conn.executeInsertQuery("pr_HT_USER_Insert", sqlParameters);
            //conn.executeInsertQuery(query, sqlParameters);
        }

        public void Update(US_HT_USER ip_us)
        {
            SqlParameter[] sqlParameters = new SqlParameter[10];
            sqlParameters[0] = new SqlParameter("@ID", SqlDbType.UniqueIdentifier) { Value = ip_us.ID };
            sqlParameters[1] = new SqlParameter("@BHYT", SqlDbType.NVarChar) { Value = ip_us.BHYT };
            sqlParameters[2] = new SqlParameter("CMND", SqlDbType.NVarChar) { Value = ip_us.CMND };
            sqlParameters[3] = new SqlParameter("MSBN", SqlDbType.NVarChar) { Value = ip_us.MSBN };
            sqlParameters[4] = new SqlParameter("USERNAME", SqlDbType.NVarChar) { Value = ip_us.USERNAME };
            sqlParameters[5] = new SqlParameter("PASSWORD", SqlDbType.NVarChar) { Value = ip_us.PASSWORD };
            sqlParameters[6] = new SqlParameter("HO", SqlDbType.NVarChar) { Value = ip_us.HO };
            sqlParameters[7] = new SqlParameter("TEN", SqlDbType.NVarChar) { Value = ip_us.TEN };
            sqlParameters[8] = new SqlParameter("IS_ACTIVE", SqlDbType.Bit) { Value = ip_us.IS_ACTIVE };
            sqlParameters[9] = new SqlParameter("ID_USER_GROUP", SqlDbType.UniqueIdentifier) { Value = ip_us.ID_USER_GROUP };
            conn.executeUpdateQuery("pr_HT_USER_Update", sqlParameters);
        }

        public void Delete(US_HT_USER ip_us)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ID", SqlDbType.UniqueIdentifier) { Value = ip_us.ID };
            conn.executeUpdateQuery("pr_HT_USER_Delete", sqlParameters);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace WcfServiceLibrary1
{
    class db
    {


        private string connectioString()
        {
             string databaseServer = "172.16.11.19", databaseName = "TempTest", userName = "arms", password = "roti1234";
           
            int iMinPoolSize = 0;
            int iMaxPoolSize = 500;
          
            bool bPersistSecurityInfo = false;
            string sConnectionString = string.Empty;

                       
                sConnectionString = "Data Source=" + databaseServer + ";Initial Catalog=" + databaseName + ";Persist Security Info="
                        + bPersistSecurityInfo.ToString() + ";User ID=" + userName + ";Password=" + password
                        + ";Connection Reset=true;Asynchronous Processing=true;MultipleActiveResultSets=true;Pooling=true;Enlist=true;Min Pool Size="
                        + iMinPoolSize.ToString() + ";Max Pool Size=" + iMaxPoolSize.ToString()
                        + ";Connection Timeout=30";

            return sConnectionString;

        }
      
        public void save(string Name)
        {
           
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectioString());
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Employee(EmpName) VALUES('" + Name + "')", sqlConnection);
                cmd.ExecuteNonQuery();

               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable GetDetails()
        {

            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectioString());
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("select * from dbo.Employee", sqlConnection);
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

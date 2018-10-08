using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
       

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

       
        public int Savedata(string EmpName)
        {
            db dbcon = new WcfServiceLibrary1.db();

            dbcon.save(EmpName);

            return 1;
        }


        List<Employee> IService1.GetData()
        {
            List<Employee> EmpList = new List<Employee>();
            db dbcon = new WcfServiceLibrary1.db();
            DataTable dt;
            dt = dbcon.GetDetails();

            EmpList = (from DataRow dr in dt.Rows
                       select new Employee()
                       {
                           Id = Convert.ToInt32(dr["Id"]),
                           EmpName = dr["EmpName"].ToString()
                       }).ToList();

            return EmpList;
        }
    }

    [DataContract]
    public class Employee
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string EmpName { get; set; }
    }
      
      

//}
}

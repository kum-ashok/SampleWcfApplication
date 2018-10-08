using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SampleWcfApplication.ServiceReference1;
using System.Runtime.Serialization;

namespace SampleWcfApplication
{
    
    public partial class Form1 : Form
    {
        SampleWcfApplication.ServiceReference1.Service1Client proxy;
        public Form1()
        {
            InitializeComponent();
            proxy = new Service1Client(); 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

           proxy.Savedata(textBox2.Text);
            GetData();

        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void GetData()
        {
            List<Employee> Employee = (List<Employee>)proxy.GetData().ToList();

            var query = (from x in Employee.AsEnumerable()
                         select new
                         {
                             x.Id,
                             x.EmpName
                         }).ToList();


            dataGridView1.DataSource = query;
        }
    }

   
    //public class Employee
    //{
    //    public int Id { get; set; }
    //    public string EmpName { get; set; }
    //}
}

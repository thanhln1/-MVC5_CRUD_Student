using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WebApplication15_CRUD_MVC5.Models
{
   
    public class StudentDBHandle
    {

        private SqlConnection con;
        private void connection ()
        {
            string constring = ConfigurationManager.ConnectionStrings["studentconn"].ToString();
            con = new SqlConnection(constring);
        }

        // insert sudent
        public bool AddStudent(StudentModel smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("insertStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", smodel.Name);
            cmd.Parameters.AddWithValue("@City", smodel.City);
            cmd.Parameters.AddWithValue("@Address", smodel.Address);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            
            if (i>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //get all to list
        public List<StudentModel> GetStudent()
        {
            connection();
            List<StudentModel > StudentList = new List<StudentModel>();

            SqlCommand cmd = new SqlCommand("GetStudentDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach ( DataRow dr in dt.Rows)
            {
                StudentList.Add(
                    new StudentModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        City = Convert.ToString(dr["City"]),
                        Address = Convert.ToString(dr["Address"])
                    });

            }
            return StudentList;
        }
    }
}
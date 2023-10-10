using CRUD_ADO.Utility;
using System.Data;
using System.Data.SqlClient;

namespace CRUD_ADO.Models
{
    public class EmployeeDataAccessLayer
    {
        string connectionString = ConnectionString.CName;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader rdr;
        public EmployeeDataAccessLayer()
        {
            con = new SqlConnection(connectionString);
        }
        public IEnumerable<EmployeeModel> GetAllEmployeeModel()
        {
            List<EmployeeModel> lstEmployeeModel = new List<EmployeeModel>();
            cmd = new SqlCommand("SP_Employee", con);
            cmd.Parameters.AddWithValue("@Flag", "Select_Employee");
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                EmployeeModel EmployeeModel = new EmployeeModel();
                EmployeeModel.Employee_id = Convert.ToInt32(rdr["Employee_id"]);
                EmployeeModel.Employee_Name = rdr["Employee_Name"].ToString();
                EmployeeModel.Employee_Salary = rdr["Employee_Salary"].ToString();
                lstEmployeeModel.Add(EmployeeModel);
            }
            con.Close();
            return lstEmployeeModel;
        }


        public void AddEmployeeModel(EmployeeModel EmployeeModel)
        {
            //using (con = new SqlConnection(connectionString))
            //{
            cmd = new SqlCommand("SP_Employee", con);
            cmd.Parameters.AddWithValue("@Flag", "Insert_Employee");
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Emp_Name", EmployeeModel.Employee_Name);
            cmd.Parameters.AddWithValue("@Emp_Salary", EmployeeModel.Employee_Salary);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            //}
        }

        public void UpdateEmployeeModel(EmployeeModel EmployeeModel)
        {
            //using (con = new SqlConnection(connectionString))
            //{
            cmd = new SqlCommand("SP_Employee", con);
            cmd.Parameters.AddWithValue("@Flag", "Update_Employee");
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", EmployeeModel.Employee_Id);
            cmd.Parameters.AddWithValue("@Emp_Name", EmployeeModel.Employee_Name);
            cmd.Parameters.AddWithValue("@Emp_Salary", EmployeeModel.Employee_Salary);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            //}
        }

        public EmployeeModel GetEmployeeModelData(int? id)
        {
            EmployeeModel EmployeeModel = new EmployeeModel();

            //using (con = new SqlConnection(connectionString))
            //{
            cmd = new SqlCommand("SP_Employee", con);
            cmd.Parameters.AddWithValue("@Flag", "Select_Employee_By_Id");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            //string sqlQuery = "SELECT * FROM SW_TBL_EMPLOYEE WHERE Employee_id= " + id;
            //SqlCommand cmd = new SqlCommand(sqlQuery, con);
            con.Open();
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                EmployeeModel.Employee_id = Convert.ToInt32(rdr["Employee_id"]);
                EmployeeModel.Employee_Name = rdr["Employee_Name"].ToString();
                EmployeeModel.Employee_Salary = rdr["Employee_Salary"].ToString();
            }
            //}
            return EmployeeModel;
        }

        public void DeleteEmployeeModel(int? id)
        {
            //using (con = new SqlConnection(connectionString))
            //{
            cmd = new SqlCommand("SP_Employee", con);
            cmd.Parameters.AddWithValue("@Flag", "Delete_Employee_By_Id");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            //}
        }
    }
}
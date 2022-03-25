using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EmpManagementApi.Models
{
    public class EmployeeDetailsModel
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public bool Permanent { get; set; }
        #endregion

        #region SqlConnection
        SqlConnection con = new SqlConnection("server=DESKTOP-VE9QC92\\TRAINERINSTANCE;database=employeeApp; integrated security=true");
        #endregion

        #region Read Data
        public List<EmployeeDetailsModel> GetEmployeeList()
        {
            SqlCommand cmd_allEmployees = new SqlCommand("select * from employeeDetails", con);
            List<EmployeeDetailsModel> employeeList = new List<EmployeeDetailsModel>();
            SqlDataReader reader = null;
            try
            {
                con.Open();
                reader = cmd_allEmployees.ExecuteReader();

                while(reader.Read())
                {
                    employeeList.Add(new EmployeeDetailsModel()
                    {
                        Id = Convert.ToInt32(reader["id"]),//Wanted to see if this notation worked. It does!
                        Name = reader[1].ToString(),
                        Salary = Convert.ToDouble(reader[2]),
                        Permanent = Convert.ToBoolean(reader[3])
                    });
                }
            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                reader.Close();
                con.Close();
            }
            return employeeList;
        }

        public EmployeeDetailsModel GetEmployeeDetails(int id)
        {
            SqlCommand cmd_SearchById = new SqlCommand("select * from employeeDetails where Id = @id", con);
            cmd_SearchById.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = null;
            EmployeeDetailsModel employee = new EmployeeDetailsModel();
            try
            {
                con.Open();
                reader = cmd_SearchById.ExecuteReader();

                if(reader.Read())
                {
                    employee.Id = Convert.ToInt32(reader["id"]);
                    employee.Name = reader[1].ToString();
                    employee.Salary = Convert.ToDouble(reader[2]);
                    employee.Permanent = Convert.ToBoolean(reader[3]);
                }
                else
                {
                    throw new Exception("Product not found");
                }
            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                reader.Close();
                con.Close();
            }

            return employee;
        }
        #endregion

        #region Add Data
        public string AddEmployee(EmployeeDetailsModel newEmployee)
        {
            SqlCommand cmd_addEmployee = new SqlCommand("insert into employeeDetails values(@Name,@Salary,@Permanent)", con);
            cmd_addEmployee.Parameters.AddWithValue("@Name", newEmployee.Name);
            cmd_addEmployee.Parameters.AddWithValue("@Salary", newEmployee.Salary);
            cmd_addEmployee.Parameters.AddWithValue("@Permanent", newEmployee.Permanent);

            try
            {
                con.Open();
                cmd_addEmployee.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return "Employee Added Succesfully";
        }
        #endregion

        #region Delete Data
        public String DeleteEmployee(int id)
        {
            SqlCommand cmd_delete = new SqlCommand("delete from employeeDetails where Id = @id", con);
            cmd_delete.Parameters.AddWithValue("@id", id);
            try
            {
                con.Open();
                cmd_delete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { con.Close(); }
            return "Employee Deleted Succesfully";
        }
        #endregion

        #region Update Data
        public string UpdateEmployee(EmployeeDetailsModel updates)
        {
            SqlCommand cmd_update = new SqlCommand("update employeeDetails set Name = @name,Salary = @salary, Permanent = @permanent", con);
            cmd_update.Parameters.AddWithValue("@Name",updates.Name);
            cmd_update.Parameters.AddWithValue("@Salary",updates.Salary);
            cmd_update.Parameters.AddWithValue("@Permanent",updates.Permanent);

            try
            {
                con.Open();
                cmd_update.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally { con.Close(); }
            return "Employee Updated Successfully";
        }
        #endregion
    }
}

using System.Collections.Generic;

namespace EmpManagementApi.Models
{
    public class EmployeeModel
    {

        #region Product Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public double salary { get; set; }
        public bool permanent { get; set; }


        #endregion

        public EmployeeModel GetEmployeeInfo()
        {
            return new EmployeeModel()
            {
                Id = 101,
                Name = "Julian Metzger",
                salary = 55000,
                permanent = false
            };
        }

        public List<EmployeeModel> GetEmployeeList()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            employees.Add(GetEmployeeInfo());
            employees.Add(new EmployeeModel() { Id =102, Name ="Michael Corleone", salary =60000, permanent = true});
            employees.Add(new EmployeeModel() { Id =103, Name ="John Halo", salary =117000, permanent = true});
            employees.Add(new EmployeeModel() { Id = 104, Name = "StarScourge Radahn", salary = 70000, permanent = true });

            return employees;
        }

    }
}

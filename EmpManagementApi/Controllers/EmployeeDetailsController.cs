using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmpManagementApi.Models;
namespace EmpManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDetailsController : ControllerBase
    {
        EmployeeDetailsModel model = new EmployeeDetailsModel();

        #region Get all Employees
        [HttpGet]
        [Route("empList")]
        public IActionResult EmployeeList()
        {
            try
            {
                return Ok(model.GetEmployeeList());
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        #endregion

        #region Get by ID
        [HttpGet]
        [Route("empByID")]
        public IActionResult GetEmpById(int id)
        {
            try
            {
                return Ok(model.GetEmployeeDetails(id));
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Add Employee
        [HttpPost]
        [Route("addEmployee")]
        public IActionResult AddEmployee(EmployeeDetailsModel newEmployee)
        {
            try
            {
                return Created("", model.AddEmployee(newEmployee));
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Delete Employee
        [HttpDelete]
        [Route("deleteEmployee")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                return Accepted(model.DeleteEmployee(id));
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Update Employee
        [HttpPut]
        [Route("updateEmployee")]
        public IActionResult UpdateEmployee(EmployeeDetailsModel updates)
        {
            try
            {
                return Accepted(model.UpdateEmployee(updates));
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}

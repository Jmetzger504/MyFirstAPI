using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmpManagementApi.Models;
namespace EmpManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        #region Greeting
            [HttpGet]
            [Route("greetings")]
            public IActionResult Greet()
            {
                return Ok("Welcome to Web API - RESTFUL Services");
            }
        #endregion

        #region Pass a Parameter
            [HttpGet]
            [Route("welcomeuser")]
            public IActionResult GreetUser(string guestName)
            {
                return Ok("Welcome," + guestName);
            }
        #endregion

        #region Return Employee Array
            [HttpGet]
            [Route("employees")]
            public IActionResult GetEmployeeList()
            {
                string[] employees = new string[5];
                employees[0] = "Julian Metzger";
                employees[1] = "Starscourge Radahn";
                employees[2] = "John Halo";
                employees[3] = "Teddy Roosevelt";
                employees[4] = "Angela Ziegler";

                return Ok(employees);
            }
        #endregion

        #region Employee Info
            [HttpGet]
            [Route("employee")]
            public IActionResult GetEmployeeInfo()
        {
            EmployeeModel employee = new EmployeeModel();
            return Ok(employee.GetEmployeeInfo());
        }
        #endregion

        #region Employee List
            [HttpGet]
            [Route("eList")]
            public IActionResult EmployeeList()
        {
            EmployeeModel employee = new EmployeeModel();
            return Ok(employee.GetEmployeeList());
        }
        #endregion

    }
}

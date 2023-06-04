using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using BL;

namespace WebApiProject.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SchedulingController : ControllerBase
    {
        Usedb usedb = new Usedb();
        [HttpGet]
        //public IActionResult Login(string email, string password)
        //{
        //    usedb.userRetrieval(email, password)
        //}
        public IActionResult Register(int UserID, string Email, string FirstName, string LastName,
            string CountryOfResidence, string Gender, string CellphoneNumber,
            string Password, string Line_of_Business, DateTime DateOfBirth)
        {
            usedb.createUser(UserID, Email, FirstName, LastName,
            CountryOfResidence, Gender, CellphoneNumber,
            Password, Line_of_Business, DateOfBirth);
            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using DTO;
using DTO.model;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        public Algorithm _alg;
        

        public SearchController()
        {
            _alg = new Algorithm();
        }
        [Route("searchUser")]
        [HttpPost]
      
        public List<FinalDialogue> searchUser(userObj userObj)
        {
            List<FinalDialogue> name = _alg.Result(userObj.Email, userObj.Password);
            return name;
        }
    }
}

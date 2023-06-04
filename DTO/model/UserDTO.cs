using System;
using System.Collections.Generic;
using System.Text;
//using DAL.Models;

namespace DTO.model
{
    public class UserDTO
    {
        public string Email { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CountryOfResidence { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string CellphoneNumber { get; set; }
        public string Password { get; set; }
        public string LineOfBusiness { get; set; }
    }
}
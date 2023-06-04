using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblDataForPlacement = new HashSet<TblDataForPlacement>();
        }

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

        public virtual ICollection<TblDataForPlacement> TblDataForPlacement { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class TblDomains
    {
        public TblDomains()
        {
            TblDataForPlacement = new HashSet<TblDataForPlacement>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TblDataForPlacement> TblDataForPlacement { get; set; }
    }
}

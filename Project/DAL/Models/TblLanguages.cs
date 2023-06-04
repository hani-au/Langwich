using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class TblLanguages
    {
        public TblLanguages()
        {
            TblDataForPlacement = new HashSet<TblDataForPlacement>();
        }

        public int CodeLanguages { get; set; }
        public string NameLanguages { get; set; }

        public virtual ICollection<TblDataForPlacement> TblDataForPlacement { get; set; }
    }
}

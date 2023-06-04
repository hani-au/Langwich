using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class TblLevelOfKnowledge
    {
        public TblLevelOfKnowledge()
        {
            TblDataForPlacement = new HashSet<TblDataForPlacement>();
        }

        public int Id { get; set; }
        public string TheLevel { get; set; }

        public virtual ICollection<TblDataForPlacement> TblDataForPlacement { get; set; }
    }
}

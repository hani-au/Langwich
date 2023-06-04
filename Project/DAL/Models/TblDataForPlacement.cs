using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class TblDataForPlacement
    {
        public int Code { get; set; }
        public int UserId { get; set; }
        public int? CodeLanguages { get; set; }
        public int? TheLevel { get; set; }
        public int? Name { get; set; }
        public int Type { get; set; }
        public int? FriendId { get; set; }

        public virtual TblLanguages CodeLanguagesNavigation { get; set; }
        public virtual TblDomains NameNavigation { get; set; }
        public virtual TblLevelOfKnowledge TheLevelNavigation { get; set; }
        public virtual TblUser User { get; set; }
    }
}

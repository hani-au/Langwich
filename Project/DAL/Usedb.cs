using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Usedb
    {
        public chaniprojectContext db { get; set; }//משתנה מסוג המסד נתונים
        TblUser use = new TblUser();//משתנה מסוג טבלת משתמשים
        public List<TblDataForPlacement> v_arc { get; set; }
        public List<TblLanguages> v_arcl { get; set; }
        public List<TblDomains> v_arc2 { get; set; }
        public List<TblLevelOfKnowledge> v_arc3 { get; set; }
        public List<TblUser> v_user { get; set; }
        public Usedb()//ctor
        {
            db = new chaniprojectContext();
            v_user = db.TblUser.ToList();
            v_arc = db.TblDataForPlacement.ToList();
            v_arcl = db.TblLanguages.ToList();

        }
        //שליפת משתמש
        public TblUser userRetrieval(string email, string password)
        {
            TblUser user= db.TblUser.FirstOrDefault(u => u.Email == email && u.Password == password);
            return user;
        }
    }
}

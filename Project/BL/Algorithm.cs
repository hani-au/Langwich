using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using DTO.model;
using AutoMapper;
using DTO;

namespace BL
{
    public class Algorithm
    {
        List<int> a = new List<int>();//רשימת נלמדים
        List<int> b = new List<int>();//רשימת מלמדים
        Graph g = new Graph();//משתנה מסוג גרף
        Usedb usedb = new Usedb();//משתנה מסוג המחלקה של פונקציות מסד הנתונים
        private IMapper m;
        public Algorithm()
        {
            //הגדרתי למעשה שאני הולכת להשתמש בקובץ AutoMapperProfile 
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperC>();
            });
            m = config.CreateMapper();
        }
        //החזרת התוצאה הסופית בכניסת משתמש
        public List<FinalDialogue> Result(string userName, string password)
        {
            TblUser resfriendTeach1 = new TblUser();//את מי אתה מלמד
            TblUser resfriendStudying1 = new TblUser();//מי מלמד אותך
            TblUser res1 = new TblUser();//המשתמש הנכנס למערכת

            res1 = usedb.userRetrieval(userName, password);//שליפת המשתמש הנתון בכניסה
            if (res1 != null)//אם קיים המשתמש
            {
                foreach (var item in usedb.v_arc.Where(x => x.UserId == res1.UserId && x.Type == 1))//לולאה העוברת על כל הטבלה במסד הנתונים ובודקת את מי הוא מלמד
                {
                    foreach (var item2 in usedb.v_user.Where(x => x.UserId == item.FriendId))
                    {
                        resfriendTeach1 = item2;
                    }
                }

                foreach (var item in usedb.v_arc.Where(x => x.FriendId == res1.UserId))//לולאה העוברת ובודקת ממי הוא לומד ממנz
                {
                    foreach (var item2 in usedb.v_user.Where(x => x.UserId == item.UserId))
                    {
                        resfriendStudying1 = item2;
                    }
                }
            }
           
            UserDTO resfriendTeach = m.Map<UserDTO>(resfriendTeach1);
            UserDTO resfriendStudying = m.Map<UserDTO>(resfriendStudying1);
            FinalDialogue resfriendTeachSofi = new FinalDialogue();
            FinalDialogue resfriendStudyingSofi = new FinalDialogue();
            //המרה סופית
            resfriendTeachSofi.Email = resfriendTeach.Email;
            resfriendTeachSofi.FirstName = resfriendTeach.FirstName;
            resfriendTeachSofi.LastName = resfriendTeach.LastName;
            resfriendTeachSofi.CellphoneNumber = resfriendTeach.CellphoneNumber;
            resfriendTeachSofi.DateOfBirth = resfriendTeach.DateOfBirth;
            resfriendTeachSofi.CountryOfResidence = resfriendTeach.CountryOfResidence;
            resfriendTeachSofi.LineOfBusiness = resfriendTeach.LineOfBusiness;
            //חפוש קוד שפה שאתה מלמד אותה
            TblDataForPlacement codeTeach=usedb.v_arc.Where(x =>x.UserId==res1.UserId && x.FriendId== resfriendTeach1.UserId ).First();
            int code1 = (int)codeTeach.CodeLanguages;
            TblLanguages name1 = usedb.v_arcl.Where(x => x.CodeLanguages == code1).First();
            string nameL1 = name1.NameLanguages;
            resfriendTeachSofi.language = nameL1;


            resfriendStudyingSofi.Email = resfriendStudying.Email;
            resfriendStudyingSofi.FirstName = resfriendStudying.FirstName;
            resfriendStudyingSofi.LastName = resfriendStudying.LastName;
            resfriendStudyingSofi.CellphoneNumber = resfriendStudying.CellphoneNumber;
            resfriendStudyingSofi.DateOfBirth = resfriendStudying.DateOfBirth;
            resfriendStudyingSofi.CountryOfResidence = resfriendStudying.CountryOfResidence;
            resfriendStudyingSofi.LineOfBusiness = resfriendStudying.LineOfBusiness;
            //חיפוש קוד שפה שילמדו אותך
            TblDataForPlacement codeStudy = usedb.v_arc.Where(x => x.UserId ==  resfriendStudying1.UserId&& x.FriendId == res1.UserId).First();
            int code2 = (int)codeStudy.CodeLanguages;
            TblLanguages name2 = usedb.v_arcl.Where(x => x.CodeLanguages == code2).First();
            string nameL2 = name2.NameLanguages;
            resfriendStudyingSofi.language = nameL2;

            List<FinalDialogue> users = new List<FinalDialogue>();
            users.Add(resfriendStudyingSofi);//ממי מלמד אותך
            users.Add(resfriendTeachSofi);//את מי אתה מלמד
            return users;
        }

        void DFSUtil(Vertex v, bool[] visited, Vertex[] parents)                            
        {
            visited[g.vertex.IndexOf(v)] = true;//קביעת הקדקוד כטופל
                                                //מעבר על כל השכנים של הקדקוד הנוכחי
            foreach (var n in v.archery)
            {
                //אם הקדקוד לא טופל הצבת האב ושליחה לפונקציה הרקורסיבית
                if (!visited[g.vertex.IndexOf(n.Target_vertex)])
                {
                    parents[g.vertex.IndexOf(n.Target_vertex)] = v;//הצבה במערך את האב של היעד 
                    DFSUtil(n.Target_vertex, visited, parents);//שליחה רקורסיבית
                }
            }
        }
        Vertex[] DFS(Vertex v)//אלגוריתם DFS שולם לDFS VISITED
        {
            bool[] visited = new bool[g.vertex.Count];//מערך לסימון האם הקודקוד טופל
            Vertex[] parents = new Vertex[g.vertex.Count];//מערך ה-parents
            DFSUtil(v, visited, parents);
            return parents;
        }
        public bool Route()//מציאת מסלול
        {
            Vertex[] varr = DFS(g.S);//מערך הPARENT שDFS מחזיר
            List<Vertex> V = g.vertex;
            Vertex v = g.T;
            Vertex p = varr[V.IndexOf(v)];
            if (p == null)
                return false;
            while (p != null)//שינוי כיוון הקשתות במסלול
            {
                g.Change_direction(p.UserId,p.WichList , v.UserId,v.WichList);//שינוי כיוון הקשת
                v = p;
                p = varr[V.IndexOf(v)];
            }
            return true;
        }
        //פונקציה למציאת זוגות והצבתם בטבלה הסופית
        public void Couples(Graph g)
        {
            foreach (var t in g.vertex.Where(x => x.WichList == 'b').ToList())//עובר על קודקודי המלמדים
            {
                foreach (var x in t.archery)//קשתות המלמד
                {
                    if (x.Target_vertex.WichList == 'a')//הקשת היא מן הלומדים
                    {
                        //לולאה העוברת על הטבלה ומחפשת את המלמד בכד להציב בו את הלומד
                        foreach (var n in usedb.v_arc.ToList().Where(y => y.UserId == t.UserId && y.Type == 1))
                        {
                            n.FriendId = t.archery[0].Target_vertex.UserId;
                            usedb.db.SaveChanges();
                            break;
                        }
                    }
                }
            }
        }

        //יצירת קודקודים לרשימה A
        public void CreateVerticesA(List<int> a)
        {
            foreach (var item in a)
            {
                g.Add_vertex(item,'a');
            }
        }
        //יצירת קודקודים לרשימה B
        public void CreateVerticesB(List<int> a)
        {
            foreach (var item in a)
            {
                g.Add_vertex(item, 'b');
            }
        }
        //פונקציה שמקבלת שתי רשימות של זהות משתמש
        //ויוצרת קשתות בהתאמה
        public void CreateArcs(List<int> a, List<int> b)//מציאת שם משתמש זהה ברשימת נתוני המשתמשים
        {
            for (int i = 0; i < a.Count; i++)
            {
                g.Add_archery(a[i],'a', b[i],'b');
            }
            
        }


        //פונקציה שקוראת מה-DB ויוצרת ומחזירה
        //שתי רשימות של משתמשים לצורך יצירת קשתות ביניהם
        public void CreateListVertex()
        {
            foreach (var i in usedb.v_arc)
            {
                if (i.Type == 0)//ללמוד
                {
                    List <TblDataForPlacement> t = usedb.v_arc.Where(x =>
                     (x.Type == 1 && x.CodeLanguages == i.CodeLanguages)//בדיקת התאמה לפי שפה
                     && (x.Name == i.Name)//התאמה לפי תחום שפה
                     && (x.User.Gender == i.User.Gender)//התאמה לפי מגדר
                     && (x.FriendId == null)//במידה ולא שובץ
                    ).ToList();
                    foreach (var j in t)
                    {
                        a.Add(i.UserId);//המעוניינים ללמוד
                        b.Add(j.UserId);//המעוניינים ללמד
                    }
                }
            }
            CreateVerticesA(a.Select(s => s).Distinct().ToList());
            CreateVerticesB(b.Select(s => s).Distinct().ToList());
            CreateArcToS(a.Select(s => s).Distinct().ToList());
            CreateArcToT(b.Select(s => s).Distinct().ToList());
            CreateArcs(a, b);
            while (Route()) ;
            Couples(g);

        }

        //פונקציה היוצרת קשתות מקודקוד S לכל הקודקודים 
        public void CreateArcToS(List<int> a)
        {
            g.Add_vertex(-1,'s');//הוספת קודקוד מקור

            for (int i = 0; i < a.Count; i++)
            {
                if (g.vertex[i].WichList=='a')
                {
                    g.Add_archery( g.S.UserId,'s',g.vertex[i].UserId,'a');
                }
            }     
            
            
        }
        //פונקציה היוצרת קשתות מכל הקודקודים אל T
        public void CreateArcToT(List<int> b)
        {            
            g.Add_vertex(-2,'t');//הוספת קודקוד יעד
            for (int i = 0; i < (b.Count)*2; i++)
            {
                if (g.vertex[i].WichList == 'b')
                {
                    g.Add_archery( g.vertex[i].UserId,'b',g.T.UserId,'t');
                }
            }

        }
    }
}


using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class Graph
    {
        public Vertex S { get; set; }
        public Vertex T { get; set; }

        public List<Vertex> vertex = new List<Vertex>();//רשימת קודקודים
        public Vertex Add_vertex(int user_id, char wichList)//הוספת קודקוד
        {
            Vertex v = new Vertex(user_id,wichList);
            v.UserId = user_id;
            if (v.UserId == -1)
                S = v;
            if (v.UserId == -2)
                T = v;
            vertex.Add(v);
            return vertex[vertex.IndexOf(v)];
        }
        public bool Delete_vertex(int user_id)//מחיקת קודקוד
        {
            if (vertex.Count > 0)
            {
                vertex.Remove(vertex.Find(x => x.UserId == user_id));
                return true;
            }
            return false;
        }
        public bool Add_archery(int id_sourse, char wichListS, int id_target,char wichListT)//הוספת קשת
        {
            if (vertex.Count >= 2)
            {
                Vertex v = vertex.Find(x => x.UserId == id_sourse && x.WichList==wichListS);
                Vertex v1 = vertex.Find(x => x.UserId == id_target&&x.WichList==wichListT);
                Archery a = new Archery();
                a.Target_vertex = v1;
                a.Direction = 1;
                v.archery.Add(a);
                return true;
            }
            return false;
        }
        public bool Delete_archery(int id_sourse,char wichListS ,int id_target,char wichListT)//מחיקת קשת
        {

            Vertex v = vertex.Find(x => x.UserId == id_sourse&&x.WichList==wichListS);
            Vertex v1 = vertex.Find(x => x.UserId == id_target&&x.WichList==wichListT);
            if (v != null && v1 != null && v.archery.Find(y => y.Target_vertex == v1) != null)
            {
                v.archery.Remove(v.archery.Find(y => y.Target_vertex == v1));
                return true;
            }
            return false;
        }
        public bool Vertex_search(int id_sourse)//חיפוש קודקוד
        {
            if (vertex.Find(x => x.UserId == id_sourse) != null)
                return true;
            return false;
        }
        public bool Archery_search(int id_sourse, int id_target)//חיפוש קשת
        {
            Vertex v = vertex.Find(x => x.UserId == id_sourse);
            Vertex v1 = vertex.Find(x => x.UserId == id_target);

            if (v.archery.Find(y => y.Target_vertex == v1) != null)
                return true;
            return false;
        }
        public bool Change_direction(int id_sourse, char wichListS, int id_target, char wichListT)//שינוי כיוון קשת
        {
            bool delete = Delete_archery(id_sourse, wichListS, id_target, wichListT);
            bool add=Add_archery(id_target,wichListT, id_sourse,wichListS);
            if (delete==true&&add==true)
            {
                return true;
            }
            return false;
        }
        
    }
}
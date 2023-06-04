using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class Vertex
    {
        public List<Archery> archery;//רשימת הקשתות
        public int UserId { get; set; }//קוד משתמש
        public char WichList { get; set; }//איזו רשימה
        public Vertex(int userId, char wichList)//פעולה בונה
        {
            archery = new List<Archery>();
            UserId = userId;
            WichList = wichList;
        }
    }
}

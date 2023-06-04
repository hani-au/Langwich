//using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
namespace project
{
   public class Program
    {
       public static void Main(string[] args)
        {
            Graph g = new Graph();
            Algorithm algorithm = new Algorithm();
            //g.Add_vertex("chanio7787@gmail.com");
            //g.Add_vertex("efratf664@gmail.com");
            //g.Add_archery("chanio7787@gmail.com", "efratf664@gmail.com");
            //g.Change_direction("chanio7787@gmail.com", "efratf664@gmail.com");
            //g.Archery_search("chanio7787@gmail.com", "efratf664@gmail.com");
            //g.Vertex_search("chanio7787@gmail.com");
            //g.Delete_archery("chanio7787@gmail.com", "efratf664@gmail.com");
            //Vertex v1 = g.Add_vertex(1);
            //Vertex v2 = g.Add_vertex(2);
            //Vertex v3 = g.Add_vertex(3);
            //Vertex v4 = g.Add_vertex(4);
            //g.Add_archery(1, 2);
            //g.Add_archery(2, 3);
            //g.Add_archery(1, 4);
            //g.Add_archery(4, 3);
            //g.Delete_vertex(5);
            algorithm.CreateListVertex();
            Console.ReadKey();
            //Usedb usedb = new Usedb();

        }
    }
}



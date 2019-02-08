using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ManagingErrors
{
    class Program
    {    
        static void Main(string[] args)
        {
           
            PlayerA p = new PlayerA();
            Console.WriteLine(p.Name);
            Console.WriteLine(p.Frag);
            Console.WriteLine(p.TotalDamage);
            Console.WriteLine(p.Score);

            p.Frag = 5;
            p.Death = 1;

            Console.WriteLine(p.Frag);
            Console.WriteLine(p.Score);

            Vector3 v1 = new Vector3(5, 5, 5);
            Console.WriteLine(v1.Magnitude);
            Console.WriteLine(v1.Normalized.Magnitude);

            GameState gs = new GameState();
            gs.State = GameState.States.InProgress;

            LoggerTest lt = new LoggerTest();
            lt.Update();
            lt.DoOtherThings();
            lt.SevMin = 10;
            lt.DoOtherThings();

            Polygon2D p1 = new Polygon2D();
            p1.vertices = new Vector2[] { new Vector2(2, 5), new Vector2(1, 5), new Vector2(2, 7) };
            Polygon2D p2 = new Polygon2D();
            p2.vertices = new Vector2[] { new Vector2(2, 5), new Vector2(1, 5), new Vector2(2, 7) };
            Console.WriteLine(p1 == p2); // t
            p2.vertices = new Vector2[] { new Vector2(2, 5), new Vector2(1, 5) };
            Console.WriteLine(p1 == p2); // f
            p2.vertices = new Vector2[] { new Vector2(2, 5), new Vector2(1, 5), new Vector2(2, 8) };
            Console.WriteLine(p1 == p2); // f
            Console.WriteLine(p1.GetHashCode());
            Console.WriteLine(p2.GetHashCode());
            Console.Read();
        }
       
    }
}

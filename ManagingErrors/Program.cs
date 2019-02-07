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
        }
       
    }
}

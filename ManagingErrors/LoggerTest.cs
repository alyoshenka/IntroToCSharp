using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingErrors
{
    class LoggerTest : ConsoleLogger
    {
        // impl interface
        int sevMin;
        public int SevMin { get => sevMin; set => sevMin = value; }
        public void Assert(bool con, string mes, int sev) { if (con && sev > sevMin) Console.WriteLine("Error of " + sev + " severity."); }
        public void Log(string mes, int sev) { Assert(true, mes, sev); }

        public void Update() { Console.WriteLine("updating..."); }
        public void DoOtherThings() { Console.WriteLine("doing other things..."); Log("testing log", 5); }
    }
}

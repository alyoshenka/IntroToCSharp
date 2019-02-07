using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingErrors
{
    interface ConsoleLogger
    {
        void Log(string mes, int lev);
        void Assert(bool con, string mes, int lev);
        int SevMin { get; set; }
    }

}

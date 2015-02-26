using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolTech.Demos.UnitTesting
{
    public class AuditLogger : IAuditLogger
    {
        public void Log(string message, params object[] args)
        {
            System.Diagnostics.Trace.TraceInformation(message, args);
        }
    }
}

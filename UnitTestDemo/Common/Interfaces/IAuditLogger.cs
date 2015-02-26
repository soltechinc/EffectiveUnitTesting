using System;

namespace SolTech.Demos.UnitTesting
{
    public interface IAuditLogger
    {
        void Log(string message, params object[] args);
    }
}

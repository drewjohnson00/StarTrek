using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointRobertsSoftware.StarTrek.Logging
{
    public interface IEventLogger
    {
        void LogInformation(string message, EventCode eCode);
        void LogWarning(string message, EventCode eCode);
        void LogError(string message, EventCode eCode);
    }
}

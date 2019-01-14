using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Windows.Foundation.Diagnostics;

namespace PointRobertsSoftware.StarTrek.Logging
{
    public class TraceLogger : IEventLogger
    {
        private FileLoggingSession _fileLoggingSession;
        private LoggingChannel _loggingChannel;

        public TraceLogger()
        {
            _fileLoggingSession = new FileLoggingSession("StarTrek");   // logfiles created in ApplicationData\Logs
            _loggingChannel = new LoggingChannel("StarTrekChannel", new LoggingChannelOptions());
            _fileLoggingSession.AddLoggingChannel(_loggingChannel);
            
        }

        public void LogVerbose(string message, EventCode eCode)
        {
            WriteEntryToSource(message, LoggingLevel.Verbose, (int)eCode);
        }

        public void LogInformation(string message, EventCode eCode)
        {
            WriteEntryToSource(message, LoggingLevel.Information, (int)eCode);
        }

        public void LogWarning(string message, EventCode eCode)
        {
            WriteEntryToSource(message, LoggingLevel.Warning, (int)eCode);
        }

        public void LogError(string message, EventCode eCode)
        {
            WriteEntryToSource(message, LoggingLevel.Error, (int)eCode);
        }

        public void LogCritical(string message, EventCode eCode)
        {
            WriteEntryToSource(message, LoggingLevel.Critical, (int)eCode);
        }


        private void WriteEntryToSource(string message, LoggingLevel type, int eventId)
        {
            if (message == null)
            {
                message = "WriteEntryToSource was called with a null message.";
            }

            if (message.Length > 32766)
            {
                // truncate...
                message = message.Substring(0, 32700);
            }

            //EventLog.WriteEntry(eSource, message, type, eventId);
            _loggingChannel.LogMessage("(" + eventId + ") - " + message, type);
        }

    }
}

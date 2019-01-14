using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointRobertsSoftware.StarTrek.Logging;

namespace PointRobertsSoftware.StarTrek.ViewModels
{
    public enum Column2StatusEnum { Blank, LoadGame, NetworkVerify };

    public class StartWindowVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private TraceLogger _logger;

        public StartWindowVM(TraceLogger logger)
        {
            _logger = logger;
        }

        private Column2StatusEnum _Column2Status = Column2StatusEnum.Blank;
        public Column2StatusEnum Column2Status
        {
            get { return _Column2Status; }
            set
            {
                if (_Column2Status == value) return;
                _Column2Status = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Column2Status"));
                _logger.LogInformation("Remove Me...Property changed to: " + value.ToString(), EventCode.UNEXPECTED_EXCEPTION);
            }
        }
    }
}

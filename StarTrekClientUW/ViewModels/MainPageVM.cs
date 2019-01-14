using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointRobertsSoftware.StarTrek.Logging;

namespace PointRobertsSoftware.StarTrek.ViewModels
{
    public enum CurrentWindowEnum { Start, Game };


    public class MainPageVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageVM()
        {
        }

        private CurrentWindowEnum _CurrentWindow = CurrentWindowEnum.Start;
        public CurrentWindowEnum CurrentWindow => _CurrentWindow;

        private TraceLogger _eventLogger;
        public TraceLogger EventLogger => _eventLogger;

        private string _verifyText;
        public string VerifyText
        {
            get { return _verifyText; }
            set
            {
                if (_verifyText == value) return;
                _verifyText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(VerifyText)));
            }
        }

        private string _verifyTextResult;
        public string VerifyTextResult
        {
            get { return _verifyTextResult; }
            set
            {
                if (_verifyTextResult == value) return;
                _verifyTextResult = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(VerifyTextResult)));
            }
        }

        private string _selectGrid;
        public string SelectGrid
        {
            get { return _selectGrid; }
            set
            {
                if (_selectGrid == value) return;
                _selectGrid = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectGrid)));
            }
        }
    }
}

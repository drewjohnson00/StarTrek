using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace StarTrek.ViewModels
{
    public class GalaxyVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //public ObservableCollection<QuadrantSummary> _quadrantSummaryRow;

        public GalaxyVM()
        {
        }

        public ObservableCollection<ObservableCollection<QuadrantSummary>> QuadrantSummaryRows
        {
            get
            {

            }
        }

        public ObservableCollection<QuadrantSummary> QuadrantSummaryRow
        {
            get
            {
                var _quadrantSummaryRow = new ObservableCollection<QuadrantSummary>();

                for (int n = 0; n < 8; n++)
                {
                    _quadrantSummaryRow.Add(new QuadrantSummary { Summary = Enterprise.KnownGalaxy.QuadrantSummary(0, n) });
                }

                return _quadrantSummaryRow;
            }
        }

        //private string _message;
        //public string Message
        //{
        //    get { return Enterprise.KnownGalaxy.Message; }
        //    set
        //    {
        //        if (value != null)
        //        {
        //            _message = value;
        //            PropertyChanged(this, new PropertyChangedEventArgs("Message"));
        //        }
        //    }
        //}
    }

    public class QuadrantSummary
    {
        private string _summary;
        public string Summary
        {
            get { return _summary; }
            set { _summary = value; }
        }
    }
}

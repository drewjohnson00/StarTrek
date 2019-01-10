using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using PointRobertsSoftware.StarTrek.Models;

namespace PointRobertsSoftware.StarTrek.ViewModels
{
    public class GalaxyVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private List<QuadrantSummary> _quadrantList;

        public GalaxyVM()
        {
            _quadrantList = new List<QuadrantSummary>();
        }

        public List<QuadrantSummary> QuadrantList => _quadrantList;

    }

    public class QuadrantSummary : INotifyPropertyChanged
    {
        public string _summary;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Summary
        {
            get { return _summary; }
        }

        public bool Active { get; set; }

        public void ChangeHandler(object sender, QuadrantChangeEventArgs e)
        {
            _summary = (e.Enemies * 100 + e.Bases * 10 + e.Stars).ToString();
            Active = e.Active;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Summary"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Active"));
        }

    }
}

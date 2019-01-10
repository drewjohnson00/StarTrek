using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using PointRobertsSoftware.StarTrek.WPFclient.Models;

namespace PointRobertsSoftware.StarTrek.WPFclient.ViewModels
{
    public class GalaxyVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private List<QuadrantSummary> _quadrantList;

        public GalaxyVM()
        {
            _quadrantList = new List<QuadrantSummary>();

            var quadrantModel = Enterprise.Instance.KnownGalaxy.Quadrants;

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    var qs = new QuadrantSummary();
                    quadrantModel[x][y].QuadrantChangeEvent += qs.ChangeHandler;
                    _quadrantList.Add(qs);
                }
            }
        }

        public List<QuadrantSummary> QuadrantList => _quadrantList;

        //private string _TestText;
        //public string TestText
        //{
        //    get { return _TestText; }
        //    set
        //    {
        //        _TestText = value;
        //        _quadrantList[0].Summary = value;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TestText"));
        //    }
        //}
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

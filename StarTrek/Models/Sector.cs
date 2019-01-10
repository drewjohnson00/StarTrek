using PointRobertsSoftware.StarTrek.Domain;

namespace PointRobertsSoftware.StarTrek.WPFclient.Models
{
    public class Sector : ISector
    {
        public SectorContent Value { get; set; }
        public char DisplayValue
        {
            get
            {
                switch (Value)
                {
                    case SectorContent.Empty: return ' ';
                    case SectorContent.Base: return 'B';
                    case SectorContent.Enterprise: return 'E';
                    case SectorContent.KlingonShip: return 'K';
                    case SectorContent.Star: return '*';
                    default: return ' ';    // TODO -- this should throw an exception
                }
            }
        }
    }
}
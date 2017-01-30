using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTrekDomain
{
    public enum SectorContent { Empty, Star, Base, Enterprise, KlingonShip}

    public interface ISector
    {
        SectorContent Value { get; }
        char DisplayValue { get; }
    }
}

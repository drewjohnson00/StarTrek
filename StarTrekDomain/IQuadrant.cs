using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointRobertsSoftware.StarTrek.Domain
{
    public interface IQuadrant
    {
        char SectorDisplayValue(int row, int col);
    }
}

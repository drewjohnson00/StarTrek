﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTrekDomain
{
    public interface IQuadrant
    {
        string QuadrantSummary();
        char SectorDisplayValue(int row, int col);
    }
}
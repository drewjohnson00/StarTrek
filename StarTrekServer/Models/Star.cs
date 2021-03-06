﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarTrekServer.Models
{
    public class Star : IEntities
    {
        private readonly EntityType _entityType;
        public Star(int QuadrantX, int QuadrantY, int SectorX, int SectorY)
        {
            _entityType = EntityType.Star;
            _quadrant = new Coordinate(QuadrantX, QuadrantY);
            _sector = new Coordinate(SectorX, SectorY);
        }

        public EntityType EntityType => _entityType;

        private Coordinate _quadrant;
        public Coordinate Quadrant
        {
            get { return _quadrant; }
        }

        private Coordinate _sector;
        public Coordinate Sector
        {
            get { return _sector; }
        }
    }
}
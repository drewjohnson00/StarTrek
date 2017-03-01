using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarTrekServer.Models
{
    public enum EntityType {  Enterprise, Star, Base, Klingon };

    public class Coordinate
    {
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }

    public interface IEntities
    {
        EntityType EntityType { get; }
        Coordinate Quadrant { get; }
        Coordinate Sector { get; }
    }
}
using StarTrekDomain;
using System;
using System.ComponentModel;

namespace StarTrek.Models
{
    public class Quadrant : IQuadrant
    {
        protected int _numberOfStars;
        protected int _numberOfBases;
        protected int _numberOfEnemies;
        protected bool _active; // true if the summary was included in the most recent Quadrant Summary message

        private Sector[][] Sectors; // Sector[Row][Col]

        public event EventHandler<QuadrantChangeEventArgs> QuadrantChangeEvent;

        public Quadrant()
        {
            Sectors = new Sector[8][];
            Sectors[0] = new Sector[8];
            Sectors[1] = new Sector[8];
            Sectors[2] = new Sector[8];
            Sectors[3] = new Sector[8];
            Sectors[4] = new Sector[8];
            Sectors[5] = new Sector[8];
            Sectors[6] = new Sector[8];
            Sectors[7] = new Sector[8];
        }


        public char SectorDisplayValue(int row, int col)
        {
            return Sectors[row][col].DisplayValue;
        }

        public void SetQuadrantSummaryValues(int stars, int bases, int enemies)
        {
            _numberOfBases = bases;
            _numberOfEnemies = enemies;
            _numberOfStars = stars;
            _active = true;
            QuadrantChangeEvent?.Invoke(this, new QuadrantChangeEventArgs { Bases = bases, Enemies=enemies, Stars = stars, Active=true });
        }

        public void SetQuadrantToInactive()
        {
            if (!_active) return;

            _active = false;
            QuadrantChangeEvent?.Invoke(this, new QuadrantChangeEventArgs { Active = false });
        }
    }

    public class QuadrantChangeEventArgs : EventArgs
    {
        public int Stars { get; set; }
        public int Bases { get; set; }
        public int Enemies { get; set; }
        public bool Active { get; set; }
    }
}

using StarTrekDomain;

namespace StarTrek.Models
{
    public class Quadrant : IQuadrant
    {
        protected int _numberOfStars;
        protected int _numberOfBases;
        protected int _numberOfEnemies;

        private Sector[][] Sectors; // Sector[Row][Col]

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


        public string QuadrantSummary()
        {
            int result = _numberOfEnemies * 100 + _numberOfBases * 10 + _numberOfStars;
            return result.ToString();
        }

        public char SectorDisplayValue(int row, int col)
        {
            // TODO -- validate row and col are in range...
            return Sectors[row][col].DisplayValue;
        }

        public void InitializeQuadrant()
        {
            int count = 0;

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++, count++)
                {
                    Sectors[row][col] = new Sector();

                    if (count % 5 == 0 && _numberOfStars < 9)
                    {
                        Sectors[row][col].Value = SectorContent.Star;
                        _numberOfStars += 1;
                    }
                    else if (count % 12 == 0 && _numberOfEnemies < 9)
                    {
                        Sectors[row][col].Value = SectorContent.KlingonShip;
                        _numberOfEnemies += 1;
                    }
                    else if (count % 200 == 0 && _numberOfBases < 9)
                    {
                        Sectors[row][col].Value = SectorContent.Base;
                        _numberOfBases += 1;
                    }
                    else
                    {
                        Sectors[row][col].Value = SectorContent.Empty;
                    }
                }
            }
        }
    }
}

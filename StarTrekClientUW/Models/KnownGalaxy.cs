namespace PointRobertsSoftware.StarTrek.Models
{
    public class KnownGalaxy
    {
        private Quadrant[][] _quadrants;

        public KnownGalaxy()
        {
            _quadrants = new Quadrant[8][];
            _quadrants[0] = new Quadrant[8];
            _quadrants[1] = new Quadrant[8];
            _quadrants[2] = new Quadrant[8];
            _quadrants[3] = new Quadrant[8];
            _quadrants[4] = new Quadrant[8];
            _quadrants[5] = new Quadrant[8];
            _quadrants[6] = new Quadrant[8];
            _quadrants[7] = new Quadrant[8];

            InitializeGalaxy();
        }

        public Quadrant[][] Quadrants => _quadrants;

        //public string QuadrantSummary(int row, int col)
        //{
        //    return _quadrants[row][col].QuadrantSummary();
        //}

        public Quadrant GetQuadrant(int row, int col)
        {
            return _quadrants[row][col];
        }

        private void InitializeGalaxy()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    _quadrants[row][col] = new Quadrant();
                    //_quadrants[row][col].InitializeQuadrant();
                }
            }
        }
    }
}

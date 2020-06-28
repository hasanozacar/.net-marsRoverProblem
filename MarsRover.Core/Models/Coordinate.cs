namespace MarsRover.Core.Models
{
    public struct Coordinate
    {
        /// <summary>
        /// Represents latitude point
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Represents longitude point
        /// </summary>
        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}

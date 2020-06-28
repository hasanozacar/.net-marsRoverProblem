using MarsRover.Core.Models;

namespace MarsRover.Core.Helpers
{
    public static class CoordinateHelper
    {
        public static bool IsValidCoordinate(Coordinate plateauCoordinate, Coordinate coordinate)
        {
            return plateauCoordinate.X >= coordinate.X
                && plateauCoordinate.Y >= coordinate.Y;
        }
    }
}

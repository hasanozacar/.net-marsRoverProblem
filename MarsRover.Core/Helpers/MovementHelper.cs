using MarsRover.Core.Models;
using System;

namespace MarsRover.Core.Helpers
{
    public static class MovementHelper
    {
        public static bool TryMoveForward(Coordinate plateauCoordinate, Position roverPosition, out Coordinate nextCoordinate)
        {
            Coordinate calculatedCoordinate = roverPosition.Coordinate;

            switch (roverPosition.CompassDirection)
            {
                case CompassDirection.North:
                    calculatedCoordinate.Y = calculatedCoordinate.Y + 1;
                    break;
                case CompassDirection.West:
                    calculatedCoordinate.X = calculatedCoordinate.X - 1;
                    break;
                case CompassDirection.South:
                    calculatedCoordinate.Y = calculatedCoordinate.Y - 1;
                    break;
                case CompassDirection.East:
                    calculatedCoordinate.X = calculatedCoordinate.X + 1;
                    break;
                default:
                    throw new ArgumentException();
            }

            bool isValidCoordinate = CoordinateHelper.IsValidCoordinate(plateauCoordinate, calculatedCoordinate);

            nextCoordinate = isValidCoordinate ? calculatedCoordinate : new Coordinate();

            return isValidCoordinate;
        }
    }
}

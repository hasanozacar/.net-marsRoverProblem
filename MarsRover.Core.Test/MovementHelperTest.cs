using Xunit;
using MarsRover.Core.Models;
using MarsRover.Core.Helpers;

namespace MarsRover.Core.Test
{
    public class MovementHelperTest
    {
        [Fact]
        public void TryMoveForwardTrueNorth()
        {
            Plateau plateau = new Plateau(new Coordinate(3, 3));

            Position roverPosition = new Position
            {
                Coordinate = new Coordinate(2, 2),
                CompassDirection = CompassDirection.North
            };

            Coordinate expectedValue = new Coordinate(2, 3);

            bool result = MovementHelper.TryMoveForward(plateau.plateauCoordinate, roverPosition, out Coordinate nextCoordinate);

            Assert.True(result);
            Assert.Equal(expectedValue, nextCoordinate);
        }

        [Fact]
        public void TryMoveForwardTrueWest()
        {
            Plateau plateau = new Plateau(new Coordinate(3, 3));

            Position roverPosition = new Position
            {
                Coordinate = new Coordinate(3, 3),
                CompassDirection = CompassDirection.West
            };

            Coordinate expectedValue = new Coordinate(2, 3);

            bool result = MovementHelper.TryMoveForward(plateau.plateauCoordinate, roverPosition, out Coordinate nextCoordinate);

            Assert.True(result);
            Assert.Equal(expectedValue, nextCoordinate);
        }

        [Fact]
        public void TryMoveForwardTrueSouth()
        {
            Plateau plateau = new Plateau(new Coordinate(3, 3));

            Position roverPosition = new Position
            {
                Coordinate = new Coordinate(1, 2),
                CompassDirection = CompassDirection.South
            };

            Coordinate expectedValue = new Coordinate(1, 1);

            bool result = MovementHelper.TryMoveForward(plateau.plateauCoordinate, roverPosition, out Coordinate nextCoordinate);

            Assert.True(result);
            Assert.Equal(expectedValue, nextCoordinate);
        }

        [Fact]
        public void TryMoveForwardTrueEast()
        {
            Plateau plateau = new Plateau(new Coordinate(3, 3));

            Position roverPosition = new Position
            {
                Coordinate = new Coordinate(1, 1),
                CompassDirection = CompassDirection.East
            };

            Coordinate expectedValue = new Coordinate(2, 1);

            bool result = MovementHelper.TryMoveForward(plateau.plateauCoordinate, roverPosition, out Coordinate nextCoordinate);

            Assert.True(result);
            Assert.Equal(expectedValue, nextCoordinate);
        }

        [Fact]
        public void TryMoveForwardFalseNorth()
        {
            Plateau plateau = new Plateau(new Coordinate(3, 3));

            Position roverPosition = new Position
            {
                Coordinate = new Coordinate(2, 3),
                CompassDirection = CompassDirection.North
            };

            bool result = MovementHelper.TryMoveForward(plateau.plateauCoordinate, roverPosition, out Coordinate nextCoordinate);

            Assert.False(result);
            Assert.Equal(default(Coordinate), nextCoordinate);
        }

        [Fact]
        public void TryMoveForwardFalseEast()
        {
            Plateau plateau = new Plateau(new Coordinate(3, 3));

            Position roverPosition = new Position
            {
                Coordinate = new Coordinate(3, 2),
                CompassDirection = CompassDirection.East
            };

            bool result = MovementHelper.TryMoveForward(plateau.plateauCoordinate, roverPosition, out Coordinate nextCoordinate);

            Assert.False(result);
            Assert.Equal(default(Coordinate), nextCoordinate);
        }

    }
}

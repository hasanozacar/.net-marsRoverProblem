using Xunit;
using MarsRover.Core.Models;
using MarsRover.Core.Helpers;

namespace MarsRover.Core.Test
{
    public class CoordinateHelperTest
    {
        [Fact]
        public void ValidCoordinate()
        {
            Plateau plateau = new Plateau( new Coordinate(3, 3));

            Assert.True(CoordinateHelper.IsValidCoordinate(plateau.plateauCoordinate, new Coordinate(2, 2)));
            Assert.True(CoordinateHelper.IsValidCoordinate(plateau.plateauCoordinate, new Coordinate(1, 3)));
            Assert.True(CoordinateHelper.IsValidCoordinate(plateau.plateauCoordinate, new Coordinate(3, 1)));
        }

        [Fact]
        public void InValidCoordinate()
        {
            Plateau plateau = new Plateau(new Coordinate(1, 1));

            Assert.False(CoordinateHelper.IsValidCoordinate(plateau.plateauCoordinate, new Coordinate(-1, 3)));
            Assert.False(CoordinateHelper.IsValidCoordinate(plateau.plateauCoordinate, new Coordinate(-1, 4)));
        }
    }
}

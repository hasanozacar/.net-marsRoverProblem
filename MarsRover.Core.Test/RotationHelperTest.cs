using Xunit;
using MarsRover.Core.Models;
using MarsRover.Core.Helpers;
using MarsRover.Core.Exceptions;

namespace MarsRover.Core.Test
{
    public class RotationHelperTest
    {
        [Fact]
        public void RotateClockwise()
        {
            var expectedValue = CompassDirection.East;
            var result = RotationHelper.Rotate(CompassDirection.North, RotationDirection.Clockwise);

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void RotateCounterClockwise()
        {
            var expectedValue = CompassDirection.East;
            var result = RotationHelper.Rotate(CompassDirection.South, RotationDirection.CounterClockwise);

            Assert.Equal(expectedValue, result);
        }
    }
}

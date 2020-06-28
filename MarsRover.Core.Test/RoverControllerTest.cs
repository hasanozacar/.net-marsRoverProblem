using System;
using System.Text;
using MarsRover.Core.Exceptions;
using Xunit;
using MarsRover.Core.Repositories;
using MarsRover.Core.Interfaces;
using MarsRover.Core.Models;

namespace MarsRover.Core.Test
{
    public class RoverControllerTest
    {
        [Fact]
        public void Deploy()
        {
            var rover = RoverController.GetRoverController().Deploy(
                new Plateau(new Coordinate(3, 3)),
                "2 2 S"
                );

            var expectedPosition = new Position
            {
                Coordinate = new Coordinate(2, 2),
                CompassDirection = CompassDirection.South
            };

            Assert.NotNull(rover);
            Assert.Equal(expectedPosition, rover.Position);
        }

        [Fact]
        public void DeployThrowsRoverDeploymentException()
        {
            Action action = () => RoverController.GetRoverController().Deploy(
                new Plateau(new Coordinate(3, 3)),
                "3 4 S"
                );

            Assert.Throws<RoverDeploymentException>(action);
        }

        [Fact]
        public void DeployThrowsRoverDeploymentException2()
        {
            Action action = () => RoverController.GetRoverController().Deploy(
                new Plateau(new Coordinate(3, 3)),
                "5 2 W"
                );

            Assert.Throws<RoverDeploymentException>(action);
        }

        [Fact]
        public void DeployThrowsRoverDeploymentException3()
        {
            Action action = () => RoverController.GetRoverController().Deploy(
                new Plateau(new Coordinate(3, 3)),
                "2 2 A"
                );

            Assert.Throws<RoverDeploymentException>(action);
        }
    }
}

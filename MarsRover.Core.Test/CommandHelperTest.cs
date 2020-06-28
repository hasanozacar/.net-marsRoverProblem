using System.Collections.Generic;
using System.Text;
using Xunit;
using MarsRover.Core.Models;
using MarsRover.Core.Helpers;

namespace MarsRover.Core.Test
{
    public class CommandHelperTest
    {
        #region TryParseInputCommand
        [Fact]
        public void ValidInputCommand()
        {
            string inputCommand = new StringBuilder()
                .Append("5 5")
                .Append('\n')
                .Append("1 2 N")
                .Append('\n')
                .Append("LMLMLMLMM")
                .ToString();

            bool result = CommandHelper.ParseCommand(inputCommand
                , out string plateauUpperCoordinateCommand
                , out IList<string> initialRoverPositionCommands
                , out IList<string> movementCommands);

            Assert.True(result);
            Assert.Equal("5 5", plateauUpperCoordinateCommand);
            Assert.Equal("1 2 N", initialRoverPositionCommands[0]);
            Assert.Equal("LMLMLMLMM", movementCommands[0]);
        }

        #endregion

        #region IsValidPlateauUpperCoordinateCommand
        [Fact]
        public void ValidPlateauUpperCoordinateCommand()
        {
            string validCommand = "7 8";
            bool result = CommandHelper.IsValidPlateau(validCommand);
            Assert.True(result);
        }

        [Fact]
        public void InvalidPlateauUpperCoordinateCommandWithoutWhiteSpace()
        {
            string validCommand = "78";
            bool result = CommandHelper.IsValidPlateau(validCommand);
            Assert.False(result);
        }

        [Fact]
        public void InvalidPlateauUpperCoordinateCommandTooLongCommand()
        {
            string validCommand = "7 8 ";
            bool result = CommandHelper.IsValidPlateau(validCommand);
            Assert.False(result);
        }

        [Fact]
        public void InvalidPlateauUpperCoordinateCommandTooLongCommand2()
        {
            string validCommand = " 7 8";
            bool result = CommandHelper.IsValidPlateau(validCommand);
            Assert.False(result);
        }

        [Fact]
        public void InvalidPlateauUpperCoordinateCommandNonNumeric()
        {
            string validCommand = "a 8";
            bool result = CommandHelper.IsValidPlateau(validCommand);
            Assert.False(result);
        }

        [Fact]
        public void InvalidPlateauUpperCoordinateCommandNonNumeric2()
        {
            string validCommand = "1 a";
            bool result = CommandHelper.IsValidPlateau(validCommand);
            Assert.False(result);
        }
        #endregion

        #region IsValidInitialRoverPositionCommand
        [Fact]
        public void ValidInitialRoverPositionCommand()
        {
            Coordinate plateauCoordinate = new Coordinate(3, 3);
            string command = "1 3 W";
            bool result = CommandHelper.IsValidInitialRover(plateauCoordinate, command);
            Assert.True(result);
        }

        [Fact]
        public void InvalidInitialRoverPositionCommandWithoutWhiteSpace()
        {
            Coordinate plateauCoordinate = new Coordinate(1, 1);
            Coordinate plateauUpperCoordinate = new Coordinate(3, 3);
            string command = "22E";
            bool result = CommandHelper.IsValidInitialRover(plateauCoordinate, command);
            Assert.False(result);
        }

        [Fact]
        public void InvalidInitialRoverPositionCommandTooLongCommand2()
        {
            Coordinate plateauCoordinate = new Coordinate(1, 1);
            Coordinate plateauUpperCoordinate = new Coordinate(3, 3);
            string command = " 2 1 N";
            bool result = CommandHelper.IsValidInitialRover(plateauCoordinate, command);
            Assert.False(result);
        }

        [Fact]
        public void InvalidInitialRoverPositionCommandTooLongCommand3()
        {
            Coordinate plateauCoordinate = new Coordinate(1, 1);
            Coordinate plateauUpperCoordinate = new Coordinate(3, 3);
            string command = "2 1  N";
            bool result = CommandHelper.IsValidInitialRover(plateauCoordinate, command);
            Assert.False(result);
        }

        [Fact]
        public void InvalidInitialRoverPositionCommandNonNumeric2()
        {
            Coordinate plateauCoordinate = new Coordinate(1, 1);
            Coordinate plateauUpperCoordinate = new Coordinate(3, 3);
            string command = "1 y W";
            bool result = CommandHelper.IsValidInitialRover(plateauCoordinate, command);
            Assert.False(result);
        }

        [Fact]
        public void InvalidInitialRoverPositionCommandInvalidCompassDirection()
        {
            Coordinate plateauCoordinate = new Coordinate(1, 1);
            Coordinate plateauUpperCoordinate = new Coordinate(3, 3);
            string command = "2 2 A";
            bool result = CommandHelper.IsValidInitialRover(plateauCoordinate, command);
            Assert.False(result);
        }
        #endregion

        #region IsValidCompass

        [Fact]
        public void ValidCompassDirectionChar()
        {
            Assert.True(CommandHelper.IsValidCompass("W"));
        }

        [Fact]
        public void InvalidCompassDirectionChar()
        {
            Assert.False(CommandHelper.IsValidCompass("X"));
        }
        #endregion

        #region IsValidMovement
        [Fact]
        public void ValidMovementCommand()
        {
            Assert.True(CommandHelper.IsValidMovement("LMRLMRLMR"));
        }

        [Fact]
        public void InvalidMovementCommandInvalidChar()
        {
            Assert.False(CommandHelper.IsValidMovement("LMRXLMR"));
        }

        [Fact]
        public void InvalidMovementCommandWithWhiteSpace()
        {
            Assert.False(CommandHelper.IsValidMovement("LMR LMR"));
        }
        #endregion
    }
}

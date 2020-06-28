using MarsRover.Core.Interfaces;
using MarsRover.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.Core.Helpers
{
    public static class CommandHelper
    {
        static readonly char[] COMPASS_DIRECTION_COMMAND_CHARS = new char[] { 'N', 'E', 'S', 'W' };
        static readonly char[] MOVEMENT_COMMAND_CHARS = new char[] { 'L', 'R', 'M' };
        static readonly char[] ROTATION_COMMAND_CHARS = new char[] { 'L', 'R' };
        static readonly char MOVE_FORWARD_COMMAND_CHAR = 'M';

        public static bool ParseCommand(string command, out string spaceLimitInfo, out IList<string> starLocationInfo, out IList<string> movementCommands)
        {
            // Valid input command format must be "{0}\n{1}\n{2}..."
            string[] parseCommandList = command.Split('\n');

            // valid input command has 2n+1 lines
            spaceLimitInfo = null;
            starLocationInfo = new List<string>();
            movementCommands = new List<string>();
            var controlCommand = (parseCommandList.Length >= 3);

            if (controlCommand)
            {
                spaceLimitInfo = parseCommandList[0];

                if (IsValidPlateau(spaceLimitInfo))
                {
                    var plateauUpperCoordinate = CommandHelper.GetCoordinate(spaceLimitInfo);

                    // assumed that lower coordinate of plateau is (0,0)

                    for (int i = 1; i < parseCommandList.Length; i = i + 2)
                    {
                        var isValidCommand = IsValidInitialRover(plateauUpperCoordinate, parseCommandList[i])
                             && IsValidMovement(parseCommandList[i + 1]);

                        if (!isValidCommand)
                            break;

                        starLocationInfo.Add(parseCommandList[i]);
                        movementCommands.Add(parseCommandList[i + 1]);
                    }
                }
            }
            else
            {
                controlCommand = false;
            }
            return controlCommand;
        }

        public static bool IsValidPlateau(string command)
        {
            // Valid plateau upper coordinate command format must be "{0} {1}"
            return command.Length == 3
                && command[1] == ' '
                && int.TryParse(command[0].ToString(), out int plateauUpperCoordinateX) && plateauUpperCoordinateX > 0
                && int.TryParse(command[2].ToString(), out int plateauUpperCoordinateY) && plateauUpperCoordinateY > 0;
        }

        public static bool IsValidInitialRover(Coordinate plateauCoordinate, string command)
        {
            // Valid initial rover position command format must be "{0} {1} {2}"
            return command.Length == 5
                && command[1] == ' ' && command[3] == ' '
                && int.TryParse(command[0].ToString(), out int roverPositionCoordinateX)
                && int.TryParse(command[2].ToString(), out int roverPositionCoordinateY)
                && CoordinateHelper.IsValidCoordinate(plateauCoordinate
                    , new Coordinate
                    {
                        X = roverPositionCoordinateX,
                        Y = roverPositionCoordinateY
                    })
                && IsValidCompass(command[4].ToString());
        }

        public static bool IsValidCompass(string command)
        {
            return !string.IsNullOrEmpty(command)
                && char.TryParse(command, out char commandChar)
                && COMPASS_DIRECTION_COMMAND_CHARS.Contains(commandChar);
        }

        public static bool IsValidMovement(string command)
        {
            // Valid movement command contains only MOVEMENT_COMMAND_CHARS chars, without whitespace
            foreach (var item in command)
            {
                if (!MOVEMENT_COMMAND_CHARS.Contains(item))
                    return false;
            }

            return true;
        }

        public static bool IsMoveForward(char command)
        {
            return char.Equals(command, MOVE_FORWARD_COMMAND_CHAR);
        }

        /// <summary>
        /// Validate coordinate before call.
        /// </summary>
        public static Coordinate GetCoordinate(string command)
        {
            int coordinateX = int.Parse(command[0].ToString());
            int coordinateY = int.Parse(command[2].ToString());

            return new Coordinate(coordinateX, coordinateY);
        }

        /// <summary>
        /// Validate coordinate before call.
        /// </summary>
        public static Position GetPositionFromCommand(string command)
        {
            return new Position
            {
                CompassDirection = Utilities.Utility.GetCompass(command[4].ToString()),
                Coordinate = new Coordinate
                {
                    X = int.Parse(command[0].ToString()),
                    Y = int.Parse(command[2].ToString()),
                }
            };
        }

        public static string GetOutputStringFinalRoverPositions(IList<IRover> rovers)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < rovers.Count; i++)
            {
                stringBuilder.Append(rovers[i].ToString());

                if (i != rovers.Count - 1)
                    stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }
    }
}

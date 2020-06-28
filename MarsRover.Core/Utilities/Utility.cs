using MarsRover.Core.Models;
using System;

namespace MarsRover.Core.Utilities
{
    public static class Utility
    {
        public static char GetCharByCompassDirection(this CompassDirection compassDirection)
        {
            char compassDirectionByChar;

            switch (compassDirection)
            {
                case CompassDirection.North:
                    compassDirectionByChar = 'N';
                    break;
                case CompassDirection.West:
                    compassDirectionByChar = 'W';
                    break;
                case CompassDirection.South:
                    compassDirectionByChar = 'S';
                    break;
                case CompassDirection.East:
                    compassDirectionByChar = 'E';
                    break;
                default:
                    throw new ArgumentException();
            }

            return compassDirectionByChar;
        }

        public static CompassDirection GetCompass(string command)
        {
            CompassDirection compassDirection;

            char character = char.Parse(command);

            switch (character)
            {
                case 'N':
                    compassDirection = CompassDirection.North;
                    break;
                case 'W':
                    compassDirection = CompassDirection.West;
                    break;
                case 'S':
                    compassDirection = CompassDirection.South;
                    break;
                case 'E':
                    compassDirection = CompassDirection.East;
                    break;
                default:
                    throw new ArgumentException();
            }

            return compassDirection;
        }

        public static RotationDirection GetRotationDirectionByChar(char command)
        {
            RotationDirection rotationDirection;

            switch (command)
            {
                case 'L':
                    rotationDirection = RotationDirection.CounterClockwise;
                    break;
                case 'R':
                    rotationDirection = RotationDirection.Clockwise;
                    break;
                default:
                    throw new ArgumentException();
            }

            return rotationDirection;
        }
    }
}

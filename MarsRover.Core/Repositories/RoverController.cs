using MarsRover.Core.Exceptions;
using MarsRover.Core.Helpers;
using MarsRover.Core.Interfaces;
using MarsRover.Core.Models;
using MarsRover.Core.Utilities;
using System;
using System.Collections.Generic;

namespace MarsRover.Core.Repositories
{
    public sealed class RoverController : IRoverController
    {
        public IList<IRover> RoverRepository { get { return this.roverRepository; } }
        readonly IList<IRover> roverRepository;

        static IRoverController instance;
        static readonly object locker = new object();

        private RoverController()
        {
            this.roverRepository = new List<IRover>();
        }

        public static IRoverController GetRoverController()
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new RoverController();
                    }
                }
            }

            return instance;
        }

        public IRover Deploy(IPlateau plateau, string command)
        {
            bool isValidCommand = CommandHelper.IsValidInitialRover(plateau.plateauCoordinate, command);

            if (isValidCommand)
            {
                Position position = CommandHelper.GetPositionFromCommand(command);
                IRover rover = new Rover
                {
                    Id = Guid.NewGuid(),
                    Position = position
                };

                this.roverRepository.Add(rover);

                return rover;
            }
            else
            {
                throw new RoverDeploymentException("Rover Could not be deployed");
            }
        }

        public void ExecuteMovement(IPlateau plateau, IRover rover, string movementCommands)
        {
            bool isValidCommand = CommandHelper.IsValidMovement(movementCommands);

            if (isValidCommand)
            {
                foreach (var command in movementCommands)
                {
                    if (CommandHelper.IsMoveForward(command))
                    {
                        this.MoveForward(plateau, rover, command);
                    }
                    else
                    {
                        this.Rotate(rover, command);
                    }
                }
            }
            else
            {
                throw new MovementException("Rover could not be moved");
            }
        }

        void Rotate(IRover rover, char command)
        {
            RotationDirection rotationDirection = Utility.GetRotationDirectionByChar(command);
            CompassDirection nextCompassDirection = RotationHelper.Rotate(rover.Position.CompassDirection, rotationDirection);

            rover.Position = new Position
            {
                Coordinate = rover.Position.Coordinate,
                CompassDirection = nextCompassDirection
            };
        }

        void MoveForward(IPlateau plateau, IRover rover, char command)
        {
            bool isValidMovementForward = MovementHelper.TryMoveForward(plateau.plateauCoordinate, rover.Position, out Coordinate nextCoordinate);

            if (isValidMovementForward)
            {
                rover.Position = new Position
                {
                    CompassDirection = rover.Position.CompassDirection,
                    Coordinate = nextCoordinate
                };
            }
        }
    }

}

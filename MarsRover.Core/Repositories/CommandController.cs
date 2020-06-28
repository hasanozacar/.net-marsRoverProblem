using System;
using MarsRover.Core.Interfaces;
using MarsRover.Core.Helpers;
using MarsRover.Core.Exceptions;
using MarsRover.Core.Models;
using System.Collections.Generic;

namespace MarsRover.Core.Repositories
{
    //[ScopedDependency]
    public class CommandController : ICommandController
    {
        static ICommandController instance;
        static readonly object locker = new object();

        private CommandController() { }

        public static ICommandController GetCommandController()
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new CommandController();
                    }
                }
            }

            return instance;
        }

        public CommandExecutionResponseModel ExecuteCommand(string command)
        {
            CommandExecutionResponseModel responseModel = new CommandExecutionResponseModel();
            if (CommandHelper.ParseCommand(command, out string   spaceLimitInfo, out IList<string>   starLocationInfo, out IList<string> movementCommands))
            {
                Coordinate plateauUpperCoordinate = CommandHelper.GetCoordinate(spaceLimitInfo);

                // ConcretePlateau 
                var plateau = ConcretePlateau.GetPlateau(plateauUpperCoordinate);

                try
                {
                    for (int i = 0; i <   starLocationInfo.Count; i++)
                    {
                        IRover rover = RoverController.GetRoverController().Deploy(plateau,   starLocationInfo[i]);
                    }

                    for (int i = 0; i < RoverController.GetRoverController().RoverRepository.Count; i++)
                    {
                        RoverController.GetRoverController().ExecuteMovement(plateau, RoverController.GetRoverController().RoverRepository[i], movementCommands[i]);
                    }
                }
                catch (CommandException commandException)
                {
                    responseModel.IsSuccess = false;
                    responseModel.ErrorMessage = commandException.Message;
                }
                catch (Exception)
                {
                    responseModel.IsSuccess = false;
                    responseModel.ErrorMessage = "Fatal Error!";
                }

                responseModel.IsSuccess = true;
                responseModel.Output = CommandHelper.GetOutputStringFinalRoverPositions(RoverController.GetRoverController().RoverRepository);

                return responseModel;
            }
            else
            {
                throw new CommandException("Invalid Input command");
            }
        }
    }
}

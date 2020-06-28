using MarsRover.Core.Models;

namespace MarsRover.Core.Interfaces
{
    public interface ICommandController
    {
        CommandExecutionResponseModel ExecuteCommand(string command);
    }
}

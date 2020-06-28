using System.Collections.Generic;

namespace MarsRover.Core.Interfaces
{
    public interface IRoverController
    {
        IList<IRover> RoverRepository { get; }
        IRover Deploy(IPlateau plateau, string command);
        void ExecuteMovement(IPlateau plateau, IRover rover, string movementCommands);
    }
}

using MarsRover.Core.Models;
using System;

namespace MarsRover.Core.Interfaces
{
    public interface IRover
    {
        Guid Id { get; set; }
        Position Position { get; set; }
    }
}

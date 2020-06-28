using MarsRover.Core.Interfaces;

namespace MarsRover.Core.Models
{
    public class Plateau : IPlateau
    {
        public Coordinate plateauCoordinate { get; }

        public Plateau(Coordinate plateauCoordinate)
        {
            this.plateauCoordinate = plateauCoordinate;
        }
    }
}

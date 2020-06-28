using MarsRover.Core.Interfaces;
using MarsRover.Core.Utilities;
using System;
using System.Text;

namespace MarsRover.Core.Models
{
    public class Rover : IRover
    {
        public Guid Id { get; set; }
        public Position Position { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder
                .Append(this.Position.Coordinate.X.ToString())
                .Append(" ")
                .Append(this.Position.Coordinate.Y.ToString())
                .Append(" ")
                .Append(this.Position.CompassDirection.GetCharByCompassDirection().ToString());

            return stringBuilder.ToString();
        }
    }
}

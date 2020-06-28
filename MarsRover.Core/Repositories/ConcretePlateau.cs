using MarsRover.Core.Models;
using System;

namespace MarsRover.Core.Repositories
{
    public sealed class ConcretePlateau
    {
        static Plateau instance;
        static readonly object locker = new object();

        private ConcretePlateau() { }

        /// <summary>
        /// Initializes a new Plateau with given upperCoordinate parameter for once.
        /// Returns instance if the Plateau has already initialized.
        /// </summary>
        public static Plateau GetPlateau(Coordinate upperCoordinate)
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new Plateau(upperCoordinate);
                    }
                }
            }

            return instance;
        }

        /// <summary>
        /// Returns instance of the Plateau.
        /// Throws NullReferenceException if a Plateau has not initialized.
        /// </summary>
        public static Plateau GetPlateau()
        {
            if (instance == null)
            {
                throw new NullReferenceException();
            }

            return instance;
        }
    }
}

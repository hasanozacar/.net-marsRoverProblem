using System;
using System.Text;

namespace MarsRover.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {


            const string header = @"
            |
           / \
          / _ \
         |.o '.|
         |'._.'|
         |     |
       ,'|  |  |`.
      /  |  |  |  \
      |,-'--|--'-.|   ";

            Console.WriteLine(header);

            Console.WriteLine("\nMARS ROVERS PROBLEMS");

            // Get space limit
            Console.WriteLine("\n Space of Coordinate limits (X Y) : ");
            string spaceLimits = Console.ReadLine().ToUpper();
            string[] spaceLimitInfo = spaceLimits.Split(' ');

            // Get start coordinate
            Console.WriteLine("Start Location Coordinate (X Y n) : ");
            string startLocation = Console.ReadLine().ToUpper();
            string[] starLocationInfo = startLocation.Split(' ');

            // Get move list
            Console.WriteLine("Movement list (L,R or M): ");
            string movement = Console.ReadLine().ToUpper();
            char[] moveList = movement.ToCharArray();

            string inputCommand = GetInputString(spaceLimits, startLocation, movement);

            Console.WriteLine("\ninput is :\n" + inputCommand);

            var response = MarsRover.Core.Repositories.CommandController.GetCommandController().ExecuteCommand(inputCommand);

            Console.WriteLine("\noutput is:");
            Console.WriteLine(response.IsSuccess ? response.Output : response.ErrorMessage);

            Console.ReadLine();
        }

        static string GetInputString(string spaceLimits, string startLocation, string movement)
        {
            return new StringBuilder()
                .Append(spaceLimits)
                .Append('\n')
                .Append(startLocation)
                .Append('\n')
                .Append(movement)
                .ToString();
        }

    }
}

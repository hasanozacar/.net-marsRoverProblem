using System;
using System.Text;
using MarsRover.Core.Exceptions;
using Xunit;
using MarsRover.Core.Repositories;

namespace MarsRover.Core.Test
{
    public class CommandControllerTest
    {
        [Fact]
        public void ValidExecuteCommand()
        {
            string inputCommand = new StringBuilder()
               .Append("5 5")
               .Append('\n')
               .Append("1 2 N")
               .Append('\n')
               .Append("LMLMLMLMM")
               .ToString();

            var response = CommandController.GetCommandController().ExecuteCommand(inputCommand);

            string expectedOutput = "1 3 N";

            Assert.True(response.IsSuccess);
            Assert.True(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.Equal(expectedOutput, response.Output);
        }
    }
}

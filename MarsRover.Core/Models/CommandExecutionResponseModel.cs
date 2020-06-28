namespace MarsRover.Core.Models
{
    public class CommandExecutionResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Output { get; set; }
        public string ErrorMessage { get; set; }
    }
}

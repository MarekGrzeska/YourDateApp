using MediatR;

namespace YourDateApp.Application.Commands.SetMessagesReceived
{
    public class SetMessagesReceivedCommand : IRequest
    {
        public string UsernameFrom { get; set; }
        public string UsernameTo { get; set; }

        public SetMessagesReceivedCommand(string usernameFrom, string usernameTo)
        {
            UsernameFrom = usernameFrom;
            UsernameTo = usernameTo;
        }
    }
}

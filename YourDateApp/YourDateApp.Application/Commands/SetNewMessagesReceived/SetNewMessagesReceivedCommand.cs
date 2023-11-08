using MediatR;

namespace YourDateApp.Application.Commands.SetNewMessagesReceived
{
    public class SetNewMessagesReceivedCommand : IRequest
    {
        public string UsernameFrom { get; set; }
        public string UsernameTo { get; set; }

        public SetNewMessagesReceivedCommand(string usernameFrom, string usernameTo)
        {
            UsernameFrom = usernameFrom;
            UsernameTo = usernameTo;
        }
    }
}

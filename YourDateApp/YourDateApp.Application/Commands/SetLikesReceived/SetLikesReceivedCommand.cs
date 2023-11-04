using MediatR;

namespace YourDateApp.Application.Commands.SetLikesReceived
{
    public class SetLikesReceivedCommand : IRequest
    {
        public string Username { get; set; }

        public SetLikesReceivedCommand(string username)
        {
            Username = username;
        }
    }
}

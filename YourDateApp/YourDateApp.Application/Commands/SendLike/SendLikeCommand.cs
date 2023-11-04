using MediatR;

namespace YourDateApp.Application.Commands.SendLike
{
    public class SendLikeCommand : IRequest
    { 
        public string UserFrom { get; set; }
        public string UserTo { get; set; }

        public SendLikeCommand(string userFrom, string userTo) 
        {
            UserFrom = userFrom;
            UserTo = userTo;
        }
    }
}

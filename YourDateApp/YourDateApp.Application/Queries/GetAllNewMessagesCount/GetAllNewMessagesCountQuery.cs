using MediatR;

namespace YourDateApp.Application.Queries.GetAllNewMessagesCount
{
    public class GetAllNewMessagesCountQuery : IRequest<int>
    {
        public string Username { get; set; }

        public GetAllNewMessagesCountQuery(string username)
        {
            Username = username;
        }
    }
}
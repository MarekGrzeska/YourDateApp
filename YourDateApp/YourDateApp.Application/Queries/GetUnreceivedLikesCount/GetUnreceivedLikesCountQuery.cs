using MediatR;

namespace YourDateApp.Application.Queries.GetUnreceivedLikesCount
{
    public class GetUnreceivedLikesCountQuery : IRequest<int>
    {
        public string Username { get; set; }

        public GetUnreceivedLikesCountQuery(string username) 
        {
            Username = username;
        }
    }
}

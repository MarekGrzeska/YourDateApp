using MediatR;
using YourDateApp.Domain.Interfaces;

namespace YourDateApp.Application.Queries.GetUnreceivedLikesCount
{
    public class GetUnreceivedLikesCountQueryHandler : IRequestHandler<GetUnreceivedLikesCountQuery, int>
    {
        private readonly ILikeRepository _likeRepository;

        public GetUnreceivedLikesCountQueryHandler(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public async Task<int> Handle(GetUnreceivedLikesCountQuery request, CancellationToken cancellationToken)
        {
            var receivedLikes = await _likeRepository.GetUserReceivedLikes(request.Username)!;
            return receivedLikes.Count(l => l.IsReceived == false);
        }
    }
}
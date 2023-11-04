using MediatR;
using YourDateApp.Domain.Interfaces;

namespace YourDateApp.Application.Commands.SetLikesReceived
{
    public class SetLikesReceivedCommandHandler : IRequestHandler<SetLikesReceivedCommand>
    {
        private readonly ILikeRepository _likeRepository;

        public SetLikesReceivedCommandHandler(ILikeRepository likeRepository) 
        {
            _likeRepository = likeRepository;
        }

        public async Task<Unit> Handle(SetLikesReceivedCommand request, CancellationToken cancellationToken)
        {
            var receivedLikes = await _likeRepository.GetUserReceivedLikes(request.Username)!;
            foreach (var like in receivedLikes)
                like.IsReceived = true;
            await _likeRepository.Commit();
            return Unit.Value;
        }
    }
}
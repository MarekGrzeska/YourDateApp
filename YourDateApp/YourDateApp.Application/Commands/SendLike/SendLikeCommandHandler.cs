using MediatR;
using YourDateApp.Domain.Entities;
using YourDateApp.Domain.Interfaces;

namespace YourDateApp.Application.Commands.SendLike
{
    public class SendLikeCommandHandler : IRequestHandler<SendLikeCommand>
    {
        private readonly ILikeRepository _likeRepository;

        public SendLikeCommandHandler(ILikeRepository likeRepository) 
        {
            _likeRepository = likeRepository;
        }

        public async Task<Unit> Handle(SendLikeCommand request, CancellationToken cancellationToken)
        {
            var like = new Like()
            {
                UsernameFrom = request.UserFrom,
                UsernameTo = request.UserTo,
                SentDate = DateTime.Now,
                IsReceived = false,
            };
            await _likeRepository.SendLike(like);

            return Unit.Value;
        }
    }
}
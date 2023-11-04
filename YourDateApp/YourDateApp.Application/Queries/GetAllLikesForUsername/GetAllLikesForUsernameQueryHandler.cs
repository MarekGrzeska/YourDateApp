using AutoMapper;
using MediatR;
using YourDateApp.Application.Dtos;
using YourDateApp.Domain.Interfaces;

namespace YourDateApp.Application.Queries.GetAllLikesForUsername
{
    public class GetAllLikesForUsernameQueryHandler : IRequestHandler<GetAllLikesForUsernameQuery, UserLikesDto>
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IMapper _mapper;

        public GetAllLikesForUsernameQueryHandler(ILikeRepository likeRepository, IMapper mapper) 
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
        }

        public async Task<UserLikesDto> Handle(GetAllLikesForUsernameQuery request, CancellationToken cancellationToken)
        {
            var recivedLikes = await _likeRepository.GetUserReceivedLikes(request.Username);
            var sendedLikes = await _likeRepository.GetUserSendedLikes(request.Username);

            var userLikesDto = new UserLikesDto()
            {
                ReceivedLikes = _mapper.Map<List<LikeDto>>(recivedLikes),
                SendedLikes = _mapper.Map<List<LikeDto>>(sendedLikes),
            };
            return userLikesDto;
        }
    }
}
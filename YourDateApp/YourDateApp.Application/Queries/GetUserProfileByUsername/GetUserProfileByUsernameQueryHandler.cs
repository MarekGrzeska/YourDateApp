using AutoMapper;
using MediatR;
using YourDateApp.Application.Dtos;
using YourDateApp.Domain.Interfaces;

namespace YourDateApp.Application.Queries.GetUserProfileByUsername
{
    public class GetUserProfileByUsernameQueryHandler : IRequestHandler<GetUserProfileByUsernameQuery, UserProfileDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        
        public GetUserProfileByUsernameQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserProfileDto> Handle(GetUserProfileByUsernameQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUsername(request.Username);
            var userProfileDto = _mapper.Map<UserProfileDto>(user);
            return userProfileDto;
        }
    }
}
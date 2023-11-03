using AutoMapper;
using MediatR;
using YourDateApp.Application.Dtos;
using YourDateApp.Domain.Interfaces;

namespace YourDateApp.Application.Queries.GetAllUserProfiles
{
    public class GetAllUserProfilesQueryHandler : IRequestHandler<GetAllUserProfilesQuery, IEnumerable<UserProfileDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUserProfilesQueryHandler(IUserRepository userRepository, IMapper mapper) 
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserProfileDto>> Handle(GetAllUserProfilesQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAll();
            var profiles = _mapper.Map<IEnumerable<UserProfileDto>>(users);
            return profiles;
        }
    }
}
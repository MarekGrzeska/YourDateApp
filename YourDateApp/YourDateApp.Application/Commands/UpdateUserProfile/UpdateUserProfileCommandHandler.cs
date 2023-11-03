using AutoMapper;
using MediatR;
using YourDateApp.Application.Dtos;
using YourDateApp.Application.Services;
using YourDateApp.Domain.Interfaces;
using YourDateApp.Domain.Entities;

namespace YourDateApp.Application.Commands.UpdateUserProfile
{
    public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IProfilePhotoService _profilePhotoService;
        private readonly IMapper _mapper;

        public UpdateUserProfileCommandHandler(IUserRepository userRepository, 
            IProfilePhotoService profilePhotoService, IMapper mapper) 
        {
            _userRepository = userRepository;
            _profilePhotoService = profilePhotoService;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<UserProfileDto>(request);
            request.PhotoSrc = _profilePhotoService.SavePhoto(dto);
            var user = await _userRepository.GetByUsername(request.Username);

            if (user.Profile == null) user.Profile = new ProfileInfo();
            user.Profile.FirstName = request.FirstName;
            user.Profile.LastName = request.LastName;
            user.Profile.Country = request.Country;
            user.Profile.City = request.City;
            user.Profile.Age = request.Age;
            if (request.PhotoSrc != null) user.Profile.PhotoSrc = request.PhotoSrc;
            await _userRepository.Commit();

            return Unit.Value;
        }
    }
}

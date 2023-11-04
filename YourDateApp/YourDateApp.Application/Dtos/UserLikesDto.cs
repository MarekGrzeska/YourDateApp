namespace YourDateApp.Application.Dtos
{
    public class UserLikesDto
    {
        public List<LikeDto>? ReceivedLikes { get; set; }
        public List<LikeDto>? SendedLikes { get; set; }
    }
}

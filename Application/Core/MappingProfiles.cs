using Application.Activities;
using Application.Comments;
using AutoMapper;
using Domain.Model;
using System.Linq;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfiles"/> class.
        /// </summary>
        public MappingProfiles()
        {

            string currentUserName = string.Empty;

            CreateMap<Activity, Activity>();
            CreateMap<Activity, ActivityDto>()
                .ForMember(dest => dest.HostUsername, opts => opts.MapFrom(src => src.Attendees
                     .FirstOrDefault(x => x.IsHost).AppUser.UserName));

            CreateMap<ActivityAttendee, AttendeeDto>()
                .ForMember(dest => dest.DisplayName, opts => opts.MapFrom(src => src.AppUser.DisplayName))
                .ForMember(dest => dest.Username, opts => opts.MapFrom(src => src.AppUser.UserName))
                .ForMember(dest => dest.Bio, opts => opts.MapFrom(src => src.AppUser.Bio))
                .ForMember(dest => dest.Image, opts => opts.MapFrom(src => src.AppUser.Photos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember(dest => dest.FollowersCount, opts => opts.MapFrom(src => src.AppUser.Followers.Count))
                .ForMember(dest => dest.FollowingCount, opts => opts.MapFrom(src => src.AppUser.Followings.Count))
                .ForMember(dest => dest.Following, opts => opts.MapFrom(src => src.AppUser.Followers.Any(x => x.Observer.UserName == currentUserName)));

            CreateMap<AppUser, Profiles.Profile>()
                .ForMember(dest => dest.Image, opts => opts.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember(dest => dest.FollowersCount, opts => opts.MapFrom(src => src.Followers.Count))
                .ForMember(dest => dest.FollowingCount, opts => opts.MapFrom(src => src.Followings.Count))
                .ForMember(dest => dest.Following, opts => opts.MapFrom(src => src.Followers.Any(x => x.Observer.UserName == currentUserName)));

            CreateMap<Comment, CommentDto>()
                .ForMember(dest => dest.DisplayName, opts => opts.MapFrom(src => src.Author.DisplayName))
                .ForMember(dest => dest.Username, opts => opts.MapFrom(src => src.Author.UserName))
                .ForMember(dest => dest.Image, opts => opts.MapFrom(src => src.Author.Photos.FirstOrDefault(x => x.IsMain).Url));



        }
    }
}

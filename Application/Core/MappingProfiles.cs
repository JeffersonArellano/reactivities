using Application.Activities;
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
            CreateMap<Activity, Activity>();
            CreateMap<Activity, ActivityDto>()
                .ForMember(dest => dest.HostUsername, opts => opts.MapFrom(src => src.Attendees
                     .FirstOrDefault(x => x.IsHost).AppUser.UserName));

            CreateMap<ActivityAttendee, Profiles.Profile>()
                .ForMember(dest => dest.DisplayName, opts => opts.MapFrom(src => src.AppUser.DisplayName))
                .ForMember(dest => dest.Username, opts => opts.MapFrom(src => src.AppUser.UserName))
                .ForMember(dest => dest.Bio, opts => opts.MapFrom(src => src.AppUser.Bio));
        }
    }
}

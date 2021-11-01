﻿using Application.Activities;
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
            CreateMap<Activity, Activity>();
            CreateMap<Activity, ActivityDto>()
                .ForMember(dest => dest.HostUsername, opts => opts.MapFrom(src => src.Attendees
                     .FirstOrDefault(x => x.IsHost).AppUser.UserName));

            CreateMap<ActivityAttendee, AttendeeDto>()
                .ForMember(dest => dest.DisplayName, opts => opts.MapFrom(src => src.AppUser.DisplayName))
                .ForMember(dest => dest.Username, opts => opts.MapFrom(src => src.AppUser.UserName))
                .ForMember(dest => dest.Bio, opts => opts.MapFrom(src => src.AppUser.Bio))
                .ForMember(dest => dest.Image, opts => opts.MapFrom(src => src.AppUser.Photos.FirstOrDefault(x => x.IsMain).Url));

            CreateMap<AppUser, Profiles.Profile>()
                .ForMember(dest => dest.Image, opts => opts.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url));

            CreateMap<Comment, CommentDto>()
                .ForMember(dest => dest.DisplayName, opts => opts.MapFrom(src => src.Author.DisplayName))
                .ForMember(dest => dest.Username, opts => opts.MapFrom(src => src.Author.UserName))
                .ForMember(dest => dest.Image, opts => opts.MapFrom(src => src.Author.Photos.FirstOrDefault(x => x.IsMain).Url));
        }
    }
}

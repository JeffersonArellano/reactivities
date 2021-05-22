using AutoMapper;
using Domain.Model;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfiles"/> class.
        /// </summary>
        public MappingProfiles()
        {
            CreateMap<ActivityModel, ActivityModel>();
        }

    }
}

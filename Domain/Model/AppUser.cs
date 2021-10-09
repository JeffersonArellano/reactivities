using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Domain.Model
{
    public class AppUser : IdentityUser
    {
        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the bio.
        /// </summary>
        public string Bio { get; set; }

        /// <summary>
        /// Gets or sets the activities.
        /// </summary>
        public virtual ICollection<ActivityAttendee> Activities { get; set; }

        /// <summary>
        /// Gets or sets the photos.
        /// </summary>
        public virtual ICollection<Photo> Photos { get; set; }

    }
}

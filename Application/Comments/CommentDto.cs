using System;

namespace Application.Comments
{
    public class CommentDto
    {
        /// <summary>
        /// The identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The comment created at datetime.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The comment body.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// The comment username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The comment displayname.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The user image.
        /// </summary>
        public string Image { get; set; }
    }
}

namespace Infrastructure.Photos
{
    /// <summary>
    /// Cloudinary Settings
    /// </summary>
    public class CloudinarySettings
    {
        /// <summary>
        /// Gets or sets the name of the cloud.
        /// </summary>
        public string CloudName { get; set; }

        /// <summary>
        /// Gets or sets the API key.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets the API secret.
        /// </summary>
        public string ApiSecret { get; set; }
    }
}

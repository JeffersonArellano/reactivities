using Application.Photos;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    /// <summary>
    /// IPhotoAccessor interface
    /// </summary>
    public interface IPhotoAccessor
    {
        /// <summary>
        /// Adds the photo.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns></returns>
        Task<PhotoUploadResult> AddPhoto(IFormFile file);

        /// <summary>
        /// Deletes the photo.
        /// </summary>
        /// <param name="publicId">The public identifier.</param>
        /// <returns></returns>
        Task<string> DeletePhoto(string publicId);
    }
}

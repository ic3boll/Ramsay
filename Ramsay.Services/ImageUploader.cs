using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ramsay.Services
{
     public class ImageUploader :IImageUploader
    {
        private const string cloudName = "ramsayimg";
        private const string apiKey = "982947359594978";
        private const string apiSecret = "YApm_oCt_NFym-D4m2Ye7hRrSAM";

        private readonly Cloudinary _cloudinary;

        public ImageUploader()
        {
            Account account = new Account(
                                       cloudName,
                                       apiKey,
                                       apiSecret);

            _cloudinary = new Cloudinary(account);

        }
        public string ImageUpload(Stream stream)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(Guid.NewGuid().ToString(), stream)
            };
            var uploadResult = _cloudinary.Upload(uploadParams);
            return uploadResult.SecureUri.AbsoluteUri;
        }

    }
}

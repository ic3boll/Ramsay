using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ramsay.Services.Ramsay.Services.Ramsay.Images.Contracts
{
    public interface IImageUploader
    {
        string ImageUpload(Stream  stream);
    }
}

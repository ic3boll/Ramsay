using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ramsay.Services
{
    public interface IImageUploader
    {
        string ImageUpload(Stream  stream);
    }
}

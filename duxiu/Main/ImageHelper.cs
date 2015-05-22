using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace Mouse.Main
{
    public class ImageHelper
    {
        public static byte[] errorImage;
        public static bool compare(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            byte[] image = new byte[stream.Length];
            stream.Read(image, 0, image.Length);
            return compare(image);
        }
        public static bool compare(byte[] image)
        {
            if (errorImage == null)
            {
                Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Mouse.error.png");
                errorImage = new byte[stream.Length];
                stream.Read(errorImage, 0, errorImage.Length);

            }

            if (image == null)
            {
                return false;
            }
            if (errorImage.Length != image.Length)
            {
                return false;
            }
            for (int i = 0; i < errorImage.Length; i++)
            {
                if (errorImage[i] != image[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}

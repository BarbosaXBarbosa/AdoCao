using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdoCao.Helpers
{
    public static class ImagemHelper
    {
        public static byte[] ConverteStreamByteArray(Stream stream)
        {
            byte[] byteArray = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int bit;
                while ((bit = stream.Read(byteArray, 0, byteArray.Length)) > 0)
                {
                    ms.Write(byteArray, 0, bit);
                }
                return ms.ToArray();
            }
        }
    }
}

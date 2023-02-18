using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdoCao.Helpers
{
    public static class CameraHelper
    {
        public static async Task<MediaFile> TirarFoto()
        {
            //Iniciarliza a camera
            await CrossMedia.Current.Initialize();
            //Verifica se a camera esta ativa 
            if (CrossMedia.Current.IsCameraAvailable || CrossMedia.Current.IsPickPhotoSupported)
            {
                //Configura a foto
                StoreCameraMediaOptions foto = new StoreCameraMediaOptions()
                {
                    SaveToAlbum = true,
                    CompressionQuality = 60,
                    PhotoSize = PhotoSize.Medium,
                    Name = $"{DateTime.UtcNow}.jpg",

                };
                //Obtem a foto
                MediaFile midia = await CrossMedia.Current.TakePhotoAsync(foto);
                return midia;
            }
            return null;
        }

        public static async Task<MediaFile> PegarFoto()
        {
            await CrossMedia.Current.Initialize();
            if (CrossMedia.Current.IsCameraAvailable || CrossMedia.Current.IsTakePhotoSupported)
            {
                //Obtem a foto
                MediaFile midia = await CrossMedia.Current.PickPhotoAsync();
                return midia;
            }
            return null;

        }
    }
}

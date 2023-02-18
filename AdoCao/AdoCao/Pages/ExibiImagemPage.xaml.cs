using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AdoCao.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ExibiImagemPage : ContentPage
	{
        public event EventHandler exibirMediaEventHandler;
		public ExibiImagemPage ()
		{
			InitializeComponent ();
		}

        private async void TirarFoto_Clicked(object sender, EventArgs e)
        {
            //Tira Foto
            var midia = await Helpers.CameraHelper.TirarFoto();
            //Verifica se tem uma foto
            if(midia != null)
            {
                ExibirFoto(midia);
                //Recarrega a pagina com a foto
                exibirMediaEventHandler?.Invoke(midia, EventArgs.Empty);
            }else
            {
                await DisplayAlert("Atenção", "Não foi possível exibir a foto", "Fechar");
                return;
            }
        }

        private async void PegarFoto_Clicked(object sender, EventArgs e)
        {
            //Tira Foto
            var midia = await Helpers.CameraHelper.PegarFoto();
            //Verifica se tem uma foto
            if (midia != null)
            {
                ExibirFoto(midia);
                //Recarrega a pagina com a foto
                exibirMediaEventHandler?.Invoke(midia, EventArgs.Empty);
                //Galeria (como se fosse para uma nova página)
                await Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("Atenção", "Não foi possível exibir a foto", "Fechar");
                return;
            }
        }


        private void ExibirFoto(MediaFile mediaFile)
        {
            //Obtem o caminho do arquivo
            var path = mediaFile.Path;
            //Obtem o arquivo e seta em memoria
            var foto = mediaFile.GetStream();
            //Exibe a foto em formato arquivo
            imgFoto.Source = ImageSource.FromStream(() => foto);
        }
    }
}
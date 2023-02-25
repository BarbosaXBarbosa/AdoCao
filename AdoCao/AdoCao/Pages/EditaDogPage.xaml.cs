using AdoCao.Models;
using AdoCao.Services;
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
	public partial class EditaDogPage : ContentPage
    {
        Cachorro _cachorro;
        
        CachorroFirebaseService _cachorroFirebaseService;

        //Evento para atualizar a pagina
        public event EventHandler exibirMediaEventHandler;
        public EditaDogPage (Cachorro cachorro )
        {
			InitializeComponent (); 
            _cachorro = new Cachorro();
            _cachorroFirebaseService = new CachorroFirebaseService();
            _cachorro = cachorro;
            this.BindingContext = cachorro;
        }


        private async void btnSalvarDog_Clicked(object sender, EventArgs e)

        {
            if (string.IsNullOrWhiteSpace(_cachorro.NomeDog) ||
                string.IsNullOrWhiteSpace(_cachorro.SexoDog) ||
                string.IsNullOrWhiteSpace(_cachorro.RacaDog) ||
                string.IsNullOrWhiteSpace(_cachorro.RuaDog) ||
                string.IsNullOrWhiteSpace(_cachorro.NumeroDog) ||
                string.IsNullOrWhiteSpace(_cachorro.CepDog) ||
                string.IsNullOrWhiteSpace(_cachorro.CidadeDog) ||
                string.IsNullOrWhiteSpace(_cachorro.DescricaoDog))
            {
                await DisplayAlert("Atenção", "Preencha todas as informações obrigatórias", "Fechar");
                return;
            }

            var cadastro = await App.BancoDadosDog.CachorroDataTable.SalvaCachorro(_cachorro);

            if (cadastro > 0)
            {
                 _cachorroFirebaseService.AlteraCachorroId(_cachorro.IdDog, _cachorro.IdDono, _cachorro.NomeDog, _cachorro.SexoDog, _cachorro.RacaDog, _cachorro.RuaDog, _cachorro.NumeroDog, _cachorro.CidadeDog, _cachorro.CepDog, _cachorro.ComplementoDog, _cachorro.DescricaoDog, _cachorro.ImagemDog);
                await Navigation.PopAsync();
            }

        }

        private async void btnVoltarDog_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void TirarFoto_Clicked(object sender, EventArgs e)
        {
            //Tira a foto
            var midia = await Helpers.CameraHelper.TirarFoto();
            //Verifica se tem uma foto
            if (midia != null)
            {
                ExibirFoto(midia);
                //Recarrega a pagina com a foto
                exibirMediaEventHandler?.Invoke(midia, EventArgs.Empty);
            }
            else
            {
                await DisplayAlert("Atenção", "Não foi possivel exibir a foto", "Fechar");
                return;
            }
        }

        private async void PegarFoto_Clicked(object sender, EventArgs e)
        {
            //Pega a foto
            var midia = await Helpers.CameraHelper.PegarFoto();
            //Verifica se tem uma foto
            if (midia != null)
            {
                ExibirFoto(midia);
                //Recarrega a pagina com a foto
                exibirMediaEventHandler?.Invoke(midia, EventArgs.Empty);
                //Galeria (como se fosse para um nova pagina)
                //await Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("Atenção", "Não foi possivel exibir a foto", "Fechar");
                return;
            }
        }

        private void ExibirFoto(MediaFile mediaFile)
        {
            //Exibe a foto em formato arquivo
            //Obtem o caminho do arquivo
            var path = mediaFile.Path;
            //imgFoto.Source = ImageSource.FromFile(path);

            //Exibe a foto no formato em memoria
            //Obtem o arquivo e seta em memoria
            var foto = mediaFile.GetStream();
            imgFoto.Source = ImageSource.FromStream(() => foto);
            _cachorro.ImagemDog = Helpers.ImagemHelper.ConverteStreamByteArray(foto);

        }
    }
}
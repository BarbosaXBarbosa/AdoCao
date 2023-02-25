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
    public partial class PerfilUsuarioPage : ContentPage
    {

        Usuario _usuario;
        //Evento para atualizar a pagina
        public event EventHandler exibirMediaEventHandler;
        public PerfilUsuarioPage(Usuario usuario)
        {
            InitializeComponent();
            _usuario = new Usuario();
            this.BindingContext = usuario;
        }

       

        private async void TirarFoto_Clicked()
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
        private async void PegarFoto_Clicked()
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
                await Navigation.PushAsync(new PreVisualizarPage());
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
            //btnImagem.Source = ImageSource.FromFile(path);

            //Exibe a foto no formato em memoria
            //Obtem o arquivo e seta em memoria
            var foto = mediaFile.GetStream();
            imgFotoUsuario.Source = ImageSource.FromStream(() => foto);
            _usuario.Imagem = Helpers.ImagemHelper.ConverteStreamByteArray(foto);

        }

        private async void btnImagem_Tapped(object sender, EventArgs e)
        {
            var retorno = await DisplayActionSheet("Inserir Foto", null, null, "Câmera", "Album");
            if (retorno == "Câmera")
            {
                TirarFoto_Clicked();
                
                await Navigation.PushAsync(new PreVisualizarPage());
            }
            if (retorno == "Album")
            {
                PegarFoto_Clicked();
                
            }

            return;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

        }
    }
}
using AdoCao.Models;
using AdoCao.Services;
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
    public partial class EditaUsuarioPage : ContentPage
    {
        //Novo usuario
        Usuario _usuario;
        UsuarioFirebaseService _usuarioFirebaseService;

        public EditaUsuarioPage()
        {
            InitializeComponent();
            //Inicializa 
            _usuario = new Usuario();
            _usuarioFirebaseService = new UsuarioFirebaseService();

            //Associacao do objeto com tela XAML
            this.BindingContext = _usuario;
        }

        private async void btnSalvar_Clicked(object sender, EventArgs e)
        {
            //Verifica se o formulario esta preenchido
            if (string.IsNullOrWhiteSpace(_usuario.Nome) ||
                string.IsNullOrWhiteSpace(_usuario.CPF) ||
                string.IsNullOrWhiteSpace(_usuario.Email) ||
                string.IsNullOrWhiteSpace(_usuario.Senha) ||
                string.IsNullOrWhiteSpace(_usuario.Confirmasenha) ||
                string.IsNullOrWhiteSpace(_usuario.Cidade) ||
                string.IsNullOrWhiteSpace(_usuario.Bairro) &&
                string.IsNullOrWhiteSpace(_usuario.Numero))
            {
                await DisplayAlert("Atenção", "Preencha todas as informações", "Fechar");
                return;
            }
            if (_usuario.Senha != _usuario.Confirmasenha)
            {
                await DisplayAlert("Atenção", "Senhas divergentes", "Fechar");
                return;
            }

            //Salva o registro no B.D
            var cadastro = await App.BancoDados.UsuarioDataTable.SalvaUsuario(_usuario);

            //Usuario cadastrado volta para a pagina de login
            if (cadastro > 0)
            {
                //Envia o dados para o serviço em nuvem do Firebase
                await _usuarioFirebaseService.Envia(_usuario);
                await Navigation.PopAsync();
            }

        }

        private async void btnVoltar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
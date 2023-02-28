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
    public partial class LoginUsuarioPage : ContentPage
    {
        public LoginUsuarioPage()
        {
            InitializeComponent();
        }

        private async void btnEntrar_Clicked(object sender, EventArgs e)
        {
            //atributos
            string email = txtEmail.Text;
            string senha = txtSenha.Text;

            //verificação do preenchimento
            if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(senha))
            {
                //Obtem o usuario 
                var usuario = await App.BancoDados.UsuarioDataTable.ObtemUsuario(email, senha);
                //Faz autenticacao
                if (usuario == null)
                {
                    await DisplayAlert("Atenção", "E-mail ou senha inválidos!", "Fechar");
                    return;
                }
                //Ativa o usuario logado na memoria do aplicativo
                App.Usuario = usuario;

                //Trocar a pagina principal do aplicativo
                //App.Current.MainPage = new HomePrincipalPage();
                App.Current.MainPage = new NavigationPage(new HomePrincipalPage(usuario));
            }
            else
            {
                //avisar o usuario para preecher com email e senha
                await DisplayAlert("Atenção", "E-mail ou senha inválidos!", "Fechar");
                //retorna para novo preenchimento
                return;
            }
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            //navegacao para a pagina de registro do usuario
            Navigation.PushAsync(new EditaUsuarioPage());

        }
    }
}
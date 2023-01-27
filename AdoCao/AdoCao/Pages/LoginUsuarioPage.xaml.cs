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
                //Trocar a página principal do aplicativo
                App.Current.MainPage = new HomePrincipalPage();
            }
            else
            {
                //avisar o usuario para preencher com email e senha
                await DisplayAlert("Atenção", "E-mail ou senha inválidos!", "Fechar");
                //retorna para novo preenchimento
                return;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            //navegação para a página de registro do usuario
            Navigation.PushAsync(new EditaUsuarioPage());
        }
    }
}
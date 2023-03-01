using AdoCao.Models;
using AdoCao.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Converters;
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
            Usuario usu = await _usuarioFirebaseService.ObtemUsuarioCPFEmail(_usuario.CPF, _usuario.Email);

            if (usu != null)
            {
                await DisplayAlert("Atenção", "Usuário já cadastrado!", "Fechar");
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


        private async void txtNome_Unfocused(object sender, FocusEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNome.Text))
            {
                if (txtNome.Text.Length < 5)
                {
                    await DisplayAlert("Atenção", "O nome deve possuir mais que 5 caracteres.", "Fechar");
                    txtNome.Focus();
                    return;
                }
                else
                {
                    ((Entry)sender).IsEnabled = true;
                }
            }
        }

        private async void txtEmail_Unfocused(object sender, FocusEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtEmail.Text)) 
            {
                if (txtEmail.Text.Length < 5)
                {
                    await DisplayAlert("Atenção", "O email deve possuir mais que 5 caracteres.", "Fechar");
                    txtEmail.Focus();
                    return;
                }
                else
                {
                    ((Entry)sender).IsEnabled = true;
                }
            }
            

        }

        private async void txtSenha_Unfocused(object sender, FocusEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSenha.Text))
            {

                if (txtSenha.Text.Length < 8)
                {
                    await DisplayAlert("Atenção", "A senha deve possuir mais que 8 caracteres.", "Fechar");
                    txtSenha.Focus();
                    return;
                }
                else
                {
                    ((Entry)sender).IsEnabled = true;
                }
            }
        }


        private async void txtCidade_Unfocused(object sender, FocusEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCidade.Text))
            {
                if (txtCidade.Text.Length < 5)
                {
                    await DisplayAlert("Atenção", "O Cidade deve possuir mais que 5 caracteres.", "Fechar");
                    txtCidade.Focus();
                    return;
                }
                else
                {
                    ((Entry)sender).IsEnabled = true;
                }
            }
        }

        private async void txtBairro_Unfocused(object sender, FocusEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBairro.Text))
            {
                if (txtBairro.Text.Length < 5)
                {
                    await DisplayAlert("Atenção", "O Bairro deve possuir mais que 5 caracteres.", "Fechar");
                    txtBairro.Focus();
                    return;
                }
                else
                {
                    ((Entry)sender).IsEnabled = true;
                }
            }
        }

        private async void txtRua_Unfocused(object sender, FocusEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtRua.Text))
            {
                if (txtRua.Text.Length < 5)
                {
                    await DisplayAlert("Atenção", "O rua deve possuir mais que 5 caracteres.", "Fechar");
                    txtEmail.Focus();
                    return;
                }
                else
                {
                    ((Entry)sender).IsEnabled = true;
                }
            }
        }

        private async void txtNumber_Unfocused(object sender, FocusEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNumber.Text))
            {
                if (txtNumber.Text.Length < 1)
                {
                    await DisplayAlert("Atenção", "O número deve possuir mais que 1 caracteres.", "Fechar");
                    txtNumber.Focus();
                    return;
                }
                else
                {
                    ((Entry)sender).IsEnabled = true;
                }
            }
        }

    }
}
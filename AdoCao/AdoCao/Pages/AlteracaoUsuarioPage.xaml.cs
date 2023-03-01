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
    public partial class AlteracaoUsuarioPage : ContentPage
    {
        UsuarioFirebaseService _usuarioFirebaseService;
        Usuario _usuario;

        public AlteracaoUsuarioPage(Usuario usuario)
        {
            InitializeComponent();
            _usuario = new Usuario();
            _usuarioFirebaseService = new UsuarioFirebaseService();
            _usuario = App.Usuario;
            this.BindingContext = _usuario;
        }

        private async void btnVoltar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void btnSalvar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_usuario.Nome) ||
                string.IsNullOrWhiteSpace(_usuario.Numero) ||
                string.IsNullOrWhiteSpace(_usuario.Senha) ||
                string.IsNullOrWhiteSpace(_usuario.Confirmasenha) ||
                string.IsNullOrWhiteSpace(_usuario.Bairro) ||
                string.IsNullOrWhiteSpace(_usuario.Complemento) ||
                string.IsNullOrWhiteSpace(_usuario.Rua))
            {
                await DisplayAlert("Atenção", "Preencha todas as informações obrigatórias", "Fechar");
                return;
            }
            if (_usuario.Senha != _usuario.Confirmasenha)
            {
                await DisplayAlert("Atenção", "Senhas divergentes", "Fechar");
                return;
            }

            var cadastro = await App.BancoDados.UsuarioDataTable.SalvaUsuario(_usuario);
            if (cadastro > 0)
            {
                _usuarioFirebaseService.AlteraUsuarioId
                    (_usuario.Id,
                    _usuario.Nome,
                    _usuario.Numero,
                    _usuario.CPF,
                    _usuario.Cidade,
                    _usuario.Complemento,
                    _usuario.Senha,
                    _usuario.Confirmasenha,
                    _usuario.Bairro,
                    _usuario.Rua,
                    _usuario.Imagem,
                    _usuario.Email
                    );
                await Navigation.PopAsync();
            }

        }

        private async void txtNome_Unfocused(object sender, FocusEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNome.Text))
            {
                if (txtNome.Text.Length < 1)
                {
                    await DisplayAlert("Atenção", "O número deve possuir mais que 1 caracteres.", "Fechar");
                    txtNome.Focus();
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
                if (txtSenha.Text.Length < 1)
                {
                    await DisplayAlert("Atenção", "O número deve possuir mais que 1 caracteres.", "Fechar");
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
                if (txtCidade.Text.Length < 1)
                {
                    await DisplayAlert("Atenção", "O número deve possuir mais que 1 caracteres.", "Fechar");
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
                if (txtBairro.Text.Length < 1)
                {
                    await DisplayAlert("Atenção", "O Bairro deve possuir mais que 1 caracteres.", "Fechar");
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
                if (txtRua.Text.Length < 1)
                {
                    await DisplayAlert("Atenção", "A rua deve possuir mais que 1 caracteres.", "Fechar");
                    txtRua.Focus();
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
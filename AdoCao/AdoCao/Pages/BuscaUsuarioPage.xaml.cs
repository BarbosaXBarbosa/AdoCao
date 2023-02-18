using AdoCao.Data;
using AdoCao.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AdoCao.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuscaUsuarioPage : ContentPage
    {
        
        public BuscaUsuarioPage()
        {
            InitializeComponent();
            AtualizaUsuarios();
            PesquisaUsuarios();
        }

        private async void AtualizaUsuarios()
        {
            UsuarioFirebaseService usuarioFirebaseService;
            usuarioFirebaseService = new UsuarioFirebaseService();
            //Obtem a lista de usuarios em nuvem
            var usuarios = await usuarioFirebaseService.Lista();

            //Atualiza o B.D local
            foreach (var usuario in usuarios)
            {
                //Salva cada usuario
                await App.BancoDados.UsuarioDataTable.SalvaUsuario(usuario);
            }
        }

        private async void PesquisaUsuarios(string pesquisa=null) 
        {
            //Obtem a lista de usuarios no B.D
            var listaUsuarios = await App.BancoDados.UsuarioDataTable.ListaUsuarios();

            //Faz a pesquisa
            if (!string.IsNullOrWhiteSpace(pesquisa))
            {
                listaUsuarios = listaUsuarios
                    .Where(e => e.Nome.Contains(pesquisa))
                    .ToList();
            }

            //Preenche o Listview com a lista de usuarios
            lsvUsuarios.ItemsSource = listaUsuarios;
        }

        private void btnPesquisar_SearchButtonPressed(object sender, EventArgs e)
        {
            var pesquisa = btnPesquisar.Text;
            PesquisaUsuarios(pesquisa);
        }
    }
}
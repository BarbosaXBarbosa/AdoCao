using AdoCao.Models;
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
    public partial class HomePrincipalPage : TabbedPage
    {
        public HomePrincipalPage(Usuario usuario)
        {
            InitializeComponent();

            var pagina1 = new ListaFeedPage()
            {
                Title = "Feed",
                IconImageSource = ""
            };

            var pagina2 = new CachorroListaPage() 
            {
                Title = "Meus Animais",
                IconImageSource = ""
            };

            var pagina3 = new PerfilUsuarioPage(usuario)
            {
                Title = "Meu Perfil",
                IconImageSource = ""
            };

            //Adiciona as paginas na Tabbed
            this.Children.Add(pagina1);
            this.Children.Add(pagina2);
            this.Children.Add(pagina3);
        }
    }
}
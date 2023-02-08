﻿using System;
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
        public HomePrincipalPage()
        {
            InitializeComponent();

            var pagina1 = new ListaFeedPage()
            {
                Title = "Feed",
                IconImageSource = ""
            };

            var pagina2 = new ExibeUsuarioPage() 
            {
                Title = "Conta",
                IconImageSource = ""
            };

            var pagina3 = new BuscaUsuarioPage()
            {
                Title = "Busca",
                IconImageSource = ""
            };

            var pagina4 = new ExibiImagemPage()
            {
                Title = "Foto",
                IconImageSource = ""
            };

            //Adiciona as paginas na Tabbed
            this.Children.Add(pagina1);
            this.Children.Add(pagina2);
            this.Children.Add(pagina3);
            this.Children.Add(pagina4);
        }
    }
}
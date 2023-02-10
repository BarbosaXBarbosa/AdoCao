using AdoCao.Data;
using AdoCao.Models;
using AdoCao.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AdoCao
{
    public partial class App : Application
    {
        
        static SQLiteData _bancoDados;
        public static SQLiteData BancoDados
        {
            get
            {
                if (_bancoDados == null)
                {
                    //Inicia o B.D em cada plataforma
                    //DependencyService.Get<ISQLiteBD>().SQLiteLocalPath("Dados.db3");
                    _bancoDados = 
                        new SQLiteData(DependencyService
                        .Get<ISQLiteBD>()
                        .SQLiteLocalPath("Dados.db3"));
                }
                return _bancoDados;
            }
        }

        public static Usuario Usuario { get; set; }

        public App()
        {
            InitializeComponent();

           MainPage = new NavigationPage(new LoginUsuarioPage());

            //MainPage = new NavigationPage(new ListaFeedPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

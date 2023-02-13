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
                    _bancoDados = new SQLiteData(DependencyService.Get<ISQLiteBD>().SQLiteLocalPath("Dados.db3"));
                }
                return _bancoDados;
            }
        }

        static SQLiteDataDog _bancoDadosDog;
        public static SQLiteDataDog BancoDadosDog
        {
            get
            {
                if (_bancoDadosDog == null)
                {
                    //Inicia o B.D em cada plataforma
                    //DependencyService.Get<ISQLiteBD>().SQLiteLocalPath("Dados.db3");
                    _bancoDadosDog = new SQLiteDataDog(DependencyService.Get<ISQLiteBD>().SQLiteLocalPath("Dados.db3"));
                }
                return _bancoDadosDog;
            }
        }

        public static Usuario Usuario { get; set; }
        public static Cachorro Cachorro { get; set; }

        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new LoginUsuarioPage());

            MainPage = new NavigationPage(new LoginUsuarioPage());
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

using AdoCao.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AdoCao
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

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

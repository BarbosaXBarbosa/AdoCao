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
    public partial class ListaFeedPage : ContentPage
    {
        public ListaFeedPage()
        {
            InitializeComponent();
            GetCachorros();
        }



        public async void GetCachorros()
        {
            CachorroFirebaseService cachorroFirebaseService;
            cachorroFirebaseService = new CachorroFirebaseService();
            //Obtem a lista de usuarios em nuvem
            var cachorros = await cachorroFirebaseService.Lista();
            PetsListView.ItemsSource = cachorros;
            
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

          // await Navigation.PushAsync(new DescricaoCaoPage());
        }

        private void PetsListView_Refreshing(object sender, EventArgs e)
        {
            PetsListView.IsRefreshing= true;
            GetCachorros();
            PetsListView.IsRefreshing = false;
        }
    }
}
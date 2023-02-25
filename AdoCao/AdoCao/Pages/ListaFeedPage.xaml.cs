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

        private async void PetsListViewDono_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Cachorro cachorro = e.SelectedItem as Cachorro;
            await Navigation.PushAsync(new DescricaoFeedCaoPage(cachorro));
        }

        private void PetsListView_Refreshing(object sender, EventArgs e)
        {
            PetsListView.IsRefreshing= true;
            GetCachorros();
            PetsListView.IsRefreshing = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            PetsListView.IsRefreshing = true;
            GetCachorros();
            PetsListView.IsRefreshing = false;
        }
    }
}
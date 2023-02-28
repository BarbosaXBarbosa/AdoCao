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
	public partial class CachorroListaPage : ContentPage
	{
		public CachorroListaPage ()
		{
			InitializeComponent ();
            GetCachorrosDono();
  
        }

        
        public async void GetCachorrosDono()
        {
            CachorroFirebaseService cachorroFirebaseService;
            cachorroFirebaseService = new CachorroFirebaseService();
            //Obtem a lista de usuarios em nuvem
            var cachorros = await cachorroFirebaseService.ObtemCachorroPorUsuario(App.Usuario.Id);
            PetsListViewDono.ItemsSource = (System.Collections.IEnumerable)cachorros;

        }

      /*  private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Cachorro cachorro = sender as Cachorro;
            await Navigation.PushAsync(new DescricaoCaoPage(cachorro));
            

            //Guid Id = (()sender)
        }*/

        private async void btnAddMeuCachorro_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistraDogPage());
        }

        private async void btnEditMeuCachorro_Clicked(object sender, EventArgs e)
        {
            //Guid id = 0;
            //await Navigation.PushAsync(new EditaDogPage(id));
        }

        /*private void PetsListViewDono_Refreshing(object sender, EventArgs e)
        {
            PetsListViewDono.IsRefreshing = true;
            GetCachorrosDono();
            PetsListViewDono.IsRefreshing = false;
        }*/

        private async void PetsListViewDono_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Cachorro cachorro = e.SelectedItem as Cachorro;
            await Navigation.PushAsync(new DescricaoCaoPage(cachorro));
        }

        private void btnExcluirMeuCachorro_Clicked(object sender, SelectedItemChangedEventArgs e)
        {
            
        }

        private void btnExcluirMeuCachorro_Clicked(object sender, EventArgs e)
        {

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            PetsListViewDono.IsRefreshing = true;
            GetCachorrosDono();
            PetsListViewDono.IsRefreshing = false;
        }
    }
}
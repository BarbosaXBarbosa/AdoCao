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
            PetsListView.ItemsSource = (System.Collections.IEnumerable)cachorros;

        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            
        }

        private async void btnAddMeuCachorro_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistraDogPage());
        }

        private async void btnEditMeuCachorro_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistraDogPage());
        }
        
    }
}
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
    public partial class RegistraDogPage : ContentPage
    {
        Cachorro _cachorro;
        CachorroFirebaseService _cachorroFirebaseService;
        public RegistraDogPage()
        {

            InitializeComponent();

            _cachorro = new Cachorro();
            _cachorroFirebaseService = new CachorroFirebaseService();

            this.BindingContext = _cachorro;
        }


        private async void btnSalvarDog_Clicked(object sender, EventArgs e)

        {
            if (string.IsNullOrWhiteSpace(_cachorro.NomeDog) || 
                string.IsNullOrWhiteSpace(_cachorro.SexoDog) ||
                string.IsNullOrWhiteSpace(_cachorro.RacaDog) ||
                string.IsNullOrWhiteSpace(_cachorro.RuaDog) ||
                string.IsNullOrWhiteSpace(_cachorro.NumeroDog) ||
                string.IsNullOrWhiteSpace(_cachorro.CepDog) ||
                string.IsNullOrWhiteSpace(_cachorro.CidadeDog))
            {
                await DisplayAlert("Atenção", "Preencha todas as informações obrigatórias", "Fechar");
                return;
            }

             var cadastro = await App.BancoDadosDog.CachorroDataTable.SalvaCachorro(_cachorro);

            if (cadastro > 0)
            {
                await _cachorroFirebaseService.Envia(_cachorro);
                await Navigation.PopAsync();
            }

        }

        private async void btnVoltarDog_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
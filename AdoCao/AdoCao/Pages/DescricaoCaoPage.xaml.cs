using AdoCao.Models;
using AdoCao.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AdoCao.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DescricaoCaoPage : ContentPage
    {
        Cachorro _cachorro = new Cachorro();
        CachorroFirebaseService _cachorroFirebaseService;
        public DescricaoCaoPage(Cachorro cachorro)
        {
            InitializeComponent();
            _cachorroFirebaseService = new CachorroFirebaseService();
            this.BindingContext = cachorro;
            _cachorro = cachorro;
            
        }

        private async void btnDeletar_Clicked(object sender, EventArgs e)
        {
            var retorno = await DisplayActionSheet("Deseja Realmente Excluir?", null, null, "Sim", "Não");
            if(retorno == "Sim")
            {
                _cachorroFirebaseService.DeletaCachorroId(_cachorro.IdDog);
                Navigation.PopAsync();
            }
            return;
        }

        private void btnEditar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditaDogPage(_cachorro));
        }
    }
}
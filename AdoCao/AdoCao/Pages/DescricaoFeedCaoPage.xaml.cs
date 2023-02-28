using AdoCao.Models;
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
    public partial class DescricaoFeedCaoPage : ContentPage
    {
        public DescricaoFeedCaoPage(Cachorro cachorro)
        {
            InitializeComponent();
            this.BindingContext = cachorro;
        }
    }
}
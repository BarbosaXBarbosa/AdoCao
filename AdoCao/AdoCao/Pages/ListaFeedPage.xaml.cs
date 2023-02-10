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
            PetsListView.ItemsSource = GetProfiles();
        }
        public class Pets
        {
            public string Name { get; set; }
            public string Breed { get; set; }
            public string Gender { get; set; }
            public string PetPicture { get; set; }
            public bool Addopted { get; set; }  
        }
        public List<Pets> GetProfiles()
        {
            return new List<Pets>
            {
                new Pets { Name = "Xaninha", Breed = "Persa", Gender = "Femêa", PetPicture = "Imagens/pet1.jpg", Addopted = false },
                new Pets { Name = "Rafael", Breed = "Labrador", Gender = "Macho", PetPicture = "Imagens/pet2.jpg", Addopted = false  },
                new Pets { Name = "Mel", Breed = "Poodle", Gender = "Femêa", PetPicture = "Imagens/pet3.jpg" , Addopted = false }
            };
        }
    }
}
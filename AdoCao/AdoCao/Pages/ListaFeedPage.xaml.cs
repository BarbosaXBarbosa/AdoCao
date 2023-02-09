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
        }
        public List<Pets> GetProfiles()
        {
            return new List<Pets>
            {
                new Pets { Name = "Xaninha", Breed = "Persa", Gender = "Femêa", PetPicture = "pet1.jpg" },
                new Pets { Name = "Rafael", Breed = "Labrador", Gender = "Macho", PetPicture = "pet2.jpg" },
                new Pets { Name = "Mel", Breed = "Poodle", Gender = "Femêa", PetPicture = "pet3.jpg" }
            };
        }
    }
}
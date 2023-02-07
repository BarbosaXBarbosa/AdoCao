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
            ProfileListView.ItemsSource = GetProfiles();
        }
        public class Profile
        {
            public string Name { get; set; }
            public string Breed { get; set; }
            public string Gender { get; set; }
            public string ProfilePicture { get; set; }
        }
        public List<Profile> GetProfiles()
        {
            return new List<Profile>
            {
                new Profile { Name = "Fluffy", Breed = "Persian", Gender = "Female", ProfilePicture = "fluffy.jpg" },
                new Profile { Name = "Buddy", Breed = "Labrador", Gender = "Male", ProfilePicture = "buddy.jpg" },
                new Profile { Name = "Daisy", Breed = "Poodle", Gender = "Female", ProfilePicture = "daisy.jpg" }
            };
        }
    }
}
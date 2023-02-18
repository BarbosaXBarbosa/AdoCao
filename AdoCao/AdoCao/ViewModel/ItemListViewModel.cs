using AdoCao.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace AdoCao.ViewModel
{
    public class ItemListViewModel : BaseViewModel
    {
        public ObservableCollection<Cachorro> ItemList { get; set; }

        public AsyncCommand RefreshCommand { get; }

        public ItemListViewModel()
        {
            RefreshCommand = new AsyncCommand(Refresh);

         /*   ItemList = new ObservableCollection<Cachorro>();
            ItemList.Add(new Cachorro() { IdDog = 1, NomeDog = "Totó", RacaDog = "Vira-lata", ImagemDog = "https://s2.glbimg.com/6N6UKj1cx5Nv6hZf3BmiHwx7Y1A=/0x0:1080x645/924x0/smart/filters:strip_icc()/i.s3.glbimg.com/v1/AUTH_cf9d035bf26b4646b105bd958f32089d/internal_photos/bs/2022/Z/F/C923T1TlORxpzmAb8lAg/ferraro.jpg" });
            ItemList.Add(new Cachorro() { IdDog = 2, NomeDog = "aaaaaaaaaaa", RacaDog = "RACA AAAA", ImagemDog = "img2.png" });
            ItemList.Add(new Cachorro() { IdDog = 3, NomeDog = "bbbbbbbbbb", RacaDog = "RACA BBBBBBB", ImagemDog = "img3.jpg" });
         */
        }

        async Task Refresh()
        {
            IsBusy= true;
            await Task.Delay(2000);
            IsBusy= false;
        }
    }
}

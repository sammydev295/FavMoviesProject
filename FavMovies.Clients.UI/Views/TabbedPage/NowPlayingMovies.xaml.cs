using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FavMovies.Clients.Portable.ViewModel;
using FavMovies.DataObjects;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FavMovies.Clients.UI.Views.TabbedPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NowPlayingMovies : ContentPage
    {
        private NowPlayingMoviesViewModel ViewModel = App.Locator.NowPlayingMovies;
        public NowPlayingMovies()
        {
            InitializeComponent();
            BindingContext = ViewModel;
            ViewModel.Initialize();
        }

        private void OnNowPlayingSelected(object sender, ItemTappedEventArgs e)
        {
            ViewModel.NowPlayingCommand.Execute(e.Item as MovieBO);
        }

        private void NowPlayingList_OnItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            if (e.Item == null)
                return;

            var currentmoviesList = e.Item as ObservableCollection<object>;
            if (currentmoviesList == null)
                return;

            var lastmovie = ViewModel.NowPlayingList[ViewModel.NowPlayingList.Count - 2];
            if (currentmoviesList.Contains(lastmovie))
            {
                ViewModel.UpdateNowPlayingList();
            }

        }
    }
}
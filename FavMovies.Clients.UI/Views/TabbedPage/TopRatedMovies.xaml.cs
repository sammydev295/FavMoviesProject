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
    public partial class TopRatedMovies : ContentPage
    {
        private TopRatedMoviesViewModel ViewModel = App.Locator.TopRatedMovies;
        public TopRatedMovies()
        {
            InitializeComponent();
            BindingContext = ViewModel;
            ViewModel.Initialize();
        }

        private void OnTopRatedSelected(object sender, ItemTappedEventArgs e)
        {
            ViewModel.TopRatedCommand.Execute(e.Item as MovieBO);
        }

        private void TopRatedList_OnItemAppearing(object sender, ItemVisibilityEventArgs e)
        {

            if (e.Item == null)
                return;

            var currentmoviesList = e.Item as ObservableCollection<object>;
            if (currentmoviesList == null)
                return;

            var lastmovie = ViewModel.TopRatedList[ViewModel.TopRatedList.Count - 2];
            if (currentmoviesList.Contains(lastmovie))
            {
                ViewModel.UpdateTopRatedList();
            }

        }
    }
}
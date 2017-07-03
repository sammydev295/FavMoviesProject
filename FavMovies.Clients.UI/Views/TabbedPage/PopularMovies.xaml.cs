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
    public partial class PopularMovies : ContentPage
    {
        private PopularMoviesViewModel ViewModel = App.Locator.PopularMovies;
        public PopularMovies()
        {
            InitializeComponent();
           BindingContext= ViewModel;
            ViewModel.Initialize();
        }

        private void OnPopularSelected(object sender, ItemTappedEventArgs e)
        {
            ViewModel.PopularCommand.Execute(e.Item as MovieBO);
        }
        private void PopularList_OnItemAppearing(object sender, ItemVisibilityEventArgs e)
        {

            if (e.Item == null)
                return;

            var currentmoviesList = e.Item as ObservableCollection<object>;
            if (currentmoviesList == null)
                return;

            var lastmovie = ViewModel.PopularList[ViewModel.PopularList.Count - 2];
            if (currentmoviesList.Contains(lastmovie))
            {
                ViewModel.UpdatePopularList();
            }

        }
    }
}
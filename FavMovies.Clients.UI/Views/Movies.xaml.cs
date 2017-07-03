using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FavMovies.Clients.Portable.ViewModel;
using FavMovies.DataObjects;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FavMovies.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Movies : ContentPage
    {
        MoviesViewModel ViewModel = App.Locator.Movies;
        public Movies()
        {
            InitializeComponent();
            BindingContext = ViewModel;
        }

        private void TopRatedList_OnScrolled(object sender, ScrolledEventArgs e)
        {
            var scrollView = sender as ScrollView;
            if (scrollView == null)
                return; ;
            double scrollingSpace = scrollView.ContentSize.Width - scrollView.Width;

            if (scrollingSpace <= e.ScrollX)
            {
                ViewModel.UpdateTopRatedList();
            };
        }

        private void PopularList_OnScrolled(object sender, ScrolledEventArgs e)
        {
            var scrollView = sender as ScrollView;
            if (scrollView == null)
                return; ;
            double scrollingSpace = scrollView.ContentSize.Width - scrollView.Width;

            if (scrollingSpace <= e.ScrollX)
            {
                ViewModel.UpdatePopularList();
            };
        }

        private void NowPlaying_OnScrolled(object sender, ScrolledEventArgs e)
        {
            var scrollView = sender as ScrollView;
            if (scrollView == null)
                return; ;
            double scrollingSpace = scrollView.ContentSize.Width - scrollView.Width;

            if (scrollingSpace <= e.ScrollX)
            {
                ViewModel.UpdateNowPlayingList();
            };
        }
    }
}
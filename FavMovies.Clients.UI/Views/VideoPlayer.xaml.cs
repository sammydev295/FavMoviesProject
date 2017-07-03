using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FavMovies.Clients.Portable.ViewModel;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FavMovies.Clients.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideoPlayer : PopupPage
    {
        private VideoPlayerViewModel ViewModel = App.Locator.VideoPlayer;
        public VideoPlayer()
        {
            InitializeComponent();
            BindingContext = ViewModel;
        }
        public VideoPlayer(object value)
        {
            InitializeComponent();
            BindingContext = ViewModel;
            ViewModel.Source = value.ToString();

        }
    }
}
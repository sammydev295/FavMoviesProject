using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FavMovies.Clients.Portable.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FavMovies.Clients.UI.Views.TabbedPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviesTabbed : Xamarin.Forms.TabbedPage
    {
        private MoviesTabbedViewModel ViewModel = App.Locator.MoviesTabbed;
        public MoviesTabbed()
        {
            InitializeComponent();
            BindingContext = ViewModel;
        }
    }
}
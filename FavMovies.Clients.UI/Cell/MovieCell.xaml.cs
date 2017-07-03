using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FavMovies.Clients.UI.Cell
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieCell : DataTemplate
    {
        public MovieCell()
        {
            InitializeComponent();
        }
    }
}
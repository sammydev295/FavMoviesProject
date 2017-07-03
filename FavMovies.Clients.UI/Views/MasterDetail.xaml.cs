using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FavMovies.DataObjects;
using FavMovies.Clients.Portable.Interfaces;
using FavMovies.Clients.UI.Views.TabbedPage;

namespace FavMovies.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetail : MasterDetailPage
    {
        #region Main Menu

        public ObservableCollection<MenuItemBO> Pages = new ObservableCollection<MenuItemBO>()
        {
           new MenuItemBO { Id = 0, Title ="Home", Icon="calendar.png", TargetType = typeof(Movies) },
           new MenuItemBO { Id = 1, Title ="Movies (Tabbed)", Icon="ic_action_shield.png", TargetType = typeof(MoviesTabbed) },
           new MenuItemBO { Id = 2, Title ="About", Icon="ic_action_warning.png", TargetType = typeof(int) },
        };

        #endregion

        #region CTOR

        public MasterDetail()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            PagesListView.ItemsSource = Pages;
        }

        #endregion

        #region ListViewMenuItems_ItemSelected

        private void ListViewMenuItems_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MenuItemBO;
            if (item == null)
                return;

            if(item.Title == "About")
            {
                var toaster = DependencyService.Get<IToast>();
                toaster.SendToast($"Application buiuld by Sammy Dev for CieDigital");
                return;
            }

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;
            Detail = new NavigationPage(page);
            IsPresented = false;

            PagesListView.SelectedItem = null;
        }

        #endregion
    }
}
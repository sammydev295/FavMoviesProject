using System;
using System.Reflection;
using System.Resources;
using System.Threading.Tasks;
using System.Diagnostics;

using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;

using FormsToolkit;
using Xamarin.Forms;

using FavMovies.Clients.Portable.Interfaces;
using FavMovies.Clients.Portable.Locator;
using FavMovies.Clients.UI.Views;
using FavMovies.Clients.UI.Views.TabbedPage;
using FavMovies.Languages;
using FavMovies.Utilities;
using FavMovies.Utilities.Interface;
using FavMovies.Views;

namespace FavMovies
{
    public partial class App : Application
    {
        #region Locator (ViewModel)

        public static ViewModelLocator locator;
        public static ViewModelLocator Locator { get { return locator; } }

        #endregion

        #region Fields

        public static App Self { get; private set; }
        public static IResourceContainer Resourcer { get; private set; }

        private NavigationPage StartingPage;

        NavigationService nav = new NavigationService();

        #endregion
        
        #region ILogger

        static ILogger logger;
        public static ILogger Logger => logger ?? (logger = DependencyService.Get<ILogger>());

        #endregion

        #region CTOR

        public App()
        {
            locator = new ViewModelLocator();

            App.Self = this;
            InitializeComponent();

            // Regster the logger
            if(Logger == null)
                DependencyService.Register<ILogger>();

            // Language locale plumbing
            var ds = DependencyService.Get<ILocalize>();
            if (ds != null)
            {
                // Inject resource manager
                if (!SimpleIoc.Default.IsRegistered<ResourceManager>())
                    SimpleIoc.Default.Register<ResourceManager>(() => new ResourceManager(ResourceContainer.ResourceId, typeof(App).GetTypeInfo().Assembly));

                // Inject resource container
                SimpleIoc.Default.Register<IResourceContainer, ResourceContainer>();
                //   Resourcer = SimpleIoc.Default.GetInstance<IResourceContainer>();
            }

            // Parameter true means mock data
            FavMovies.Clients.Portable.ViewModel.BaseViewModel.Init(false);

            // Navigation
            nav.Configure(ViewModelLocator.MoviesKey, typeof(Movies));
            nav.Configure(ViewModelLocator.MoviesDetailKey, typeof(MoviesDetail));
            nav.Configure(ViewModelLocator.MasterDetaiKey, typeof(MasterDetail));
            nav.Configure(ViewModelLocator.VideoPlayerKey, typeof(VideoPlayer));
            nav.Configure(ViewModelLocator.MoviesTabbedKey, typeof(MoviesTabbed));
            nav.Configure(ViewModelLocator.TopRatedMoviesKey, typeof(TopRatedMovies));
            nav.Configure(ViewModelLocator.PopularMoviesKey, typeof(PopularMovies));
            nav.Configure(ViewModelLocator.NowPlayingMoviesKey, typeof(NowPlayingMovies));


            if (!SimpleIoc.Default.IsRegistered<INavigationService>())
                SimpleIoc.Default.Register<INavigationService>(() => nav);

            StartingPage = new NavigationPage(new MasterDetail());

            nav.Initialize(StartingPage);

            MainPage = StartingPage;

         //   FFImage cache settings
            Task.Run(() =>
            {
                FFImageLoading.ImageService.Instance.Initialize();
#if DEBUG
                FFImageLoading.ImageService.Instance.Config.Logger = new CustomMiniLogger();
                FFImageLoading.ImageService.Instance.Config.VerboseLoadingCancelledLogging = true;
                FFImageLoading.ImageService.Instance.Config.VerboseLogging = true;
                FFImageLoading.ImageService.Instance.Config.VerboseMemoryCacheLogging = true;
                FFImageLoading.ImageService.Instance.Config.VerbosePerformanceLogging = true;
#endif       
            });
        }

        #endregion

        #region Event Overrides

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            MessagingService.Current.Unsubscribe<MessagingServiceQuestion>(MessageKeys.Question);
            MessagingService.Current.Unsubscribe<MessagingServiceAlert>(MessageKeys.Message);
            MessagingService.Current.Unsubscribe<MessagingServiceChoice>(MessageKeys.Choice);
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            MessagingService.Current.Subscribe<MessagingServiceAlert>(MessageKeys.Message, async (m, info) =>
            {
                var task = Application.Current?.MainPage?.DisplayAlert(info.Title, info.Message, info.Cancel);
                if (task == null)
                    return;

                await task;
                info?.OnCompleted?.Invoke();
            });

            MessagingService.Current.Subscribe<MessagingServiceQuestion>(MessageKeys.Question, async (m, q) =>
            {
                var task = Application.Current?.MainPage?.DisplayAlert(q.Title, q.Question, q.Positive, q.Negative);
                if (task == null)
                    return;

                var result = await task;
                q?.OnCompleted?.Invoke(result);
            });

            MessagingService.Current.Subscribe<MessagingServiceChoice>(MessageKeys.Choice, async (m, q) =>
            {
                var task = Application.Current?.MainPage?.DisplayActionSheet(q.Title, q.Cancel, q.Destruction, q.Items);
                if (task == null)
                    return;

                var result = await task;
                q?.OnCompleted?.Invoke(result);
            });
        }

        #endregion

        #region Class CustomMiniLogger 

        public class CustomMiniLogger : FFImageLoading.Helpers.IMiniLogger
        {
            public void Debug(string message)
            {
                System.Diagnostics.Debug.WriteLine(message);
            }

            public void Error(string errorMessage)
            {
                System.Diagnostics.Debug.WriteLine(errorMessage);
            }

            public void Error(string errorMessage, Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(errorMessage + ex.ToString());
            }
        }

        #endregion
    }
}

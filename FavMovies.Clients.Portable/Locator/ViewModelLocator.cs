using FavMovies.Clients.Portable.ViewModel;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavMovies.Clients.Portable.Locator
{
    public class ViewModelLocator
    {
        #region Constructor
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MoviesViewModel>();
            SimpleIoc.Default.Register<MoviesDetailViewModel>();
            SimpleIoc.Default.Register<MasterDetailViewModel>();
            SimpleIoc.Default.Register<VideoPlayerViewModel>();
            SimpleIoc.Default.Register<MoviesTabbedViewModel>();
            SimpleIoc.Default.Register<TopRatedMoviesViewModel>();
            SimpleIoc.Default.Register<PopularMoviesViewModel>();
            SimpleIoc.Default.Register<NowPlayingMoviesViewModel>();

        }
        #endregion

        #region Const Strings
        public const string MoviesKey = "Movies";
        public const string MoviesDetailKey = "MoviesDetail";
        public const string MasterDetaiKey = "MasterDetai";
        public const string MoviesTabbedKey = "MoviesTabbed";
        public const string VideoPlayerKey = "VideoPlayer";
        public const string TopRatedMoviesKey = "TopRatedMovies";
        public const string PopularMoviesKey = "PopularMovies";
        public const string NowPlayingMoviesKey = "NowPlayingMovies";


        #endregion

        #region Properties
        public MoviesViewModel Movies
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MoviesViewModel>();
            }
        }
        public MoviesDetailViewModel MoviesDetail
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MoviesDetailViewModel>();
            }
        }
        public MasterDetailViewModel MasterDetail
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MasterDetailViewModel>();
            }
        }
        public VideoPlayerViewModel VideoPlayer
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VideoPlayerViewModel>();
            }
        }

        public MoviesTabbedViewModel MoviesTabbed
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MoviesTabbedViewModel>();
            }
        }

        public TopRatedMoviesViewModel TopRatedMovies
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TopRatedMoviesViewModel>();
            }
        }

        public PopularMoviesViewModel PopularMovies
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PopularMoviesViewModel>();
            }
        }

        public NowPlayingMoviesViewModel NowPlayingMovies
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NowPlayingMoviesViewModel>();
            }
        }
        #endregion
    }
}

using System;
using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using AsNum.XFControls.Droid;

using FormsToolkit.Droid;
using Plugin.Media;
using Refractored.XamForms.PullToRefresh.Droid;
using FavMovies;

namespace FavMovies.Droid
{
    [Activity(Label = "FavMovies", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;


            Toolkit.Init();
            PullToRefreshLayoutRenderer.Init();
            UserDialogs.Init(this);

            base.OnCreate(bundle);
            AsNumAssemblyHelper.HoldAssembly();

          //  CachedImageRenderer.Init();


            global::Xamarin.Forms.Forms.Init(this, bundle);
           LoadApplication(new App());
        }
    }
}


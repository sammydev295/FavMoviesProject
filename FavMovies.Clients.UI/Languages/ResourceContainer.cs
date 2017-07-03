using System.Resources;
using System.Globalization;

using FavMovies.Languages;
using FavMovies.Clients.Portable.Interfaces;
using Xamarin.Forms;


[assembly: Dependency(typeof(ResourceContainer))]
namespace FavMovies.Languages
{
    public class ResourceContainer : IResourceContainer
    {
        public static string ResourceId = "FavMovies.Clients.UI.Languages.Lang"; // The namespace and name of your Resources file
        private CultureInfo _cultureInfo;
        private ResourceManager _resourceManager;

        public ResourceContainer(ResourceManager manager, ILocalize localize)
        {
            _cultureInfo = localize.GetCurrentCultureInfo();
            _resourceManager = manager;
        }

        public string GetString(string key)
        {
            return _resourceManager.GetString(key, _cultureInfo);
        }
    }
}

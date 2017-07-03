using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using Plugin.Media;
using Plugin.Media.Abstractions;

[assembly: Xamarin.Forms.Dependency(typeof(FavMovies.Clients.Portable.MediaService))]
namespace FavMovies.Clients.Portable
{
    public interface IMediaService
    {
        Task<Tuple<ImageSource, string>> SelectSource(Application App);
        Task<Tuple<ImageSource, string>> PickPhoto(Application App);
        Task<Tuple<ImageSource, string>> TakePhoto(Application App);
        Task<string> PickVideo(Application App);
        Task<string> TakeVideo(Application App);
    }

    public class MediaService : IMediaService
    {
        /// <summary>
        /// Pick an existing picture from the camera roll or take a new picture
        /// </summary>
        /// <param name="App"></param>
        /// <returns>a Tuple with 2 items, the image source and the album file path to the selected or snapped picture</returns>
        public async Task<Tuple<ImageSource, string>> SelectSource(Application App)
        {
            var selectedItem = await App.MainPage.DisplayActionSheet("Choose Media", "Cancel",
                null, "Take Photo", "Browse From Album");

            Tuple<ImageSource, string> src = null;
            switch (selectedItem)
            {
                case "Take Photo":
                    src = await TakePhoto(App);
                    break;
                case "Browse From Album":
                    src = await PickPhoto(App);
                    break;
            }

            return src;
        }

        /// Pick an existing picture from the camera roll album
        /// </summary>
        /// <param name="App">Non null if method should display error and prompt messages to caller</param>
        /// <returns>a Tuple with 2 items, the image source and the album file path to the selected picture. If something goes wrong then the first item returned is null with the error message in the 2nd item</returns>
        public async Task<Tuple<ImageSource, string>> PickPhoto(Application App = null)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                if(App != null)
                    await App.MainPage.DisplayAlert("Photos Not Supported", ":( Permission not granted to take photo", "OK");

                return new Tuple<ImageSource, string>(null, ":( Permission not granted to take photo");
            }
            MediaFile file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions()
            {
                CustomPhotoSize = 50,
                PhotoSize = PhotoSize.Medium,
            });

            var path = file.Path;
            return new Tuple<ImageSource, string>(ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            }), path);
        }

        /// <summary>
        /// Take a new picture with the camera
        /// </summary>
        /// <param name="App">Non null if method should display error and prompt messages to caller</param>
        /// <returns>a Tuple with 2 items, the image source and the album file path to the snapped picture. If something goes wrong then the first item returned is null with the error message in the 2nd item</returns>
        /// <summary>
        public async Task<Tuple<ImageSource, string>> TakePhoto(Application App = null)
        {
            if (!CrossMedia.Current.IsTakePhotoSupported)
            {
                if (App != null)
                    await App.MainPage.DisplayAlert("Message", "Camera not Available!", "Okay");

                return new Tuple<ImageSource, string>(null, ":( Camera not Available!");
            }

            MediaFile file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions()
            {
                Directory = "Sealegs",
                SaveToAlbum = true,
                Name = "Sealegs " + DateTime.Now.ToString("yyyyMMddHHmmss")
            });

            var path = file.Path;
            return new Tuple<ImageSource, string>(ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            }), path);
        }

        /// <summary>
        /// Cature a new video with the camera
        /// </summary>
        /// <param name="App">Non null if method should display error and prompt messages to caller</param>
        /// <returns>The file path to the captured video. If something goes wrong then the null is returned</returns>
        /// <summary>
        public async Task<string> PickVideo(Application App = null)
        {
            if (!CrossMedia.Current.IsPickVideoSupported)
            {
                if (App != null)
                    await App.MainPage.DisplayAlert("Videos Not Supported", ":( Permission not granted to videos.", "OK");
                return null;
            }
            var file = await CrossMedia.Current.PickVideoAsync();
            if (file == null)
                return null;

            var filePath = file.Path;
            await App.MainPage.DisplayAlert("Video Selected", "Location: " + file.Path, "OK");
            file.Dispose();

            return filePath;
        }

        /// <summary>
        /// Pick an existing video from the camera roll album
        /// </summary>
        /// <param name="App">Non null if method should display error and prompt messages to caller</param>
        /// <returns>The file path to the selected video. If something goes wrong then the null is returned</returns>
        /// <summary>
        public async Task<string> TakeVideo(Application App)
        {
            if (!CrossMedia.Current.IsTakeVideoSupported)
            {
                if (App != null)
                    await App.MainPage.DisplayAlert("Message", "Camera not Available !", "Okay");
                return null;
            }

            var file = await CrossMedia.Current.TakeVideoAsync(new Plugin.Media.Abstractions.StoreVideoOptions
            {
                Name = "video.mp4",
                Directory = "DefaultVideos",
            });

            if (file == null)
                return null;

            var filePath = file.Path;
            await App.MainPage.DisplayAlert("Video Recorded", "Location: " + file.Path, "OK");

            file.Dispose();

            return filePath;
        }
    }
}

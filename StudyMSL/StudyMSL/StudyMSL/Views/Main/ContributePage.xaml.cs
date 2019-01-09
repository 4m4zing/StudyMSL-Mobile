using Plugin.Media;
using Plugin.Media.Abstractions;
using StudyMSL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudyMSL.Views.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContributePage : ContentPage
    {
        //Variable Assignments
        private MediaFile _mediaFile;
        string name_malay = "", desc_malay = "", username;

        //Default Ctor
        public ContributePage()
        {
            InitializeComponent();

            username = App.Current.Properties["Username"] as string;

            etyImgName.Completed += (object sender, EventArgs e) =>
            {
                etyImgNameMalay.Focus();
            };

            etyImgNameMalay.Completed += (object sender, EventArgs e) =>
            {
                etyImgDesc.Focus();
            };

            etyImgDesc.Completed += (object sender, EventArgs e) =>
            {
                etyImgDescMalay.Focus();
            };
        }

        //Button Choose Image Event Handler
        private async void btnChooseImage_OnClicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Information", "Upload image not supported \n\nClick OK to continue", "OK");
                return;
            }

            _mediaFile = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
            {
                CompressionQuality = 80
            });

            if (_mediaFile == null)
            {
                return;
            }

            lblLocalImagePath.Text = _mediaFile.Path;

            imgUpload.Source = ImageSource.FromStream(() =>
            {
                return _mediaFile.GetStream();
            });
        }

        //Button Take Image Event Handler
        private async void btnTakeImage_OnClicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Information", "Camera is not available \n\nClick OK to continue", "OK");
                return;
            }

            _mediaFile = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                DefaultCamera = CameraDevice.Rear,
                CompressionQuality = 80,
                SaveToAlbum = true,
                Directory = "StudyMSL",
                Name = "CapturedImage_" + DateTime.Now.Date.ToString("ddMMyyyy") + ".jpg"
            });

            _mediaFile = await CrossMedia.Current.PickPhotoAsync();

            if (_mediaFile == null)
            {
                return;
            }

            lblLocalImagePath.Text = _mediaFile.Path;

            imgUpload.Source = ImageSource.FromStream(() =>
            {
                return _mediaFile.GetStream();
            });
        }

        //Button Upload Image Event Handler
        private async void btnUploadImage_OnClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(etyImgName.Text) || string.IsNullOrWhiteSpace(etyImgDesc.Text))
            {
                await DisplayAlert("Warning", "Please enter all information required \n\nClick OK to continue", "OK");
                return;
            }

            if (!string.IsNullOrWhiteSpace(etyImgNameMalay.Text) || !string.IsNullOrWhiteSpace(etyImgDescMalay.Text))
            {
                name_malay = etyImgDescMalay.Text;
                desc_malay = etyImgDescMalay.Text;
            }

            if (_mediaFile == null)
            {
                await DisplayAlert("Warning", "No Image is selected \n\nClick OK to continue", "OK");
                return;
            }

            btnUploadImage.IsEnabled = false;

            var content = new MultipartFormDataContent();

            content.Add(new StreamContent(_mediaFile.GetStream()),
                "\"file\"", $"\"{_mediaFile.Path}\"");

            var httpclient = new HttpClient();
            var url = "https://studymsl.azurewebsites.net/api/uploads/user";
            var httpResponseMessage = await httpclient.PostAsync(url, content);
            var filename = _mediaFile.Path.Split('\\').LastOrDefault().Split('/').LastOrDefault();

            ((ContributeViewModel)BindingContext).Init("word", etyImgName.Text, name_malay,
                                                        "https://studymsl.azurewebsites.net/uploads/user_uploads/" + filename, etyImgDesc.Text, desc_malay, username);

            btnUploadImage.IsEnabled = true;

            lblResponse.Text = await httpResponseMessage.Content.ReadAsStringAsync();
        }

        //Entry Name Malay Text Event Handler
        private void etyImgNameMalay_TextChanged(object sender, TextChangedEventArgs e)
        {
            //name_malay = etyImgDescMalay.Text.ToString();
        }

        //Entry Desc Malay Text Event Handler
        private void etyImgDescMalay_TextChanged(object sender, TextChangedEventArgs e)
        {
            //desc_malay = etyImgDescMalay.Text.ToString();
        }
    }
}
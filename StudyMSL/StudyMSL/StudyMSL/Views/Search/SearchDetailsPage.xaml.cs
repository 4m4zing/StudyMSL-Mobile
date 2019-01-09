using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudyMSL.Views.Search
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchDetailsPage : PopupPage
    {
        //Overload Ctor
        public SearchDetailsPage(StudyMSL.Models.Learn learn)
        {
            InitializeComponent();
            imgSearch.Source = learn.image_dir;
            lblSearchName.Text = learn.image_name;
            lblSearchNameMalay.Text = learn.image_name_malay;
            lblSearcDesc.Text = learn.image_desc;
            lblSearcDescMalay.Text = learn.image_desc_malay;
        }

        //Button Close Event Handler
        private async void btnClose_OnClicked(object sender, System.EventArgs e)
        {
            Navigation.PopPopupAsync();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Send(this, "Clear");
        }

        //Handle Device Display Resolution
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            var size = width - 10;

            imgSearch.WidthRequest = size;
            imgSearch.HeightRequest = size;
        }
    }
}
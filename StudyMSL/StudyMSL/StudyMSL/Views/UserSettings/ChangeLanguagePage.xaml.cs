using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudyMSL.Views.UserSettings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangeLanguagePage : ContentPage
    {
        //Default Ctor
        public ChangeLanguagePage()
        {
            InitializeComponent();
            pLanguage.SelectedItem = StudyMSL.Services.Settings.LanguageSetting;
        }

        //Button Save Event Handler
        private async void btnSave_OnClicked(object sender, EventArgs e)
        {
            var language = pLanguage.SelectedItem.ToString();
            StudyMSL.Services.Settings.LanguageSetting = language;
            await DisplayAlert("Learning Language Changed", 
                "The learning language is successfully changed to " + language + " \n\nClick OK to return", "OK");
            await Navigation.PopAsync();
        }
    }
}
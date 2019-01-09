using StudyMSL.Views.UserSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudyMSL.Views.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        //Default Ctor
        public SettingsPage()
        {
            InitializeComponent();
        }

        //Button Change Password Event Handler
        private async void btnChangePassword_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChangePasswordPage());
        }

        //Button Change Language Event Handler
        private async void btnChangeLanguage_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChangeLanguagePage());
        }
    }
}
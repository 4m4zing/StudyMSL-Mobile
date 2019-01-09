using StudyMSL.ViewModels;
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
    public partial class ChangePasswordPage : ContentPage
    {
        //Default Ctor
        public ChangePasswordPage()
        {
            InitializeComponent();

            etyCurrentPassword.Completed += (object sender, EventArgs e) =>
            {
                etyNewPassword.Focus();
            };

            etyNewPassword.Completed += (object sender, EventArgs e) =>
            {
                etyConfirmNewPassword.Focus();
            };
        }

        //Button Save Event Handler
        private async void btnSave_OnClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(etyCurrentPassword.Text) || string.IsNullOrWhiteSpace(etyNewPassword.Text)
                || string.IsNullOrWhiteSpace(etyConfirmNewPassword.Text))
            {
                await DisplayAlert("Warning", "Please enter all required information \n\nClick OK to continue", "OK");
                return;
            }

            if (etyNewPassword.Text != etyConfirmNewPassword.Text)
            {
                await DisplayAlert("Warning", "The new password entered does not matched \n\nClick OK to continue", "OK");
                return;
            }

            btnSave.IsEnabled = false;

            var username = App.Current.Properties["Username"] as string;
            var message = await ((LoginViewModel)BindingContext).ChangePassword(username, etyCurrentPassword.Text, etyNewPassword.Text);

            if (message)
            {
                btnSave.IsEnabled = true;
                await DisplayAlert("Successful Changed", "The new password is successfully changed \n\nClick OK to continue", "OK");
                await Navigation.PopAsync();
                return;
            }
            else
            {
                btnSave.IsEnabled = true;
                await DisplayAlert("Unsuccessful Change", "Failed to change new password \n\nClick OK to continue", "OK");
                return;
            }
        }
    }
}
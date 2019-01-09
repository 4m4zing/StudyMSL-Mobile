using StudyMSL.ViewModels;
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
    public partial class RegisterPage : ContentPage
    {
        //Default Ctor
        public RegisterPage()
        {
            InitializeComponent();

            etyUsername.Completed += (object sender, EventArgs e) =>
            {
                etyPassword.Focus();
            };

            etyPassword.Completed += (object sender, EventArgs e) =>
            {
                etyConfirmPassword.Focus();
            };

            etyConfirmPassword.Completed += (object sender, EventArgs e) =>
            {
                etyEmail.Focus();
            };
        }

        //Button Register Event Handler
        private async void btnRegister_OnClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(etyUsername.Text) || string.IsNullOrWhiteSpace(etyPassword.Text)
                || string.IsNullOrWhiteSpace(etyConfirmPassword.Text) || string.IsNullOrWhiteSpace(etyEmail.Text))
            {
                await DisplayAlert("Warning", "Please enter all required information \n\nClick OK to continue", "OK");
                return;
            }

            if (etyPassword.Text != etyConfirmPassword.Text)
            {
                await DisplayAlert("Warning", "The password entered does not matched \n\nClick OK to continue", "OK");
                return;
            }

            btnRegister.IsEnabled = false;

            var message = await ((LoginViewModel)BindingContext).RegisterLogin(etyUsername.Text, etyPassword.Text, etyEmail.Text);

            if (message)
            {
                btnRegister.IsEnabled = true;
                await DisplayAlert("Successfully Registered", "The new account is successfully registered \n\nClick OK to continue", "OK");
                //return;

                Navigation.PopAsync();
            }
            else
            {
                btnRegister.IsEnabled = true;
                await DisplayAlert("Unsuccessful Registration", "Failed to register new account \n\nClick OK to continue", "OK");
                return;
            }
        }

        //Label Have Account Event Handler
        private async void lblHaveAccount_OnClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
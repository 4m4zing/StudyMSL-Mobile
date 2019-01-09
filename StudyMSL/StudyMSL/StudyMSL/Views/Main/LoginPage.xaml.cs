using Plugin.Connectivity;
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
    public partial class LoginPage : ContentPage
    {
        //Default Ctor
        public LoginPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            etyUsername.Completed += (object sender, EventArgs e) =>
            {
                etyPassword.Focus();
            };

            etyPassword.Completed += (object sender, EventArgs e) =>
            {
                btnLogin_OnClicked(sender, e);
            };

        }

        //Check for Internet Connectivity
        private void CheckConnectivity()
        {
            var connection = CrossConnectivity.Current.IsConnected;

            if (connection == true)
            {

                //DisplayAlert("Alert", "Have Internet connection!", "OK");
            }
            else
            {
                DisplayAlert("Warning", "No Internet connection!", "OK");
                //System.Threading.Thread.Sleep(1000);
                Application.Current.Quit();
            }
        }

        //Button Login Event Handler
        private async void btnLogin_OnClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(etyUsername.Text) || string.IsNullOrWhiteSpace(etyPassword.Text))
            {
                await DisplayAlert("Warning", "Please enter all required information \n\nClick OK to continue", "OK");
                return;
            }

            btnLogin.IsEnabled = false;

            var userlogin = await ((LoginViewModel)BindingContext).VerifyLogin(etyUsername.Text.ToString(), etyPassword.Text.ToString());

            if (userlogin)
            {
                btnLogin.IsEnabled = true;
                //DisplayAlertLogin();
                App.Current.Properties["Username"] = etyUsername.Text;
                App.Current.Properties["Userid"] = await ((LoginViewModel)BindingContext).getUserID(etyUsername.Text);
                Application.Current.MainPage = new StudyMSL.Views.Main.MasterDetailMainPage();
            }
            else
            {
                btnLogin.IsEnabled = true;
                DisplayAlertLoginFailed();
            }
        }

        //Label Create Account Event Handler
        private async void lblCreateAccount_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }

        //Label No Account Event Handler
        private async void lblNoAccount_OnClicked(object sender, EventArgs e)
        {
            //MasterDetailPage fpm = new MasterDetailPage();
            //fpm.Master = new Cocos.Views.Main.MasterPage(); // You have to create a Master ContentPage()
            //fpm.Detail = new NavigationPage(new Cocos.Views.Main.MasterDetail()); // You have to create a Detail ContenPage()
            App.Current.Properties["Username"] = "User";
            App.Current.Properties["Userid"] = "0";
            Application.Current.MainPage = new StudyMSL.Views.Main.MasterDetailMainPage();
        }

        //Show Success Alert
        private async void DisplayAlertLogin()
        {
            await DisplayAlert("Success Login", "Welcome, " + etyUsername.Text + "!" + " \n\nClick OK to return", "OK");
        }

        //Show Failed Alert
        private async void DisplayAlertLoginFailed()
        {
            await DisplayAlert("Failed Login", "Wrong Username or Password! \n\nClick OK to return", "OK");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            CheckConnectivity();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}
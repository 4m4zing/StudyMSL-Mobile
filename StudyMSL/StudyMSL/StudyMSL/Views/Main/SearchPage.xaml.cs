using Rg.Plugins.Popup.Extensions;
using StudyMSL.ViewModels;
using StudyMSL.Views.Search;
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
    public partial class SearchPage : ContentPage
    {
        //Default Ctor
        public SearchPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<SearchDetailsPage>(this, "Clear", (view) => clearListView());
        }

        //Searchbar ByName Event Handler
        private async void sbByName_OnClicked(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(sbByName.Text))
            {
                //lblAlphabet.IsVisible = false;
                //lblNumber.IsVisible = false;
                //lblWord.IsVisible = false;
            }
            else
            {
                lblAlphabet.IsVisible = true;
                lblNumber.IsVisible = true;
                lblWord.IsVisible = true;

                await ((SearchViewModel)BindingContext).Init(sbByName.Text);

                if (((SearchViewModel)BindingContext).getAlphabetCount() == 0)
                {
                    lblNoAlphabet.IsVisible = true;
                }
                else
                {
                    lblNoAlphabet.IsVisible = false;
                }

                if (((SearchViewModel)BindingContext).getNumberCount() == 0)
                {
                    lblNoNumber.IsVisible = true;
                }
                else
                {
                    lblNoNumber.IsVisible = false;
                }

                if (((SearchViewModel)BindingContext).getWordCount() == 0)
                {
                    lblNoWord.IsVisible = true;
                }
                else
                {
                    lblNoWord.IsVisible = false;
                }
            }
        }

        //Listview Alphabet Tap Event Handler
        private void lvAlphabet_OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            var item = args.Item as StudyMSL.Models.Learn;
            Navigation.PushPopupAsync(new SearchDetailsPage(item));
        }

        //Listview Number Tap Event Handler
        private void lvNumber_OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            var item = args.Item as StudyMSL.Models.Learn;
            Navigation.PushPopupAsync(new SearchDetailsPage(item));
        }

        //Listview Word Tap Event Handler
        private void lvWord_OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            var item = args.Item as StudyMSL.Models.Learn;
            Navigation.PushPopupAsync(new SearchDetailsPage(item));
        }

        //Clear the Listview Tap Item
        private void clearListView()
        {
            lvAlphabets.SelectedItem = null;
            lvNumbers.SelectedItem = null;
            lvWords.SelectedItem = null;
        }
    }
}
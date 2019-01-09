using StudyMSL.Models;
using StudyMSL.Views.Learn.Fingerspelling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudyMSL.Views.Learn
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FingerspellingPage : ContentPage
    {
        //Variable Assignments
        public List<FingerspellingPageItem> FPItems;

        //Default Ctor
        public FingerspellingPage()
        {
            InitializeComponent();
            setItem();
            MessagingCenter.Subscribe<FingerspellingLearningPage>(this, "Clear", (view) => clearListView());
        }

        //Set Fingerspelling Learn Pages
        private void setItem()
        {
            FPItems = new List<FingerspellingPageItem>();
            FPItems.Add(new FingerspellingPageItem("Alphabets", "aIcon_Alphabet_200.png", 
                new FingerspellingLearningPage("F01", "Fingerspelling", "alphabet", "Alphabets")));
            FPItems.Add(new FingerspellingPageItem("Numbers", "aIcon_Number_200.png", 
                new FingerspellingLearningPage("F02", "Fingerspelling", "number", "Numbers")));
            lvFingerspellingPage.ItemsSource = FPItems;
        }

        //Listview Fingerspelling Tap Event Handler
        private void lvFingerspellingPage_OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            var item = args.Item as FingerspellingPageItem;
            Navigation.PushAsync(item.page);
        }

        //Clear the Listview Tap Item
        private void clearListView()
        {
            lvFingerspellingPage.SelectedItem = null;
        }
    }
}
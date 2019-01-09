using StudyMSL.Models;
using StudyMSL.Views.Sentences;
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
    public partial class SentencesPage : ContentPage
    {
        //Variable Assignments
        public List<SentencesPageItem> SPItems;

        //Default Ctor
        public SentencesPage()
        {
            InitializeComponent();
            setItem();
            MessagingCenter.Subscribe<SentencesLearningPage>(this, "Clear", (view) => clearListView());
            MessagingCenter.Subscribe<MalaySentencesLearningPage>(this, "Clear", (view) => clearListView());
        }

        //Set Sentence Learn Pages
        private void setItem()
        {
            SPItems = new List<SentencesPageItem>();
            SPItems.Add(new SentencesPageItem("English Sentence Builder", "aIcon_Alphabet_200.png", new SentencesLearningPage("word")));
            SPItems.Add(new SentencesPageItem("Malay Sentence Builder", "aIcon_Alphabet_200.png", new MalaySentencesLearningPage("word")));
            lvSentencesPage.ItemsSource = SPItems;
        }

        //Listview Sentence Tap Event Handler
        private void lvSentencesPage_OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            var item = args.Item as SentencesPageItem;
            Navigation.PushAsync(item.page);
        }

        //Clear the Listview Tap Item
        private void clearListView()
        {
            lvSentencesPage.SelectedItem = null;
        }
    }
}
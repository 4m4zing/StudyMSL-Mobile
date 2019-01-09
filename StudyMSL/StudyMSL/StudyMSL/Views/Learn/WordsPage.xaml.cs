using StudyMSL.Models;
using StudyMSL.Views.Learn.Words;
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
    public partial class WordsPage : ContentPage
    {
        //Variable Assignments
        public List<WordsPageItem> WPItems;

        //Default Ctor
        public WordsPage()
        {
            InitializeComponent();
            setItem();
            MessagingCenter.Subscribe<WordsLearningPage>(this, "Clear", (view) => clearListView());
        }

        //Set Word Learn Pages
        private void setItem()
        {
            WPItems = new List<WordsPageItem>();
            WPItems.Add(new WordsPageItem("Greetings", "aIcon_Greetings.png", new WordsLearningPage("W01", "Words", "word", "Greetings")));
            WPItems.Add(new WordsPageItem("Pronouns", "aIcon_Pronouns.png", new WordsLearningPage("W02", "Words", "word", "Pronouns")));
            WPItems.Add(new WordsPageItem("Family", "aIcon_Family.png", new WordsLearningPage("W03", "Words", "word", "Family")));
            WPItems.Add(new WordsPageItem("Questions", "aIcon_Questions.png", new WordsLearningPage("W04", "Words", "word", "Questions")));
            //WPItems.Add(new WordsPageItem("Conjunctions", "Icon_Conjunctions.png", new WordsLearningPage("W05", "Words", "word", "Conjunctions")));
            WPItems.Add(new WordsPageItem("Auxiliary Verbs", "aIcon_AuxiliaryVerb.png", new WordsLearningPage("W06", "Words", "word", "Auxiliary Verbs")));
            WPItems.Add(new WordsPageItem("Feelings", "aIcon_Feelings.png", new WordsLearningPage("W07", "Words", "word", "Feelings")));
            WPItems.Add(new WordsPageItem("Verb", "aIcon_Verb.png", new WordsLearningPage("W08", "Words", "word", "Verbs")));
            WPItems.Add(new WordsPageItem("Transports", "aIcon_Transport.png", new WordsLearningPage("W14", "Words", "word", "Transports")));
            WPItems.Add(new WordsPageItem("User Uploads", "aIcon_UserUpload.png", new WordsLearningPage("WU", "Words", "word", "User Uploads")));
            lvWordsPage.ItemsSource = WPItems;
        }

        //Listview Word Tap Event Handler
        private void lvWordsPage_OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            var item = args.Item as WordsPageItem;
            Navigation.PushAsync(item.page);
        }

        //Clear the Listview Tap Item
        private void clearListView()
        {
            lvWordsPage.SelectedItem = null;
        }
    }
}
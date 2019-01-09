using StudyMSL.Views.GamesAndQuizzes.Games.Memory;
using StudyMSL.Views.GamesAndQuizzes.Games.PictureSpelling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudyMSL.Views.GamesAndQuizzes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamesPage : ContentPage
    {
        //Default Ctor
        public GamesPage()
        {
            InitializeComponent();
        }

        //Button Alphabet Memory Event Handler
        private void btnAlphabetMemory_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MemoryGamePage("F01G01", "Alphabets", "alphabet"));
        }

        //Button Alphabet Picture Spelling Event Handler
        private void btnAlphabetSpelling_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PictureSpellingGamePage("F01G02", "Alphabets", "alphabet"));
        }

        //Button Number Memory Event Handler
        private void btnNumberMemory_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MemoryGamePage("F02G01", "Numbers", "number"));
        }

        //Button Number Picture Spelling Event Handler
        private void btnNumberSpelling_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PictureSpellingGamePage("F02G02", "Numbers", "number"));
        }

        //Button Word Memory Event Handler
        private void btnWordMemory_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MemoryGamePage("WG01", "Words", "word"));
        }
    }
}
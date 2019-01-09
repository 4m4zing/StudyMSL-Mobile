using StudyMSL.Views.GamesAndQuizzes.Quizzes.FITB;
using StudyMSL.Views.GamesAndQuizzes.Quizzes.MCQ;
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
    public partial class QuizzesPage : ContentPage
    {
        //Default Ctor
        public QuizzesPage()
        {
            InitializeComponent();
        }

        //Button Alphabet MCQ Event Handler
        private void btnAlphabetMCQ_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MCQQuizPage("F01Q01", "Alphabets", "alphabet"));
        }

        //Button Alphabet FITB Event Handler
        private void btnAlphabetFITB_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FITBQuizPage("F01Q02", "Alphabets", "alphabet"));
        }

        //Button Number MCQ Event Handler
        private void btnNumberMCQ_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MCQQuizPage("F02Q01", "Numbers", "number"));
        }

        //Button Number FITB Event Handler
        private void btnNumberFITB_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FITBQuizPage("F02Q02", "Numbers", "number"));
        }

        //Button Word MCQ Event Handler
        private void btnWordMCQ_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MCQQuizPage("WQ01", "Words", "word"));
        }

        //Button Word FITB Event Handler
        private void btnWordFITB_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FITBQuizPage("WQ02", "Words", "word"));
        }
    }
}
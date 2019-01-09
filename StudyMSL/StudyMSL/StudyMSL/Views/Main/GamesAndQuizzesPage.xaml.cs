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
    public partial class GamesAndQuizzesPage : TabbedPage
    {
        //Default Ctor
        public GamesAndQuizzesPage()
        {
            InitializeComponent();
        }
    }
}
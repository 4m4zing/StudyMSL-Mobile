using StudyMSL.Models;
using StudyMSL.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudyMSL.ViewModels
{
    class SearchViewModel : INotifyPropertyChanged
    {
        /*..........Attribute Assignments..........*/
        private ObservableCollection<Learn> _AlphabetsOC = new ObservableCollection<Learn>();
        public ObservableCollection<Learn> AlphabetsOC
        {
            get { return _AlphabetsOC; }
            set
            {
                _AlphabetsOC = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Learn> _NumbersOC = new ObservableCollection<Learn>();
        public ObservableCollection<Learn> NumbersOC
        {
            get { return _NumbersOC; }
            set
            {
                _NumbersOC = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Learn> _WordsOC = new ObservableCollection<Learn>();
        public ObservableCollection<Learn> WordsOC
        {
            get { return _WordsOC; }
            set
            {
                _WordsOC = value;
                OnPropertyChanged();
            }
        }

        private LearnServices learnServices = new LearnServices();
        /*.........................................*/


        /*..........Default Constructor..........*/
        public SearchViewModel()
        {
        }
        /*.......................................*/


        /*..........Search Methods..........*/
        public async Task Init(string id)
        {
            await GetAlphabetAsync(id);
            await GetNumberAsync(id);
            await GetWordAsync(id);
        }

        //get an ObservableCollection list of Alphabet objects
        private async Task GetAlphabetAsync(string keyword)
        {
            var alphabetsList = await learnServices.GetLearnByNameAll(keyword, "alphabet");
            AlphabetsOC = new ObservableCollection<Learn>(alphabetsList);
        }

        //get an ObservableCollection list of Number objects
        private async Task GetNumberAsync(string keyword)
        {
            var numbersList = await learnServices.GetLearnByNameAll(keyword, "number");
            NumbersOC = new ObservableCollection<Learn>(numbersList);
        }

        //get an ObservableCollection list of Word objects
        private async Task GetWordAsync(string keyword)
        {
            var wordsList = await learnServices.GetLearnByNameAll(keyword, "word");
            WordsOC = new ObservableCollection<Learn>(wordsList);
        }

        //return Alphabet ObservableCollection list count
        public int getAlphabetCount()
        {
            return AlphabetsOC.Count;
        }

        //return Number ObservableCollection list count
        public int getNumberCount()
        {
            return NumbersOC.Count;
        }

        //return Word ObservableCollection list count
        public int getWordCount()
        {
            return WordsOC.Count;
        }
        /*..................................*/


        /*..........Property Changed Event Handler..........*/
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
        /*..................................................*/
    }
}

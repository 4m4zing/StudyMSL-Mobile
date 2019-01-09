using StudyMSL.Models;
using StudyMSL.Plugins.Timer;
using StudyMSL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StudyMSL.ViewModels
{
    public class QuestionViewModel : INotifyPropertyChanged
    {
        /*..........Attribute Assignments..........*/
        public bool found = false;

        private List<Question> _QuestionsList;
        public List<Question> QuestionsList
        {
            get { return _QuestionsList; }
            set
            {
                _QuestionsList = value;
                OnPropertyChanged();
            }
        }

        private Progress _recordedprogress = new Progress();
        public Progress recordedprogress
        {
            get { return _recordedprogress; }
            set
            {
                _recordedprogress = value;
                OnPropertyChanged();
            }
        }

        private Progress _progressdetails = new Progress();
        public Progress progressdetails
        {
            get { return _progressdetails; }
            set
            {
                _progressdetails = value;
                OnPropertyChanged();
            }
        }

        private string _question_id;
        public string question_id
        {
            get { return _question_id; }
            set
            {
                _question_id = value;
                OnPropertyChanged();
            }
        }

        private string _question;
        public string question
        {
            get { return _question; }
            set
            {
                _question = value;
                OnPropertyChanged();
            }
        }

        private string _image_dir;
        public string image_dir
        {
            get { return _image_dir; }
            set
            {
                _image_dir = value;
                OnPropertyChanged();
            }
        }

        private string _answer;
        public string answer
        {
            get { return _answer; }
            set
            {
                _answer = value;
                OnPropertyChanged();
            }
        }

        private int _answerindex;
        public int answerindex
        {
            get { return _answerindex; }
            set
            {
                _answerindex = value;
                OnPropertyChanged();
            }
        }

        private string _answer1;
        public string answer1
        {
            get { return _answer1; }
            set
            {
                _answer1 = value;
                OnPropertyChanged();
            }
        }

        private string _answer2;
        public string answer2
        {
            get { return _answer2; }
            set
            {
                _answer2 = value;
                OnPropertyChanged();
            }
        }

        private string _answer3;
        public string answer3
        {
            get { return _answer3; }
            set
            {
                _answer3 = value;
                OnPropertyChanged();
            }
        }

        private string _answer4;
        public string answer4
        {
            get { return _answer4; }
            set
            {
                _answer4 = value;
                OnPropertyChanged();
            }
        }

        private int _score;
        public int score
        {
            get { return _score; }
            set
            {
                _score = value;
                OnPropertyChanged();
            }
        }

        private int _number;
        public int number
        {
            get { return _number; }
            set
            {
                _number = value;
                OnPropertyChanged();
            }
        }

        private Timer _timer;
        public Timer timer
        {
            get { return _timer; }
            set
            {
                _timer = value;
                OnPropertyChanged();
            }
        }

        private TimeSpan _duration = new TimeSpan(0, 0, 0, 60);
        public TimeSpan duration
        {
            get { return _duration; }
            set
            {
                _duration = value;
                OnPropertyChanged();
            }
        }

        private double _time;
        public double time
        {
            get { return _time; }
            set
            {
                _time = value;
                OnPropertyChanged();
            }
        }

        Random rdm = new Random();
        /*.........................................*/


        /*..........Default Constructor..........*/
        public QuestionViewModel()
        {
        }
        /*.......................................*/


        /*..........Question Methods..........*/
        public void Init(string type)
        {
            InitDataAsync(type);

            timer = new Timer(TimeSpan.FromSeconds(1), CountDown);
            duration = _duration;
            score = 0;
        }

        private async Task InitDataAsync(string type)
        {
            var questionServices = new QuestionServices();

            try
            {
                QuestionsList = await questionServices.GetQuestions(type);
            }
            catch (Exception exc)
            {
            }
            NextQuestion();
        }

        //set current question and answer
        public void NextQuestion()
        {
            int qindex = rdm.Next(0, QuestionsList.Count);
            Question selectedItem = QuestionsList[qindex];

            question_id = selectedItem.question_id;
            image_dir = selectedItem.image_dir;
            question = selectedItem.question1;
            answer = selectedItem.answer;
            answerindex = selectedItem.answerindex;
            answer1 = selectedItem.answer1;
            answer2 = selectedItem.answer2;
            answer3 = selectedItem.answer3;
            answer4 = selectedItem.answer4;

            QuestionsList.RemoveAt(qindex);
        }

        //set question number
        public void setQuestionNo(int qNumber)
        {
            number = qNumber;
        }

        //increase score
        public void setScore()
        {
            score++;
        }

        //return score
        public int getScore()
        {
            return score;
        }

        //return time
        public double getTime()
        {
            return time;
        }

        //check answers
        public bool isCorrect(int inputAnswer)
        {
            if (answerindex == inputAnswer)
            {
                //-->if answer index matched
                return true;
            }
            return false;
        }

        //check answers
        public bool isCorrect(string inputAnswer)
        {
            if (answer == inputAnswer)
            {
                //-->if answer matched
                return true;
            }
            return false;
        }
        /*.....................................*/


        /*..........Timer Methods..........*/
        //start the timer
        public void startTimer()
        {
            timer.Start();
        }

        //manage the timer countdown
        private void CountDown()
        {
            //set display countdown time
            time = duration.TotalSeconds;

            if (duration.TotalSeconds == 0)
            {
                //-->if countdown ends
                stopTimer();
                displayTimeOut();
            }
            else
            {
                //-->if countdown
                duration = _duration.Subtract(new TimeSpan(0, 0, 0, 1));
            }
        }

        //stop the timer
        public void stopTimer()
        {
            duration = new TimeSpan(0, 0, 0, 60);
            _timer.Stop();
        }

        //call the view alert
        private async void displayTimeOut()
        {
            MessagingCenter.Send(this, "TimeOut");
        }
        /*.................................*/


        /*..........Progress Methods..........*/
        //manage the progress
        public async void DoProgress(string questionid, string questiontitle, string questiontype, string questioncontent)
        {
            var userid = App.Current.Properties["Userid"] as string;
            var message = await CheckProgressAsync(userid, questionid);

            if (!message)
            {
                //-->if record not exist
                setPostProgressData(userid, questionid, questiontitle, questioncontent);
                PostProgressAsync();
            }
            else
            {
                //-->if record existed
                recordedprogress = await GetProgressAsync(userid, questionid);

                if (Convert.ToInt32(recordedprogress.content_desc) < score)
                {
                    //-->if current score is higher than record's score
                    var result = await DeleteProgressAsync();

                    if (result)
                    {
                        //-->if successfully deleted a record
                        setPostProgressData(userid, questionid, questiontitle, questioncontent);
                        PostProgressAsync();
                    }
                }
            }
        }

        //check for a progress existence
        private async Task<bool> CheckProgressAsync(string userid, string contentid)
        {
            var progressServices = new ProgressServices();
            var response = await progressServices.GetProgressBool(userid, contentid);
            return response;
        }

        //get a progress object
        private async Task<Progress> GetProgressAsync(string userid, string contentid)
        {
            var progressServices = new ProgressServices();
            var response = await progressServices.GetProgress(userid, contentid);
            return response;
        }

        //post a progress object
        private async Task PostProgressAsync()
        {
            var progressServices = new ProgressServices();
            await progressServices.PostProgress(progressdetails);
        }

        //delete a progress object
        private async Task<bool> DeleteProgressAsync()
        {
            var progressServices = new ProgressServices();
            var response = await progressServices.DeleteProgressBool(recordedprogress.p_id);
            return response;
        }

        //set a progress data to be posted
        private void setPostProgressData(string userid, string questionid, string questiontitle, string questioncontent)
        {
            progressdetails.user_id = userid;
            progressdetails.content_id = questionid;
            progressdetails.content_name = questiontitle + " - " + questioncontent;
            progressdetails.content_desc = score.ToString();
            progressdetails.date_completed = DateTime.Now;
        }

        //destroy progress objects
        public void destroyProgress()
        {
            _progressdetails = new Progress();
            _recordedprogress = new Progress();
        }
        /*....................................*/


        /*..........Property Changed Event Handler..........*/
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
        /*..................................................*/
    }
}
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
    public class MemoryMatchingViewModel : INotifyPropertyChanged
    {
        /*..........Attribute Assignments..........*/
        string resourcesurl = "https://studymsl.azurewebsites.net/uploads/";
        bool taken1 = false, taken2 = false, taken3 = false, taken4 = false, taken5 = false, taken6 = false;

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

        private string _q_image1;
        public string q_image1
        {
            get { return _q_image1; }
            set
            {
                _q_image1 = value;
                OnPropertyChanged();
            }
        }

        private string _q_image2;
        public string q_image2
        {
            get { return _q_image2; }
            set
            {
                _q_image2 = value;
                OnPropertyChanged();
            }
        }

        private string _q_image3;
        public string q_image3
        {
            get { return _q_image3; }
            set
            {
                _q_image3 = value;
                OnPropertyChanged();
            }
        }

        private string _q_image4;
        public string q_image4
        {
            get { return _q_image4; }
            set
            {
                _q_image4 = value;
                OnPropertyChanged();
            }
        }

        private string _q_image5;
        public string q_image5
        {
            get { return _q_image5; }
            set
            {
                _q_image5 = value;
                OnPropertyChanged();
            }
        }

        private string _q_image6;
        public string q_image6
        {
            get { return _q_image6; }
            set
            {
                _q_image6 = value;
                OnPropertyChanged();
            }
        }

        private string _q_image1_val;
        public string q_image1_val
        {
            get { return _q_image1_val; }
            set
            {
                _q_image1_val = value;
                OnPropertyChanged();
            }
        }

        private string _q_image2_val;
        public string q_image2_val
        {
            get { return _q_image2_val; }
            set
            {
                _q_image2_val = value;
                OnPropertyChanged();
            }
        }

        private string _q_image3_val;
        public string q_image3_val
        {
            get { return _q_image3_val; }
            set
            {
                _q_image3_val = value;
                OnPropertyChanged();
            }
        }

        private string _q_image4_val;
        public string q_image4_val
        {
            get { return _q_image4_val; }
            set
            {
                _q_image4_val = value;
                OnPropertyChanged();
            }
        }

        private string _q_image5_val;
        public string q_image5_val
        {
            get { return _q_image5_val; }
            set
            {
                _q_image5_val = value;
                OnPropertyChanged();
            }
        }

        private string _q_image6_val;
        public string q_image6_val
        {
            get { return _q_image6_val; }
            set
            {
                _q_image6_val = value;
                OnPropertyChanged();
            }
        }

        private int _score = 100;
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

        private double _time = 60;
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
        public MemoryMatchingViewModel()
        {
        }
        /*.......................................*/


        /*..........Memory Matching Methods..........*/
        public void Init(string type)
        {
            InitDataAsync(type);

            _timer = new Timer(TimeSpan.FromSeconds(1), CountDown);
            duration = _duration;
            score = 100;
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
            ThreeQuestion(type);
        }

        //set three images and three labels for the game
        public void ThreeQuestion(string type)
        {
            taken1 = false;
            taken2 = false;
            taken3 = false;
            taken4 = false;
            taken5 = false;
            taken6 = false;

            int rdm1 = rdm.Next(1, 7);
            int rdm2 = rdm.Next(1, 7);
            int rdm3 = rdm.Next(1, 7);
            int rdm4 = rdm.Next(1, 7);
            int rdm5 = rdm.Next(1, 7);
            int rdm6 = rdm.Next(1, 7);

            int qindex1 = rdm.Next(0, QuestionsList.Count);
            randomizeImage(rdm1, qindex1);
            randomizeLabel(rdm4, qindex1, type);
            QuestionsList.RemoveAt(qindex1);

            int qindex2 = rdm.Next(0, QuestionsList.Count);
            randomizeImage(rdm2, qindex2);
            randomizeLabel(rdm5, qindex2, type);
            QuestionsList.RemoveAt(qindex2);

            int qindex3 = rdm.Next(0, QuestionsList.Count);
            randomizeImage(rdm3, qindex3);
            randomizeLabel(rdm6, qindex3, type);
            QuestionsList.RemoveAt(qindex3);
        }

        //set image to display on which image viewer
        public void randomizeImage(int img_viewer, int qindex)
        {
            string ext = QuestionsList[qindex].answer.ToString();
            bool done = false;
            while (done != true)
            {
                if (img_viewer == 1)
                {
                    if (taken1 != true)
                    {
                        q_image1 = QuestionsList[qindex].image_dir;
                        q_image1_val = ext;
                        taken1 = true;
                        done = true;
                    }
                }
                else if (img_viewer == 2)
                {
                    if (taken2 != true)
                    {
                        q_image2 = QuestionsList[qindex].image_dir;
                        q_image2_val = ext;
                        taken2 = true;
                        done = true;
                    }
                }
                else if (img_viewer == 3)
                {
                    if (taken3 != true)
                    {
                        q_image3 = QuestionsList[qindex].image_dir;
                        q_image3_val = ext;
                        taken3 = true;
                        done = true;
                    }
                }
                else if (img_viewer == 4)
                {
                    if (taken4 != true)
                    {
                        q_image4 = QuestionsList[qindex].image_dir;
                        q_image4_val = ext;
                        taken4 = true;
                        done = true;
                    }
                }
                else if (img_viewer == 5)
                {
                    if (taken5 != true)
                    {
                        q_image5 = QuestionsList[qindex].image_dir;
                        q_image5_val = ext;
                        taken5 = true;
                        done = true;
                    }
                }
                else
                {
                    if (taken6 != true)
                    {
                        q_image6 = QuestionsList[qindex].image_dir;
                        q_image6_val = ext;
                        taken6 = true;
                        done = true;
                    }
                }

                if (done == true)
                {
                    break;
                }
                else
                {
                    img_viewer = rdm.Next(1, 7);
                }
            }
        }

        //set label to display on which image viewer
        public void randomizeLabel(int img_viewer, int qindex, string type)
        {
            string full;
            string label = QuestionsList[qindex].answer.ToString();
            bool done = false;

            if (type == "alphabet")
            {
                var ext = "labels/lblAlphabet_" + label + ".jpg";
                full = resourcesurl + ext;
            }
            else
            {
                var ext = "labels/lblNumber_" + label + ".jpg";
                full = resourcesurl + ext;
            }

            while (done != true)
            {
                if (img_viewer == 1)
                {
                    if (taken1 != true)
                    {
                        q_image1 = full;
                        q_image1_val = label;
                        taken1 = true;
                        done = true;
                    }
                }
                else if (img_viewer == 2)
                {
                    if (taken2 != true)
                    {
                        q_image2 = full;
                        q_image2_val = label;
                        taken2 = true;
                        done = true;
                    }
                }
                else if (img_viewer == 3)
                {
                    if (taken3 != true)
                    {
                        q_image3 = full;
                        q_image3_val = label;
                        taken3 = true;
                        done = true;
                    }
                }
                else if (img_viewer == 4)
                {
                    if (taken4 != true)
                    {
                        q_image4 = full;
                        q_image4_val = label;
                        taken4 = true;
                        done = true;
                    }
                }
                else if (img_viewer == 5)
                {
                    if (taken5 != true)
                    {
                        q_image5 = full;
                        q_image5_val = label;
                        taken5 = true;
                        done = true;
                    }
                }
                else
                {
                    if (taken6 != true)
                    {
                        q_image6 = full;
                        q_image6_val = label;
                        taken6 = true;
                        done = true;
                    }
                }

                if (done == true)
                {
                    break;
                }
                else
                {
                    img_viewer = rdm.Next(1, 7);
                }
            }
        }

        //change score
        public void setScore(int changescore)
        {
            score += changescore;
        }

        //increase step
        public void setStep()
        {
            number++;
        }

        //return score
        public int getScore()
        {
            return score;
        }

        //return step
        public int getStep()
        {
            return number;
        }

        //return time
        public double getTime()
        {
            return time;
        }

        //return answer value
        public string getInput(int inputAnswer)
        {
            if (inputAnswer == 1)
            {
                return q_image1_val;
            }
            else if (inputAnswer == 2)
            {
                return q_image2_val;
            }
            else if (inputAnswer == 3)
            {
                return q_image3_val;
            }
            else if (inputAnswer == 4)
            {
                return q_image4_val;
            }
            else if (inputAnswer == 5)
            {
                return q_image5_val;
            }
            else
            {
                return q_image6_val;
            }
        }

        //check answers
        public bool isCorrect(int inputAnswer1, int inputAnswer2)
        {
            string compare1 = getInput(inputAnswer1);
            string compare2 = getInput(inputAnswer2);

            if (compare1 == compare2)
            {
                //-->if answers matched
                setScore(2);
                return true;
            }
            setScore(-5);
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

using System;
using System.Collections.Generic;
using System.Text;

namespace StudyMSL.Models
{
    public class Question
    {
        public string question_id { get; set; }
        public string question_type { get; set; }
        public string image_dir { get; set; }
        public string question1 { get; set; }
        public string answer { get; set; }
        public int answerindex { get; set; }
        public string answer1 { get; set; }
        public string answer2 { get; set; }
        public string answer3 { get; set; }
        public string answer4 { get; set; }
    }
}

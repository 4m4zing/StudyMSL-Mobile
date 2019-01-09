using System;
using System.Collections.Generic;
using System.Text;

namespace StudyMSL.Models
{
    public class Progress
    {
        public int p_id { get; set; }
        public string user_id { get; set; }
        public string content_id { get; set; }
        public string content_name { get; set; }
        public string content_desc { get; set; }
        public System.DateTime date_completed { get; set; }

        public Progress() { }

        public Progress(string user_id, string content_id, string content_name, string content_desc, DateTime date_completed)
        {
            this.user_id = user_id;
            this.content_id = content_id;
            this.content_name = content_name;
            this.content_desc = content_desc;
            this.date_completed = date_completed;
        }
    }
}

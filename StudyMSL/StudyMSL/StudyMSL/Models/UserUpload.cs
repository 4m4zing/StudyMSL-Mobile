using System;
using System.Collections.Generic;
using System.Text;

namespace StudyMSL.Models
{
    public class UserUpload
    {
        public int image_id { get; set; }
        public string image_type { get; set; }
        public string image_name { get; set; }
        public string image_name_malay { get; set; }
        public string image_dir { get; set; }
        public string image_desc { get; set; }
        public string image_desc_malay { get; set; }
        public string uploader { get; set; }
        public Nullable<System.DateTime> upload_time { get; set; }
    }
}

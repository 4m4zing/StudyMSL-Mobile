using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace StudyMSL.Models
{
    public class SentencesPageItem
    {
        public string Title { get; set; }
        public string IconSource { get; set; }
        public Page page { get; set; }

        public SentencesPageItem(string title, string iconsource, Page page)
        {
            this.Title = title;
            this.IconSource = iconsource;
            this.page = page;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace StudyMSL.Models
{
    public class MainMenuItem
    {
        public string Title { get; set; }
        public Type TargetType { get; set; }
        public string IconSource { get; set; }

        public MainMenuItem(string title, string iconsource, Type targettype)
        {
            this.Title = title;
            this.IconSource = iconsource;
            this.TargetType = targettype;
        }
    }
}

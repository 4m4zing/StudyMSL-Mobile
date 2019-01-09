using System;
using System.Collections.Generic;
using System.Text;

namespace StudyMSL.Plugins.CustomRenderer
{
    public interface ToastAlert
    {
        void LongAlert(string message);
        void ShortAlert(string message);
    }
}

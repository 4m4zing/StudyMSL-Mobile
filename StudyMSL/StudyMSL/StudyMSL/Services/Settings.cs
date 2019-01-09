using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyMSL.Services
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string LanguageSettingsKey = "language_settings_key";
        private static readonly string SettingsDefault = "English";

        #endregion


        public static string LanguageSetting
        {
            get
            {
                return AppSettings.GetValueOrDefault(LanguageSettingsKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(LanguageSettingsKey, value);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Licencing
{
    public static class Trial
    {
        public static void SaveStartDateOfTrial()
        {
            IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;
            if (!appSettings.Contains("dateoftrialstart"))
            {
                appSettings.Add("dateoftrialstart", DateTime.Today);
            }
            appSettings.Save();
        }

        public static DateTime GetStartDateOfTrial()
        {
            DateTime returnValue = DateTime.Today;

            IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;

            if (appSettings.Contains("dateoftrialstart"))
            {
                returnValue = (DateTime)appSettings["dateoftrialstart"];
            }

            return returnValue;
        }

        public static int GetDaysLeftInTrial()
        {
            int returnValue = 0;
            IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;

            if (appSettings.Contains("dateoftrialstart"))
            {
                DateTime startDate = (DateTime)appSettings["dateoftrialstart"];

                TimeSpan daysTimespan = startDate.AddDays(GetDaysInTrial()) - DateTime.Today;

                returnValue = daysTimespan.Days;
            }

            return returnValue;
        }

        public static bool IsTrialExpired()
        {
            bool trialExpired = false;

            DateTime startDateOfTrial = GetStartDateOfTrial();
            DateTime endDateOfTrial = startDateOfTrial.AddDays(GetDaysInTrial());

            if (endDateOfTrial < DateTime.Today)
            {
                trialExpired = true;
            }

            return trialExpired;
        }

        private static int GetDaysInTrial()
        {
            int returnValue = 0;
            try
            {
                IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;
                if (!appSettings.Contains("numberofdaysintrial"))
                {
                    //Default days in trial
                    returnValue = 3;
                }
                else
                {
                    returnValue = 10;
                }
            }
            catch (Exception ex)
            {

            }

            return returnValue;
        }

        public static void Add10DaysToTrial()
        {
            try
            {
                IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;
                if (!appSettings.Contains("numberofdaysintrial"))
                {
                    appSettings.Add("numberofdaysintrial", 10);
                }
                else
                {
                    appSettings["numberofdaysintrial"] = 10;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.IsolatedStoreage;
using System.Windows;
using Microsoft.Phone.Tasks;

namespace Common.Utilities
{
    public static class Rate
    {


        //5th, 10th, 15th time prompt, 20th time ok only to rate, never prompt them again after they rate.
        public static void RateTheApp(string rateTheAppQuestion, string rateTheAppPrompt, string rateAppHeader)
        {
            MessageBoxResult msgResult;
            int appOpenedCount = 0;
            string hasAppBeenRated = string.Empty;

            try
            {
                appOpenedCount = AppOpenedCount();
                hasAppBeenRated = HasAppBeenRated();
                if ((appOpenedCount == 5 || appOpenedCount == 10 || appOpenedCount == 15) && hasAppBeenRated.ToUpper() == "NO")
                {
                    msgResult = MessageBox.Show(rateTheAppQuestion, rateAppHeader, MessageBoxButton.OKCancel);
                    if (msgResult == MessageBoxResult.OK)
                    {
                        MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();
                        marketplaceReviewTask.Show();

                        IS.SaveSetting("AppRated", "Yes");
                    }
                    else
                    {
                        IS.SaveSetting("AppRated", "No");
                    }
                }
                else
                {
                    if (appOpenedCount >= 20 && hasAppBeenRated.ToUpper() == "NO")
                    {
                        msgResult = MessageBox.Show(rateTheAppPrompt, rateAppHeader, MessageBoxButton.OK);
                        MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();
                        marketplaceReviewTask.Show();
                        if (msgResult == MessageBoxResult.OK)
                        {
                            IS.SaveSetting("AppRated", "Yes");
                        }
                    }
                }
            }
            catch (Exception ex)
            {


            }
        }

        //This proc will add 1 to the number of times the app has been opened and return that value and save that value
        public static int AppOpenedCount()
        {
            int returnValue = 0;
            string settingValue = string.Empty;

            try
            {
                if (IS.GetSettingStringValue("AppOpenedCount") != string.Empty)
                {
                    settingValue = IS.GetSettingStringValue("AppOpenedCount");
                    returnValue = Convert.ToInt16(settingValue) + 1;
                    IS.SaveSetting("AppOpenedCount", returnValue.ToString());
                }
                else   //has not been opened yet so intitialize as first time being opened
                {
                    IS.SaveSetting("AppOpenedCount", "1");
                    returnValue = 1;
                }
            }
            catch (Exception)
            {
                ;
                return 0;
            }
            return returnValue;
        }

        public static string HasAppBeenRated()
        {
            string returnValue = string.Empty;

            try
            {
                if (IS.GetSettingStringValue("AppRated") != string.Empty)
                {
                    returnValue = IS.GetSettingStringValue("AppRated");
                }
                else
                {
                    IS.SaveSetting("AppRated", "No");
                    returnValue = "No";
                }
            }
            catch (Exception)
            {
                return "No";
            }
            return returnValue;
        }
    }
}

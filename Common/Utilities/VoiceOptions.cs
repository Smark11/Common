using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utilities
{
    public enum Pitch
    {
        ExtraLow,
        Low,
        Medium,
        High,
        ExtraHigh,
        Default
    }

    public enum Speed
    {
        ExtraSlow,
        Slow,
        Medium,
        Fast,
        ExtraFast,
        Default
    }

    public enum SpeakerVolume
    {
        ExtraSoft,
        Soft,
        Medium,
        Loud,
        ExtraLoud,
        Default
    }

    public static class VoiceOptions
    {
        public static string GetText(string stringToSpeak, Pitch pitch, Speed speed, SpeakerVolume volume, string language)
        {
            string returnValue;

            returnValue = "<speak version=\"1.0\" ";
            returnValue += "xmlns=\"http://www.w3.org/2001/10/synthesis\" xml:lang=\"" + language +"\" >";
            returnValue += "<prosody rate= \"" + GetRate(speed) + "\"";
            returnValue += " volume= \"" + GetVolume(volume) + "\"";
            returnValue += " pitch=\"" + GetPitch(pitch) + "\" >";
            returnValue += stringToSpeak;
            returnValue += "</prosody>";
            returnValue += "</speak>";

            return returnValue;
        }

        /// <summary>
        /// Pitch of the voice
        /// </summary>
        /// <param name="pitch"></param>
        /// <returns></returns>
        private static string GetPitch(Pitch pitch)
        {
            string returnValue = string.Empty;
            switch (pitch)
            {
                case Pitch.ExtraLow:
                    returnValue = "x-low";
                    break;
                case Pitch.Low:
                    returnValue = "low";
                    break;
                case Pitch.Medium:
                    returnValue = "medium";
                    break;
                case Pitch.High:
                    returnValue = "high";
                    break;
                case Pitch.ExtraHigh:
                    returnValue = "x-high";
                    break;
                case Pitch.Default:
                    returnValue = "default";
                    break;
            }

            return returnValue;
        }

        /// <summary>
        /// Rate at which the word is said
        /// </summary>
        /// <param name="rate"></param>
        /// <returns></returns>
        private static string GetRate(Speed rate)
        {
            string returnValue = string.Empty;

            switch (rate)
            {
                case Speed.ExtraSlow:
                    returnValue = "x-slow";
                    break;
                case Speed.Slow:
                    returnValue = "slow";
                    break;
                case Speed.Medium:
                    returnValue = "medium";
                    break;
                case Speed.Fast:
                    returnValue = "fast";
                    break;
                case Speed.ExtraFast:
                    returnValue = "x-fast";
                    break;
                case Speed.Default:
                    returnValue = "default";
                    break;
            }

            return returnValue;
        }

        /// <summary>
        /// Get volume to speak text
        /// </summary>
        /// <param name="volume"></param>
        /// <returns></returns>
        private static string GetVolume(SpeakerVolume volume)
        {
            string returnValue = string.Empty;

            switch (volume)
            { 
                case SpeakerVolume.ExtraSoft:
                    returnValue = "x-soft";
                    break;
                case SpeakerVolume.Soft:
                    returnValue = "soft";
                    break;
                case SpeakerVolume.Medium:
                    returnValue = "medium";
                    break;
                case SpeakerVolume.Loud:
                    returnValue = "loud";
                    break;
                case SpeakerVolume.ExtraLoud:
                    returnValue = "x-loud";
                    break;
                case SpeakerVolume.Default:
                    returnValue = "default";
                    break;
            }

            return returnValue;
        }
    }
}

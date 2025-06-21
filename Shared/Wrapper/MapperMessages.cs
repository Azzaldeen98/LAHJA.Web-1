using Shared.Enums;

namespace Shared.Wrapper;

public class MapperMessages
{

    public static string Map(string arMsg, string enMsg, object lang =null)
    {
        if (lang == null) return enMsg;

        string langCode = "en";

        if (lang is string langStr)
        {
            langCode = langStr.ToLower();
        }
        else if (lang is AvailableLanguage availableLang)
        {
            langCode = availableLang.ToString().ToLower();
        }

        return langCode == "ar" ? arMsg : enMsg;
    }


    //public static string Map(string arMsg,string enMsg, AvailableLanguage lang=AvailableLanguage.EN)
    //{
    //    if (lang == AvailableLanguage.AR) return arMsg;
    //    else if (lang == AvailableLanguage.AR) return enMsg;
    //    else return enMsg;
    //}
    //public static string MapSrc(string arMsg, string enMsg, string lang ="en")
    //{
    //    if (lang == AvailableLanguage.AR.ToString().ToLower()) return arMsg;
    //    else if (lang == AvailableLanguage.AR.ToString().ToLower()) return enMsg;
    //    else return enMsg;
    //}


}
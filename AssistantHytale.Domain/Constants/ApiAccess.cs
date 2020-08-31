using System.Collections.Generic;

namespace AssistantHytale.Domain.Constants
{
    public static class ApiAccess
    {
        public static string Public = "public";
        //public static string Auth = "authenticated";
        public static string All = "all";

        public static List<string> PublicControllers = new List<string>
        {
            "About",
            "Hypixel",
            "Version"
        };
    }
}

﻿using System.Collections.Generic;

namespace AssistantHytale.Domain.Constants
{
    public static class ApiCorsSettings
    {
        public static string[] ExposedHeaders = new List<string>
        {
            "Token",
            "TokenExpiry",
            "UserGuid",
            "loadingTitle",
            "Authorization",
            "reloadtype",
            "content-type",
            "cache-control",

        }.ToArray();

        public static string[] AllowedMethods = new List<string>
        {
            "GET",
            "PUT",
            "POST",
            "DELETE",
            "OPTIONS",
        }.ToArray();
    }
}

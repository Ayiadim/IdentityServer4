﻿using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Http
{
    public static class HttpResponseExtensions
    {
        private readonly static JsonSerializerSettings settings = new JsonSerializerSettings
        {
            DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore
        };

        public static async Task WriteJsonAsync(this HttpResponse response, object o)
        { 
            var json = JsonConvert.SerializeObject(o, settings);
            await response.WriteJsonAsync(json);
        }

        public static async Task WriteJsonAsync(this HttpResponse response, string json)
        {
            response.ContentType = "application/json";
            await response.WriteAsync(json);
        }
    }
}
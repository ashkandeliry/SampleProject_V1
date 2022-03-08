using Newtonsoft.Json;
using System;

namespace Common.Extensions
{
    public static class JsonExtentions
    {
        public static string ToJson(this object input)
        {
            return JsonConvert.SerializeObject(input);
        }
        public static T ToObject<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
        public static object ToObject(this string json, object obj)
        {
            return JsonConvert.DeserializeAnonymousType(json, obj);
        }
        public static object ToObject(this string json, Type type)
        {
            return JsonConvert.DeserializeObject(json, type);
        }
    }
}

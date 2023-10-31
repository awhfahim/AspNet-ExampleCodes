using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonFormat
{
    public static class JsonFormatter
    {
        public static string ToJson<T>(T obj)
        {
            var type = typeof(T);
            var properties = type.GetProperties();

            StringBuilder jsonString = new StringBuilder();

            foreach(var property in properties)
            {
                jsonString.Append($"\"{property.Name}\":");
                JsonFormatter.AppendJsonString()
            }
            return jsonString.ToString();
        }

        public static T FromJson<T>(string jsonString)
        {
            return default(T);
        }

        private static void AppendJsonString(StringBuilder sb, object jsonString)
        {

        }
    }
}

﻿using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GlobalServer.Properties.Response.Converters
{
    public class ResponseConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) 
            => throw new NotImplementedException();
        
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jo = JObject.Load(reader);

            var method = jo.GetValue("method", StringComparison.CurrentCultureIgnoreCase)
                .Value<string>()
                .ToLower();
            return jo.ToObject(ResponseTypeFactory.GetResponse(method).GetType());
        }

        public override bool CanConvert(Type objectType)
            => objectType == typeof(ResponseBase) || objectType == typeof(ResponseBase);
    }
}
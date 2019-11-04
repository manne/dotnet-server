﻿using Newtonsoft.Json;
using GlobalServer.Properties.Request;
using GlobalServer.Properties.Request.Converters;

namespace GlobalServer.Properties
{
    public class ServerInteraction
    {
        public string Description { get; set; }

        [JsonConverter(typeof(RequestConverter))]
        public RequestDescription Request { get; set; }
        public ResponseDescription Response { get; set; }
    }
}
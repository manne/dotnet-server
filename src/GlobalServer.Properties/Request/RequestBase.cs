﻿using GlobalServer.Properties.Request.Queries;

namespace GlobalServer.Properties.Request
{
    public abstract class RequestBase
    {
        internal abstract string Method { get; }
    
        public string Path { get; set; }

        public abstract void Accept(Visitor visitor);
    }
}
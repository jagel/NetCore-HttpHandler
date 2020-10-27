using System;
using HttpHandler.Headers;

namespace HttpHandler.Initializers
{
    public abstract class HttpBaseContext
    {
        public string Uri {get; set;}
        public HeaderParameters Header;

        public HttpBaseContext(string uri)
        {
            Uri = uri;
            Header = ConfigureHeaderParameters(new HeaderParameters());
        }

        public virtual HeaderParameters ConfigureHeaderParameters(HeaderParameters parameters)
        {
            return parameters;
        }

        public abstract void BuildEndPoints();
    }
}
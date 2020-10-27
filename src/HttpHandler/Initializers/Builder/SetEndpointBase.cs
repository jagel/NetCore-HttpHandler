using HttpHandler.Headers;
using HttpHandler.Headers.ParameterModels;
using HttpHandler.Initializers;

namespace APIService.Builder
{
    public class SetEndpointBase
    {
        protected string FullUrl;
        protected string URLSite;
        protected string Endpoint;

        private HeaderParameters headers;
        private HeaderParameters customHeader;
        private HeaderParameters partialHeader;


        public SetEndpointBase(HttpBaseContext context, string Endpoint)
        {
            URLSite = context.Uri;
            this.Endpoint = Endpoint;
            headers = context.Header;

            FullUrl = $"{URLSite}{Endpoint}";
        }

        public delegate void HeaderDelegate(HeaderParametersModifiers headerParam);

        /// <summary>
        /// Declare configuration by endpoint 
        /// </summary>
        /// <param name="header"></param>
        public void HeaderCustom(HeaderDelegate header)
        {
            var modifiers = new HeaderParametersModifiers();
            header(modifiers);
            customHeader = Setmodifiers(modifiers);
        }

        /// <summary>
        /// Declare header configuration by call 
        /// </summary>
        /// <param name="header"></param>
        public void HeaderByRequest(HeaderDelegate header)
        {
            var modifiers = new HeaderParametersModifiers();
            header(modifiers);
            partialHeader = Setmodifiers(modifiers);
        }


        public HeaderParameters GetHeaderConfig()
        {
            if (partialHeader != null)
            {
                var _pheader = partialHeader;
                partialHeader = null;
                return _pheader;
            }
            if (customHeader != null)
                return customHeader;
            else
                return headers;
        }


        private HeaderParameters Setmodifiers(HeaderParametersModifiers modifiers)
        {
            var customHeader = new HeaderParameters();
            headers.HeaderList.ForEach(parameter => customHeader.AddParameter(parameter));

            modifiers.ModelRemoveHeaderList
             .ForEach(x => customHeader.RemoveParameter(x));

            modifiers.ModelAddHeaderList
                .ForEach(x => customHeader.AddParameter(x));

            customHeader.AuthHeader = modifiers.AuthHeader;

            return customHeader;
        }


    }
  
}

using System.Collections.Generic;
using System.Net.Http.Headers;

namespace HttpHandler.Headers.ParameterModels
{
    public class HeaderParametersModifiers
    {
        internal List<string> ModelRemoveHeaderList { get; set; }
        internal List<HeaderParameterStructure> ModelAddHeaderList { get; set; }
        internal AuthenticationHeaderValue AuthHeader { get; set; }

        public HeaderParametersModifiers()
        {
            ModelRemoveHeaderList = new List<string>();
            ModelAddHeaderList = new List<HeaderParameterStructure>();
        }
      
        public void AddParameterHeader(HeaderParameterStructure headerParameterStructure) => ModelAddHeaderList.Add(headerParameterStructure);
        public void RemoveParameterHeader(string valueName) => ModelRemoveHeaderList.Add(valueName);


        public void AddAuthenticator(AuthenticationHeaderValue header) => AuthHeader = header;
        public void RemoveAuthenticator() => AuthHeader = null;
        public void ReplaceAuthenticator(AuthenticationHeaderValue header) => AuthHeader = header;


    }
}

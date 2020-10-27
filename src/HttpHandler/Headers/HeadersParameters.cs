using System.Linq;
using System.Collections.Generic;
using HttpHandler.Headers.ParameterModels;
using HttpHandler.Exceptions;
using System.Net.Http.Headers;

namespace HttpHandler.Headers
{
    public class HeaderParameters
    {
        internal List<HeaderParameterStructure> HeaderList { get; set; }
        internal AuthenticationHeaderValue AuthHeader { get; set; }

        public HeaderParameters()
        {
            HeaderList = new List<HeaderParameterStructure>();
        }

         public void AddParameter(HeaderParameterStructure headerParameterStructure)
        {
            IsHeaderExist(headerParameterStructure.Name);
            HeaderList.Add(headerParameterStructure);
        }

        public void RemoveParameter(string ParameterName)
        {
            if (!IsHeaderExist(ParameterName, false))
                throw new HttpHandlerExceptiosn($"Parameter : {ParameterName} not found","Encabezados", ExceptionError.Internal_InconsistencyData);
            var removeItem = HeaderList.First(x => x.Name == ParameterName);
            HeaderList.Remove(removeItem);
        }


        public bool IsHeaderExist(string Name, bool throwException = true){
            bool exist = HeaderList.Any(x => x.Name == Name);
            if(exist && throwException)
              throw new HttpHandlerExceptiosn($"Global Param: {Name} is already declared","Encabezados", ExceptionError.Internal_InconsistencyData);
            return exist;
        }

        public void AddAuthentication(AuthenticationHeaderValue auth) => AuthHeader = auth;
    }
}
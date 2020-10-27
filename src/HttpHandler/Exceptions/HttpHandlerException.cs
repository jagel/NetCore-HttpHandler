using System;

namespace HttpHandler.Exceptions
{
    public class HttpHandlerExceptiosn : Exception
    {

        public ExceptionError CodeError { get; set; }
        public string ExternalError { get; set; }

        public HttpHandlerExceptiosn(string message, string Key, ExceptionError codeError) : base(message)
        {
             CodeError = codeError;

            switch (CodeError)
            {
                case ExceptionError.Data_NotFound:
                    ExternalError = $"No se han Localizado datos de la Institucion Seleccionada. Error:{Key}";
                    break;
                case ExceptionError.Petition_BadRequest:
                    ExternalError = $"Error al intentar obtener petición. Error:{Key}";
                    break;
                case ExceptionError.Internal_ErrorBuildingData:
                    ExternalError = $"Error al generar cadena de peticiones. Error:{Key}";
                    break;
                case ExceptionError.Internal_InconsistencyData:
                    ExternalError = $"Error al generar respuesta. Error:{Key}";
                    break;

            }
        }
    }
}
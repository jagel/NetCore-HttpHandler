namespace HttpHandler.BitsoExample.ConfigExternalHttp.Responses
{
    public class ResponseBaseModel<TPayloadModel>
    {
        public string Success { get; set; }
        public TPayloadModel Payload  { get; set; }
    }
}
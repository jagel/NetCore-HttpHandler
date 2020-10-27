using HttpHandler.Initializers;
using HttpHandler.Initializers.Builder;
using HttpHandler.BitsoExample.ConfigExternalHttp.Responses;

namespace HttpHandler.BitsoExample
{
    public class BitsoExternalContext : HttpBaseContext
    {
        public BitsoExternalContext(string uri) : base(uri)
        {
        }

        public SetEndpoint<ResponseBookList> AvailableBooks {get; set;}

        public override void BuildEndPoints()
        {
            AvailableBooks = new SetEndpoint<ResponseBookList>(this, "available_books");
        }
    }
}
using System.Threading.Tasks;
using HttpHandler.Utils.Extensions;
using HttpHandler.Resolvers;

namespace HttpHandler.Initializers.Builder
{
      /// <summary>
    /// Set new enpoint in the context
    /// </summary>
    /// <typeparam name="TModelResponse">Model Response</typeparam>
    public class SetEndpoint<TModelResponse> : EndpointSetBase where TModelResponse : new()
    {

        /// <summary>
        /// Declare endpoint to build configuration
        /// </summary>
        /// <param name="context">Use same context</param>
        /// <param name="Endpoint">endpoint structure ex. endpoint/{0} </param>
        public SetEndpoint(HttpBaseContext context, string Endpoint) : base(context, Endpoint)
        {

        }

        /// <summary>
        /// Get async Data from HTTPGet method
        /// </summary>
        /// <param name="URLParameters">TransactionParameters to be transform in values within the url</param>
        /// <returns>TModelResponse</returns>
        public async Task<TModelResponse> HttpGetAsync(object URLParameters = null)
        {
            var endpoint = URLParameters != null ?
                Endpoint.Inject(URLParameters) :
                Endpoint;

            var gerHeaderParams = GetHeaderConfig();

            var ResponseBody = await RestClientMiddleware.GetData<TModelResponse>(URLSite, endpoint, gerHeaderParams);
            return ResponseBody;
        }

        /// <summary>
        /// Get async Data from HTTPost method
        /// </summary>
        /// <typeparam name="TModelRequest">Body Model Request Class</typeparam>
        /// <param name="BodyRequest">Body Model Request Data</param>
        /// <param name="URLParameters">Parameters to be transform in values within the url</param>
        /// <returns>TModelResponse</returns>
        public async Task<TModelResponse> HttpPostAsync<TModelRequest>(TModelRequest BodyRequest, object URLParameters)
        {
            var endpoint = Endpoint.Inject(URLParameters);
            var gerHeaderParams = GetHeaderConfig();

            var ResponseBody = await RestClientMiddleware.GetPost<TModelResponse, TModelRequest>(BodyRequest, URLSite, endpoint, gerHeaderParams);
            return ResponseBody;
        }
    }
}


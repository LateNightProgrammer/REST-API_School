using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SriSloka.Api.HttpClient
{
    public class HttpRequestBuilder
    {
        private HttpMethod method = null;
        private string requestUri = "";
        private HttpContent content = null;
        private string bearerToken = "";
        private string acceptHeader = "application/json";
        private TimeSpan timeout = new TimeSpan(0, 0, 15);
        private bool allowAutoRedirect = false;

        public HttpRequestBuilder()
        {
        }

        public HttpRequestBuilder AddMethod(HttpMethod httpMethod)
        {
            method = httpMethod;
            return this;
        }
        
        public HttpRequestBuilder AddRequestUri(string uri)
        {
            requestUri = uri;
            return this;
        }

        public HttpRequestBuilder AddContent(HttpContent httpContent)
        {
            content = httpContent;
            return this;
        }

        public HttpRequestBuilder AddBearerToken(string requestBearerToken)
        {
            bearerToken = requestBearerToken;
            return this;
        }

        public HttpRequestBuilder AddAcceptHeader(string httpAcceptHeader)
        {
            acceptHeader = httpAcceptHeader;
            return this;
        }

        public HttpRequestBuilder AddTimeout(TimeSpan requestTimeout)
        {
            timeout = requestTimeout;
            return this;
        }

        public HttpRequestBuilder AddAllowAutoRedirect(bool requestAllowAutoRedirect)
        {
            allowAutoRedirect = requestAllowAutoRedirect;
            return this;
        }

        public async Task<HttpResponseMessage> SendAsync()
        {
            // Check required arguments
            EnsureArguments();

            // Set up request
            var request = new HttpRequestMessage
            {
                Method = this.method,
                RequestUri = new Uri(this.requestUri)
            };

            if (this.content != null)
                request.Content = this.content;

            if (!string.IsNullOrEmpty(this.bearerToken))
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", this.bearerToken);

            request.Headers.Accept.Clear();
            if (!string.IsNullOrEmpty(this.acceptHeader))
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(this.acceptHeader));

            // Setup client
            var handler = new HttpClientHandler {AllowAutoRedirect = this.allowAutoRedirect};

            var client = new System.Net.Http.HttpClient(handler) {Timeout = this.timeout};

            return await client.SendAsync(request);
        }

        #region " Private "

        private void EnsureArguments()
        {
            if (this.method == null)
                throw new ArgumentNullException("Method");
            
            if (string.IsNullOrEmpty(this.requestUri))
                throw new ArgumentNullException("Request Uri");
        }

        #endregion
    }
}

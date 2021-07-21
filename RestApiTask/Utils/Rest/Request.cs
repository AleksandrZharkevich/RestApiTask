using RestSharp;

namespace RestApiTask.Utils.Rest
{
    class Request
    {
        public string BaseUrl { get; set; }
        public string Resource { get; set; }
        public RequestDataFormat DataFormat { get; set; }

        public Request(string baseUrl, string resource, RequestDataFormat dataFormat)
        {
            BaseUrl = baseUrl;
            Resource = resource;
            DataFormat = dataFormat;
        }

        public Request(string baseUrl, string resource)
        : this(baseUrl, resource, RequestDataFormat.JSON)
        { }

        public Request(string baseUrl)
            : this(baseUrl, "", RequestDataFormat.JSON)
        {
        }

        public RestRequest ToRestRequest()
        {
            string resource = this.Resource;
            DataFormat dataFormat = this.DataFormat switch
            {
                RequestDataFormat.JSON => RestSharp.DataFormat.Json,
                RequestDataFormat.XML => RestSharp.DataFormat.Xml,
                _ => RestSharp.DataFormat.None
            };

            return new RestRequest(resource, dataFormat);
        }
    }
}

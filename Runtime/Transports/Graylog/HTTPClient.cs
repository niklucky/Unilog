using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UnilogTransports.Graylog
{
    public class HttpGelfClient : IGELFClient
    {
        private readonly HttpClient _httpClient;

        public HttpGelfClient(Options options)
        {
            var uriBuilder = new UriBuilder
            {
                Scheme = options.Protocol.ToString().ToLower(),
                Host = options.Host,
                Port = options.Port
            };
            Debug.Log(uriBuilder.Uri);
            _httpClient = new HttpClient
            {
                BaseAddress = uriBuilder.Uri,
                Timeout = options.HttpTimeout
            };

            foreach (var header in options.HttpHeaders)
            {
                _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }

        public async Task SendMessageAsync(GELFMessage message)
        {
            var json = message.ToJson();
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsync("gelf", content);
            result.EnsureSuccessStatusCode();
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
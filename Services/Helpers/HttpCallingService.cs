using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace DMBackend.Infrastructure.Services.Helpers
{
    public class HttpCallingService
    {
        public T Get<T>(string url, Dictionary<string, string> requestHeaders)
        {
            return SendRequest<T>(HttpMethod.Get, url, requestHeaders ?? new Dictionary<string, string>());
        }

        public T Post<T>(string url, Dictionary<string, string> requestHeaders, HttpContent content)
        {
            return SendRequest<T>(HttpMethod.Post, url, requestHeaders ?? new Dictionary<string, string>(), content);
        }

        public T SendRequest<T>(HttpMethod method, string url,
            Dictionary<string, string> requestHeaders, HttpContent content = null)
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler()
                {
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                };

                using (HttpClient client = new HttpClient(handler))
                {
                   
                    using (HttpRequestMessage request = new HttpRequestMessage())
                    {
             
                        request.Method = method;
                        request.RequestUri = new Uri(url);
                        foreach (var requestHeader in requestHeaders)
                        {
                            request.Headers.Add(requestHeader.Key, requestHeader.Value);
                        }
                        if (content != null)
                            request.Content = content;

                        var response = client.SendAsync(request).Result;
                        var responseString = response.Content.ReadAsStringAsync().Result;
						Console.Write(responseString);
                        if (typeof(T) == typeof(string))
                        {
                            return (T)Convert.ChangeType(responseString, typeof(T));
                        }
                        else
                        {
                            T deserializedProduct = JsonConvert.DeserializeObject<T>(responseString);
                            return deserializedProduct;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
        public List<T> ReadJson<T>(JsonReader reader, Type objectType, JsonSerializer serializer)
        {
            List<T> list = new List<T>();
            JArray array = JArray.Load(reader);
            foreach (JObject obj in array.Children<JObject>())
            {
                if (obj.HasValues)
                {
                    list.Add(obj.ToObject<T>(serializer));
                }
            }
            return list;
        }
        public string Base64Encode(string plainText)
        {
            if (plainText == null)
                return null;
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public string Base64Decode(string base64EncodedData)
        {
            if (base64EncodedData == null)
                return null;
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}

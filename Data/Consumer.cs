using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Tarea_asp.Data.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace Tarea_asp.Data
{
    public class Consumer
    {
        private static HttpMethod CreateHttpMethod(MethodHttp method)
        {
            switch (method)
            {
                case MethodHttp.GET:
                    return HttpMethod.Get; // Traer información, 
                case MethodHttp.POST:
                    return HttpMethod.Post;
                case MethodHttp.PUT:
                    return HttpMethod.Put;
                case MethodHttp.DELETE:
                    return HttpMethod.Delete;
                default:
                    throw new NotImplementedException("Not implemented http method");
            }
        }

        public static async Task<Response<T>> Execute<T>(string url, MethodHttp method, T objectRequest)
        {
            Response<T> response = new Response<T>();
            try
            {

                using (HttpClient client = new HttpClient())
                {

                    var myContent = JsonConvert.SerializeObject((method != MethodHttp.GET) ? method != MethodHttp.DELETE ? objectRequest : "" : "");
                    var bytecontent = new ByteArrayContent(Encoding.UTF8.GetBytes(myContent));
                    bytecontent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    //Si es get o delete no le mandamos content
                    var request = new HttpRequestMessage(CreateHttpMethod(method), url)
                    {
                        Content = (method != MethodHttp.GET) ? method != MethodHttp.DELETE ? bytecontent : null : null
                    };

                    using (HttpResponseMessage res = await client.SendAsync(request))
                    {
                        using (HttpContent content = res.Content)
                        {
                            string data = await content.ReadAsStringAsync();
                            if (data != null)
                                response.Data = JsonConvert.DeserializeObject<T>(data);

                            response.StatusCode = res.StatusCode.ToString();
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                response.StatusCode = "ServerError";
                var res = (HttpWebResponse)ex.Response;
                if (res != null)
                    response.StatusCode = response.StatusCode.ToString();
            }
            catch (Exception ex)
            {
                response.StatusCode = "AppError";
                response.Message = ex.Message;
            }
            return response;

        }
    }
}
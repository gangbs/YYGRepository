using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using YYG.Framework.Extension;

namespace YYG.Framework.Net
{
    public class HttpHelper
    {
        public HttpHelper()
        {
        }

        private HttpClient InitHttp()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//返回json,可以不写这一段，因为默认就是返回json
            httpClient.DefaultRequestHeaders.Add("KeepAlive", "false");   // HTTP KeepAlive设为false，防止HTTP连接保持
            httpClient.DefaultRequestHeaders.Add("UserAgent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.11 (KHTML, like Gecko) Chrome/23.0.1271.95 Safari/537.11");
            return httpClient;
        }


        #region//异步方法

        //public async Task<T> Get<T>(string url)
        //{
        //    using (var client = new HttpClient())
        //    {

        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//返回json,可以不写这一段，因为默认就是返回json               
        //        string response = await client.GetStringAsync(url);//.ConfigureAwait(false);
        //        return JsonHelper.Parse<T>(response);
        //    }
        //}

        public static async Task<T> Get2<T>(string url)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//返回json,可以不写这一段，因为默认就是返回json
                HttpResponseMessage response = await client.GetAsync(url);
                T rtn = await response.Content.ReadAsAsync<T>();
                return rtn;
            }
        }

        public static async Task<TReturn> Post<TParams, TReturn>(string url, TParams p)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//返回json,可以不写这一段，因为默认就是返回json
                HttpContent content = new ObjectContent<TParams>(p, new JsonMediaTypeFormatter());
                //ConfigureAwait可避免在调用时发生死锁，其作用是，使当前async方法的await后续操作不需要恢复到主线程（不需要保存线程上下文）
                HttpResponseMessage response = await client.PostAsync(url, content);//.ConfigureAwait(false);
                TReturn rtn = await response.Content.ReadAsAsync<TReturn>();
                return rtn;
            }
        }

        public static async Task PutRequestAsync<T>(string baseAddres, string requestUri, T p)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddres);
                await client.PutAsJsonAsync(requestUri, p);//该方法自动格式化内容
            }
        }

        public static async Task DeleteRequestAsync(string baseAddres, string requestUri)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddres);
                HttpResponseMessage response = await client.DeleteAsync(requestUri);//需对System.Net.Http.Formatting程序集添加引用
            }
        }

        #endregion


        public async Task<HttpResponseResult> Post<T>(string url, T data)
        {
            HttpResponseResult result = null;
            if (data == null)
            {
                result = null;
            }

            try
            {
                using (var http = this.InitHttp())
                {
                    string json = data.ToJson<T>();
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await http.PostAsync(url, content);
                    result = response.ConvertToResult();
                    response.EnsureSuccessStatusCode();//保证请求成功，失败的话报错
                    result = await response.Content.ReadAsStringAsync().ContinueWith(m => new HttpResponseResult(m.Result, HttpStatusCode.OK));
                }
            }
            catch (HttpRequestException ex)
            {
                result = new HttpResponseResult(ex.Message, HttpStatusCode.InternalServerError);
            }

            return result;
        }

        public async Task<HttpResponseResult> Get(string url)
        {
            HttpResponseResult result = null;
            try
            {
                using (var http = this.InitHttp())
                {
                    var response = await http.GetAsync(url);
                    response.EnsureSuccessStatusCode();//保证请求成功，失败的话报错
                    result = await response.Content.ReadAsStringAsync().ContinueWith(m => new HttpResponseResult(m.Result, HttpStatusCode.OK));
                }
            }
            catch (HttpRequestException ex)
            {
                result = new HttpResponseResult(ex.Message, HttpStatusCode.InternalServerError);
            }
            return result;
        }

        public async Task<TReturn> Post<TReturn, TData>(string url, TData data)
        {
            TReturn result;
            using (var httpClient = this.InitHttp())
            {
                HttpContent content = new ObjectContent<TData>(data, new JsonMediaTypeFormatter());
                var response = await httpClient.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsAsync<TReturn>();
                }
                else
                {
                    result = default(TReturn);
                }
            }
            return result;
        }


        public async Task<T> Get<T>(string url)
        {
            T result;
            using (var http = this.InitHttp())
            {
                var response = await http.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsAsync<T>();
                }
                else
                {
                    result = default(T);
                }
            }
            return result;
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace BeckMan.WebAPI.Controllers
{
    public class FileController : ApiController
    {
        private static readonly long MEMORY_SIZE = 64 * 1024 * 1024;

        [HttpGet]
        public async Task<HttpResponseMessage> Get(string id)
        {
            string fileName = "sample.txt";
            string filePath = "C:\\sample.txt";
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            FileStream stream = new FileStream(filePath, FileMode.Open);
            ContentDispositionHeaderValue disp = new ContentDispositionHeaderValue("inline");
            disp.FileName = HttpUtility.UrlEncode(fileName);
            disp.Name = HttpUtility.UrlEncode(fileName);
            disp.Size = stream.Length;
            if (stream.Length < MEMORY_SIZE)
            {
                byte[] bytes = new byte[stream.Length];
                await stream.ReadAsync(bytes, 0, (int)stream.Length);
                stream.Close();
                MemoryStream ms = new MemoryStream(bytes);
                result.Content = new ByteArrayContent(ms.ToArray());
            }
            else
            {
                result.Content = new StreamContent(stream);
            }

            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            result.Content.Headers.ContentDisposition = disp;
            result.Content.Headers.Expires = new DateTimeOffset(DateTime.Now).AddHours(1);
            return result;
        }


        [HttpPost]
        public async Task<Dictionary<string, string>> Post(int id = 0)
        {
            if (id == 1)
            {
                return await Method1();
            }else
            {
                return await Method2();
            }
           
        }

        private async Task<Dictionary<string, string>> Method2()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string root = "c:\\";//指定要将文件存入的服务器物理位置  
            var provider = new MultipartMemoryStreamProvider();
            try
            { 
                await Request.Content.ReadAsMultipartAsync(provider);

                foreach (var item in provider.Contents)
                {
                    if (item.Headers.ContentDisposition.FileName != null)
                    {
                        var filename = item.Headers.ContentDisposition.FileName.Replace("\"", "");
                        var newFileName = Path.Combine(root, filename);
                        var ms = item.ReadAsStreamAsync().Result;
                        using (var br = new BinaryReader(ms))
                        {
                            var data = br.ReadBytes((int)ms.Length);
                            File.WriteAllBytes(newFileName, data);
                        }
                        dic.Add(filename, newFileName);
                    }
                    else
                    {
                        var key = item.Headers.ContentDisposition.Name.Replace("\"", "");
                        var value = item.ReadAsStringAsync().Result;
                        dic.Add(key, value);
                    }
                }
            }
            catch
            {
                throw;
            }
            return dic;
        }


        private async Task<Dictionary<string, string>> Method1()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string root = "c:\\";//指定要将文件存入的服务器物理位置  
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);
 
                foreach (MultipartFileData file in provider.FileData)
                {  
                    string fileName = file.Headers.ContentDisposition.FileName;
                    string localFileName = file.LocalFileName;
                    dic.Add(fileName, localFileName);
                }
                foreach (var key in provider.FormData.AllKeys)
                {
                    dic.Add(key, provider.FormData[key]);
                }
            }
            catch
            {
                throw;
            }
            return dic;
        }
    }
}

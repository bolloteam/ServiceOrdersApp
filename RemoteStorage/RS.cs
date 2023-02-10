using DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RemoteStorage
{
    public static class RS
    {
        public static bool SendData(List<Order> list)
        {
            string json = PrepareJson(list);
            if (json != string.Empty)
            {
                if(SendData(json))
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        public static string PrepareJson(List<Order> list)
        {
            try
            {
                var query = from item in list
                            select new { id = item.id, cliente = item.CustomerName, fecha = item.CreatedAt, descripcion = item.Description, estado = item.StatusEnum.ToString() };
                return JsonConvert.SerializeObject(query);
            }catch(Exception ex)
            {
                return string.Empty;
            }
        }

        public static bool SendData(string json)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://e3z5k.mocklab.io/json");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                dynamic dynamicObject = JsonConvert.DeserializeObject<ExpandoObject>(result);
                if (dynamicObject.resultado == "OK")
                    return true;
                else
                    return false;
            }
        }
        
    }
}

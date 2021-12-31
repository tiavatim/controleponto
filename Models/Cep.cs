using Nancy.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace ControlePonto.Models
{
    public class Cep
    {
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string UF { get; set; }
        public string DDD { get; set; }

        public static Cep BuscarCEP(string cep)
        {
            var cepObj = new Cep();
            var url = "https://viacep.com.br/ws/" + cep + "/json/";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            string json = string.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader streamReader = new StreamReader(stream))
            {
                json = streamReader.ReadToEnd();
            }

            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            JsonCepObject cepJson = json_serializer.Deserialize<JsonCepObject>(json);

            cepObj.CEP = cepJson.cep;
            cepObj.Logradouro = cepJson.logradouro;
            cepObj.Bairro = cepJson.bairro;
            cepObj.Localidade = cepJson.localidade;
            cepObj.UF = cepJson.uf;
            cepObj.DDD = cepJson.ddd;

            return cepObj;

        }

        public class JsonCepObject
        {
            public string cep { get; set; }
            public string logradouro { get; set; }
            public string bairro { get; set; }
            public string localidade { get; set; }
            public string uf { get; set; }
            public string ddd { get; set; }
        }


    }
}

using Solucoes.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Api.Service
{
    public static class Helpers
    {
        public static string ConverterObjectJson(Object objeto)
        {
            var ms = new MemoryStream();

            var ser = new DataContractJsonSerializer(typeof(Object));
            ser.WriteObject(ms, objeto);
            byte[] json = ms.ToArray();
            ms.Close();
            string retorno = Encoding.UTF8.GetString(json, 0, json.Length);

            return retorno;

        }
        public static Object ConverterJsonObject<T>(string json)
        {
            var deserialized = new Object();
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            var ser = new DataContractJsonSerializer(deserialized.GetType());
            deserialized = ser.ReadObject(ms) as Object;
            ms.Close();

            return deserialized;

        }

    }
}

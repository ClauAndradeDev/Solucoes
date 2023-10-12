using System.Text.Json;

namespace Solucoes.Api.Service
{
    public static class Helpers
    {
        public static string ConverterObjectJson(Object objeto)
        {


            string jsonString = JsonSerializer.Serialize(objeto);

            //var ms = new MemoryStream();

            //var ser = new DataContractJsonSerializer(typeof(Object));
            //ser.WriteObject(ms, objeto);
            //byte[] json = ms.ToArray();
            //ms.Close();
            //string retorno = Encoding.UTF8.GetString(json, 0, json.Length);

            return jsonString;

        }
        public static Object ConverterJsonObject<T>(string json)
        {
            string jsonString = File.ReadAllText(json);
            Object objeto = JsonSerializer.Deserialize<Object>(jsonString)!;

            return objeto;

            //var deserialized = new Object();
            //var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            //var ser = new DataContractJsonSerializer(deserialized.GetType());
            //deserialized = ser.ReadObject(ms) as Object;
            //ms.Close();

            //return deserialized;

        }

    }
}

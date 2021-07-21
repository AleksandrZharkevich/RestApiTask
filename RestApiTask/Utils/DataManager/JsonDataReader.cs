using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace KasperskyTask.Utils.DataManager
{
    class JsonDataReader : IDataReader
    {
        private readonly string _json;

        public JsonDataReader(string pathToFile) => _json = File.ReadAllText(pathToFile);

        public T ReadProperty<T>(string key) => JObject.Parse(_json)[key].ToObject<T>();

        public T ReadObject<T>() => JsonConvert.DeserializeObject<T>(_json);
    }
}

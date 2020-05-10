using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace TestWebApi
{
    public class JsonCreationConverter<T> : JsonConverter where T : Person
    {
        public override bool CanWrite
        {
            get
            {
                return false;
            }
        }

        private Person Create(Type objectType, JObject jObject)
        {
            if (jObject == null) throw new ArgumentNullException("jObject");

            if (jObject["schoolName"] != null)
            {
                return new Student();
            }
            else if (jObject["hospitalName"] != null)
            {
                return new Doctor();
            }
            else
            {
                return new Person();
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader == null) throw new ArgumentNullException("reader");
            if (serializer == null) throw new ArgumentNullException("serializer");
            if (reader.TokenType == JsonToken.Null)
                return null;

            JObject jObject = JObject.Load(reader);
            Person target = Create(objectType, jObject);
            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}

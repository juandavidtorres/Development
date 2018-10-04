//Development by Kelmer Ashley Comas Cardona © 2017

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;


namespace JSONSerializer
{
    public abstract class JSON 
    {   

        public static string Serialize<T>(T obj)
        {
            byte[] json = new byte[0];

            using (MemoryStream ms = new MemoryStream())
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));
                jsonSerializer.WriteObject(ms, obj);
                json = ms.ToArray();
            }

            return Encoding.UTF8.GetString(json, 0, json.Length);
        }
  
        public static T Deserialize<T>(string json)
        {
            T deserializedUser = default(T);

            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                deserializedUser = (T)Activator.CreateInstance(typeof(T));
                DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedUser.GetType());
                deserializedUser = (T)ser.ReadObject(ms);
            }

            return deserializedUser;
        }

        public static bool IsDeserializable<T>(string json)
        {
            bool isDeserializable = true;

            try
            {
                using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
                {
                    T deserializedUser = (T)Activator.CreateInstance(typeof(T));
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedUser.GetType());
                    deserializedUser = (T)ser.ReadObject(ms);
                }
            }
            catch { isDeserializable = false; }

            return isDeserializable;            
        }

    }
}

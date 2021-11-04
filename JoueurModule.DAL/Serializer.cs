using System;
using System.Collections.Generic;

namespace JoueurModule.DAL
{
    public class Serializer<T>
    {
        private object Json;
        private string Path;

        public Serializer(object Json, string Path)
        {
            this.Json = Json;
            this.Path = Path;
        }

        public void Serialize(List<T> datas)
        {
            throw new NotImplementedException();
        }

        public List<T> Deserialize()
        {
            throw new NotImplementedException();
        }
    }

//    public static string JSON_MODE = "JSON";
}
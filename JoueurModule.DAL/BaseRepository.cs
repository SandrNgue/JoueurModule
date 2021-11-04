using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JoueurModule.DAL
{
    public class BaseRepository<T>
    {
        protected List<T> datas;
        private readonly string PATH = $"Data/{typeof(T).Name}.json";
        private Serializer<T> serializer;
        public BaseRepository()
        {
            datas = new List<T>();
            FileInfo fi = new FileInfo(PATH);

            if (!fi.Directory.Exists)
                fi.Directory.Create();

            //            serializer = new Serializer<T>(SerializerMode.JSON_MODE, PATH);
            serializer = new Serializer<T>("JSON", PATH);
            Restore();
        }

        public int Check(T Obj)
        {
            var index = -1;
            for (int i = 0; i < datas.Count; i++)
            {
                if (Obj.Equals(datas[i]))
                    index = i;
            }
            return index;
        }

        public void Add(T obj)
        {
            int index = Check(obj);
            if (index != -1)
                throw new DuplicateWaitObjectException($"{typeof(T).Name} already exists !");

            datas.Add(obj);
            Save();
        }

        public void Set(T oldObj, T newObj)
        {
            int oldIndex = Check(oldObj);
            if (oldIndex < 0)
                throw new KeyNotFoundException($"{typeof(T).Name} not found !");

            var newIndex = Check(newObj);

            if (newIndex >= 0 && newIndex != oldIndex)
                throw new KeyNotFoundException($"{typeof(T).Name} already exists !");

            datas[oldIndex] = newObj;
        }

        public void Delete(T obj)
        {
            var index = Check(obj);
            if (index < 0)
                throw new KeyNotFoundException($"{typeof(T).Name} not found !");

            if (index >= 0)
                datas.RemoveAt(index);
            Save();
        }

        public void Save()
        {
            serializer.Serialize(datas);
        }
        public void Restore()
        {
            FileInfo fi = new FileInfo(PATH);
            if (fi.Exists && fi.Length > 0)
                datas = serializer.Deserialize();
        }

        public List<T> GetAll()
        {
            Restore();
            T[] items = new T[datas.Count];
            datas.CopyTo(items);
            return items.ToList<T>();
        }

        public T FindByIndex(int index)
        {
            if (index < 0 || index >= datas.Count)
                throw new KeyNotFoundException($"{typeof(T).Name} with index not found !");

            return datas[index];
        }

        public T Find(Predicate<T> predicate)
        {
            return datas.Find(predicate);
        }

        public List<T> FindAll(Predicate<T> predicate)
        {
            return datas.FindAll(predicate);
        }
    }
}
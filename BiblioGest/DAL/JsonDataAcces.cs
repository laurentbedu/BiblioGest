using Newtonsoft.Json;

namespace BiblioGest.DAL
{
    internal class JsonDataAcces<T> where T : Models.ModelBase<T>
    {
        private List<T> dataList;
        private List<T> DataList
        {
            get
            {
                if (dataList == null)
                {
                    dataList = LoadJsonData();
                }
                return dataList;
            }
        }
        private List<T> LoadJsonData()
        {
            string className = typeof(T).Name.ToLower();
            using (StreamReader reader = new StreamReader($"JsonData/{className}.json"))
            {
                string jsonString = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<T>>(jsonString);
            }
        }
        private void SaveJsonData()
        {
            string className = typeof(T).Name.ToLower();
            using (StreamWriter writer = new StreamWriter($"JsonData/{className}.json"))
            {
                string jsonString = JsonConvert.SerializeObject(DataList);
                writer.Write(jsonString);
            }
        }

        public List<T> GetAll(Predicate<T> filter = null)
        {
            List<T> list = DataList.FindAll(item => !item.Deleted);
            return filter != null ? list.FindAll(filter) : list;
        }

        public T? GetById(int id)
        {
            return id > 0 ? GetAll(item => item.Id == id).First() : null;
        }

        public List<T> GetDeleted(Predicate<T> filter = null)
        {
            List<T> list = DataList.FindAll(item => item.Deleted);
            return filter != null ? list.FindAll(filter) : list;
        }

        public void Persist(T instance)
        {
            if (DataList.Find(item => item.Id == instance.Id) == null)
            {
                if (instance.Id == 0)
                {
                    int nextId = DataList.MaxBy(x => x.Id).Id;
                    instance.Id = nextId;
                }
                DataList.Add((T)instance);
            }
            SaveJsonData();
        }

        public void Delete(T instance)
        {
            if (DataList.Find(item => item.Id == instance.Id) != null)
            {
                DataList.Remove((T)instance);
            }
            SaveJsonData();
        }


    }
}

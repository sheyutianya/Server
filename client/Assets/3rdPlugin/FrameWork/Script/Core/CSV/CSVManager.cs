using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Core.CSV
{
    public class CSVManager
    {
        static private CSVManager _instance;
        static public CSVManager GetInstance()
        {
            if (null == _instance)
            {
                _instance = new CSVManager();
            }
            return _instance;
        }


        Hashtable dict;

        public CSVManager()
        {
            dict = new Hashtable();
        }

        public void Register<T>(string csvText) where T : new()
        {
            dict.Add(typeof(T), CSVParser<T>.Parse(csvText));
        }

        public Dictionary<object, T> GetCsv<T>()
        {
			return (Dictionary<object, T>)dict[typeof(T)];
        }

        public T GetData<T>(int itemId)
        {
            return GetCsv<T>()[itemId];
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newPos.Models
{
    public class SessionManager
    {
        private SessionManager()
        {
        }


        public static T Get<T>(HttpSessionStateBase session) where T : class, new()
        {
            var item = session[typeof(T).Name] as T ?? new T();
            return item;
        }
        public static void Set<T>(HttpSessionStateBase session, T item)
        {
            session[typeof(T).Name] = item;
        }
        public static void Clear<T>(HttpSessionStateBase session)
        {
            session[typeof(T).Name] = null;
        }


        public static void AddItemToList<T>(HttpSessionStateBase session, T data)
        {
            var list = GetList<T>(session);
            list.Add(data);
            session[typeof(T).Name + "List"] = list;
        }
        public static void RemoveItemFromList<T>(HttpSessionStateBase session, int index)
        {
            var list = GetList<T>(session);
            try
            {
                if (list.Count > 0)
                {
                    list.RemoveAt(index);
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("ArgumentOutOfRangeException @ SessionManager:" + e.Message);
            }
        }
        public static void ReplaceItemInList<T>(HttpSessionStateBase session, int index, T data)
        {
            RemoveItemFromList<T>(session, index);
            var list = GetList<T>(session);
            list.Insert(index, data);
            session[typeof(T).Name + "List"] = list;
        }
        /// <summary>
        /// ดึงข้อมูล List ใน Session โดย session[typeof(T).Name + "List"]
        /// </summary>
        /// <typeparam name="T">Data Type</typeparam>
        /// <param name="session">ตัวแปล Session เป็น Property ของ Controller</param>
        public static List<T> GetList<T>(HttpSessionStateBase session)
        {
            var list = session[typeof(T).Name + "List"] as List<T> ?? new List<T>();
            return list;
        }
        public static void SetList<T>(HttpSessionStateBase session, List<T> list)
        {
            session[typeof(T).Name + "List"] = list;
        }
        public static void ClearList<T>(HttpSessionStateBase session)
        {
            session[typeof(T).Name + "List"] = null;
        }
    }

}
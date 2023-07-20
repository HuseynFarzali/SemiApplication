using SemiApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemiApplication.Database_Models
{
    public class Database<TElement> : IDatabase<TElement> where TElement : BaseEntity
    {
        Dictionary<int, TElement> database;

        public Database()
        {
            database = new Dictionary<int, TElement>();
        }

        public void Add(TElement element)
        {
            database.Add(element.Id, element);
        }

        public List<KeyValuePair<int, TElement>> FindByCriteria(Predicate<TElement> criteria)
        {
            var filteredPairs = from pair in database
                                where criteria(pair.Value)
                                select pair;

            return filteredPairs.ToList();
        }

        public List<KeyValuePair<int, TElement>> GetContent()
        {
            return database.ToList();
        }

        public bool Remove(int id)
        {
            bool success = database.Remove(id);
            return success;
        }

        public bool Update(int id, TElement element)
        {
            var filteredPair = from pair in database
                                where pair.Key == id
                                select pair;

            if (filteredPair.Count() > 1) return false;

            int key = filteredPair.ToList()[0].Key;

            database.Remove(key);
            database.Add(key, element);
            
            return true;
        }
    }
}

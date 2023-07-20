using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemiApplication.Database_Models
{
    public interface IDatabase <TElement>
    {
        public List<KeyValuePair<int, TElement>> GetContent();
        public void Add(TElement element);
        public bool Remove(int id);
        public bool Update(int id, TElement element);
        public List<KeyValuePair<int, TElement>> FindByCriteria(Predicate<TElement> criteria);
    }
}

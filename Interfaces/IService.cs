using System.Collections.Generic;

namespace shoeshoe.Interfaces
{
    public interface IService<T>
    {
        public IEnumerable<T> Get();
        public T GetById(int id);
        public T Create(T newData);
        public T Edit(T update, int id);
        public string Delete(int id);

    }
}
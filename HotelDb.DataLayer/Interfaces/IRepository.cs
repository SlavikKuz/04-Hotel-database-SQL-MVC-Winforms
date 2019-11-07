using System.Collections.Generic;
using HotelDb.DataLayer.Entities;

namespace HotelDb.DataLayer.Interfaces
{
    public interface IRepository<T> where T:class
    {
        void Create(T item);
        IEnumerable<T> ReadAll();
        T Read(int id);
        void Update(T item);
        void Delete(int id);
    }
}

using MyShop.Core.Models;
using System.Linq;

namespace MyShop.Core.Intefaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Collection();
        void Commit();
        void Delete(string ID);
        T Find(string ID);
        void Insert(T item);
        void Update(T item);
    }
}
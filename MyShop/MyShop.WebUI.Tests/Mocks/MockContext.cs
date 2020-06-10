using MyShop.Core.Intefaces;
using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.WebUI.Tests.Mocks
{
    public class MockContext<T> : IRepository<T> where T:BaseEntity
    {
        List<T> items;
        string className;

        public MockContext()
        {
            items = new List<T>();
            this.className = typeof(T).Name;
        }
        public void Commit()
        {
            return;
        }
        public void Insert(T item)
        {
            items.Add(item);
        }
        public void Update(T item)
        {
            T itemToUpdate = items.Find(i => i.Id == item.Id);
            if (itemToUpdate != null) itemToUpdate = item;
            else throw new Exception(className + "not found");
        }
        public T Find(string ID)
        {
            T itemtToFind = items.Find(i => i.Id == ID);
            if (itemtToFind != null) return itemtToFind;
            else throw new Exception(className + "not found");
        }
        public IQueryable<T> Collection()
        {
            return items.AsQueryable();
        }
        public void Delete(string ID)
        {
            T itemToDelete = items.Find(i => i.Id == ID);
            if (itemToDelete != null) items.Remove(itemToDelete);
            else throw new Exception(className + "not found");
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using MyShop.Core.Intefaces;
using MyShop.Core.Models;

namespace MyShop.DataAccess.InMemory
{
    public class InMemoryRepository<T> : IRepository<T> where T : BaseEntity
    {
        ObjectCache cache = MemoryCache.Default;
        List<T> items;
        string className;

        public InMemoryRepository()
        {
            this.className = typeof(T).Name;
            items = cache[className] as List<T>;
            if (items == null) items = new List<T>();
        }
        public void Commit()
        {
            cache[className] = items;
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

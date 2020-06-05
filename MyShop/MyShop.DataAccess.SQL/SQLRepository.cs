using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Core.Models;
using MyShop.Core.Intefaces;
using System.Data.Entity;

namespace MyShop.DataAccess.SQL
{
    public class SQLRepository<T> : IRepository<T> where T : BaseEntity
    {
        internal DataContext context;
        internal DbSet<T> dbSet;
        string className;
        public SQLRepository(DataContext context) {
            this.context = context;
            this.dbSet = context.Set<T>(); ;
            this.className = typeof(T).Name;
        }
        public void Commit(){
            context.SaveChanges();
        }
        public void Insert(T item){
            dbSet.Add(item);
        }
        public IQueryable<T> Collection(){
            return dbSet;
        }
        public void Delete(string ID){
            if (Find(ID) != null){
                var item = Find(ID);
                if (context.Entry(item).State == EntityState.Detached) dbSet.Attach(item);
                dbSet.Remove(item);
            }
            else throw new Exception(className + "not found");
        }
        public T Find(string ID){
            if (dbSet.Find(ID) != null) return dbSet.Find(ID);
            else throw new Exception(className + "not found");
        }
        public void Update(T item)
        {
            if (dbSet.Attach(item) != null) context.Entry(item).State = EntityState.Modified;
            else throw new Exception(className + "not found");
        }
    }
}

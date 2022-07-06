using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public abstract class CoreDataContext : DbContext, IContext
    {
        public CoreDataContext(DbContextOptions options) : base(options)
        {

        }

        public IQueryable<T> AsQueryable<T>() where T : class, IEntity
            => Set<T>().AsQueryable();

        public void Insert<T>(T item) where T : class, IEntity
        {
            SetContextEntry(item);
            SaveChanges();
        }

        public void Insert<T>(IEnumerable<T> items) where T : class, IEntity
        {
            foreach (var item in items)
            {
                SetContextEntry(item);
            }
            SaveChanges();
        }

        public void Update<T>(T item) where T : class, IEntity
        {
            SetContextEntry(item, EntityState.Modified);
            SaveChanges();
        }

        public void Update<T>(IEnumerable<T> items) where T : class, IEntity
        {
            foreach (var item in items)
            {
                SetContextEntry(item, EntityState.Modified);
            }
            SaveChanges();
        }

        public void Delete<T>(T item) where T : class, IEntity
        {
            var set = Set<T>();
            var entity = item as T;
            set.Attach(entity);
            set.Remove(entity);
            SaveChanges();
        }

        public void Delete<T>(IEnumerable<T> items) where T : class, IEntity
        {
            var set = Set<T>();
            foreach (var item in items)
            {
                var entity = item as T;
                set.Attach(entity);
                set.Remove(entity);
            }
            SaveChanges();
        }

        private void SetContextEntry<T>(T item, EntityState state = EntityState.Added) where T : class, IEntity
        {
            var entry = Entry(item);

            if (state == EntityState.Added)
            {
                Set<T>().Add(item);
                entry.State = state;
            }

            if (entry.State == EntityState.Detached)
            {
                Set<T>().Attach(item);
                entry.State = state;
            }
        }
    }
}

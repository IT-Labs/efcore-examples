using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public interface IContext : IDisposable
    {
        IQueryable<T> AsQueryable<T>() where T : class, IEntity;
        void Insert<T>(T item) where T : class, IEntity;
        void Insert<T>(IEnumerable<T> items) where T : class, IEntity;
        void Update<T>(T item) where T : class, IEntity;
        void Update<T>(IEnumerable<T> items) where T : class, IEntity;
        void Delete<T>(T item) where T : class, IEntity;
        void Delete<T>(IEnumerable<T> items) where T : class, IEntity;
    }
}

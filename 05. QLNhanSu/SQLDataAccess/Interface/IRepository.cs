using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDataAccess.Interface
{
    public interface IRepository<T> where T : class
    {
        T FindById(object id);
        void InsertGraph(T entity);
        void Update(T entity);
        void Delete(object id);
        void Delete(T entity);
        void Insert(T entity);
        RepositoryQuery<T> Query();
    }
}

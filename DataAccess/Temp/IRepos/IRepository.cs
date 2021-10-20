using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Temp.IRepos
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        void Add(T category);
        void Delete(int id);
        T Find(int id);
        void Update(T category);
        void Save();
        IQueryable<T> GetQuery();
    }
}

using DataAccess.Models;
using DataAccess.Temp.IRepos;
using System;
using System.Data.Entity;
using System.Linq;

namespace DataAccess.Temp.Repositories
{
    public class TransctionsRepository : IRepository<TransactionsHistory>
    {
        private ApplicationContext context;

        public TransctionsRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public void Add(TransactionsHistory transactionsHistory)
        {
            context.TransactionsHistories.Add(transactionsHistory);
        }

        public void Delete(int id)
        {
            var tHistory = context.TransactionsHistories.Find(id);
            context.TransactionsHistories.Remove(tHistory);
        }

        public TransactionsHistory Find(int id)
        {
            return context.TransactionsHistories.Find(id);
        }

        public IQueryable<TransactionsHistory> GetQuery()
        {
            return context.TransactionsHistories;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(TransactionsHistory transactionsHistory)
        {
            context.Entry(transactionsHistory).State = EntityState.Modified;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

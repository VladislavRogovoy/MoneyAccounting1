using DataAccess.Models;
using DataAccess.Temp.IRepos;
using System;
using System.Data.Entity;
using System.Linq;

namespace DataAccess.Temp.Repositories
{
    public class TransctionsRepository : IRepository<Transaction>
    {
        private ApplicationContext context;

        public TransctionsRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public void Add(Transaction transactionsHistory)
        {
            context.Transactions.Add(transactionsHistory);
        }

        public void Delete(int id)
        {
            var tHistory = context.Transactions.Find(id);
            context.Transactions.Remove(tHistory);
        }

        public Transaction Find(int id)
        {
            return context.Transactions.Find(id);
        }

        public IQueryable<Transaction> GetQuery()
        {
            return context.Transactions;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Transaction transactionsHistory)
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

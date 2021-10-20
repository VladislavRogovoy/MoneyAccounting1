using DataAccess.Models;
using DataAccess.Temp.IRepos;
using System;
using System.Data.Entity;
using System.Linq;

namespace DataAccess.Temp.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private ApplicationContext context;

        public CategoryRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public void Add(Category category)
        {
            context.Categories.Add(category);
        }

        public void Delete(int id)
        {
            var category = context.Categories.Find(id);
            context.Categories.Remove(category);
        }

        public Category Find(int id)
        {
            return context.Categories.Find(id);
        }

        public void Update(Category category)
        {
            context.Entry(category).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public IQueryable<Category> GetQuery()
        {
            return context.Categories;
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

using System.Collections.Generic;
using System.Threading.Tasks;
using PruebaApiREST.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace PruebaApiREST.Models
{
    public class Repository<TodoContext> : IRepository where TodoContext : DbContext
    {
        protected TodoContext dbContext;

        public Repository(TodoContext context)
        {
            dbContext = context;
        }

        public async Task CreateAsync<T>(T entity) where T : class
        {
            this.dbContext.Set<T>().Add(entity);

            _ = await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync<T>(T entity) where T : class
        {
            this.dbContext.Set<T>().Remove(entity);
            _ = await this.dbContext.SaveChangesAsync();
        }

       public async Task<List<T>> SelectAll<T>() where T : class
        {
            return await this.dbContext.Set<T>().ToListAsync();
        }


        public async Task<T> SelectById<T>(int id) where T : class
        {
            return await this.dbContext.Set<T>().FindAsync(id) ;
        }

        public async Task UpdateAsync<T>(T entity) where T : class
        {
            this.dbContext.Set<T>().Update(entity);
            _ = await this.dbContext.SaveChangesAsync();
        }
    }
}   
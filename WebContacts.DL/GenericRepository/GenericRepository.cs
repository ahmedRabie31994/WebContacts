using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebContacts.DL.Context;

namespace WebContacts.DL.GenericRepository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task AddAsync(T Item)
        {
            await _context.AddAsync(Item);
        }

        public virtual void Insert(T Item)
        {
            _context.Add(Item);
        }

        public void AddWithoutSync(T Item)
        {
            _context.Add(Item);
            _context.SaveChanges();
        }

        public virtual async Task AddAll(IEnumerable<T> Items)
        {
            _context.AddRange(Items);
            await _context.SaveChangesAsync();
        }

        public virtual void InsertAll(IEnumerable<T> Items)
        {
            _context.AddRange(Items);
        }

        public virtual async Task Delete(int Id)
        {
            _context.Remove(await GetByID(Id));
        }

        public virtual async Task DeleteWithoutSave(int Id)
        {
            _context.Remove(await GetByID(Id));
        }

        /// <summary>
        /// Delete object TEntity by Object TEntity Passed
        /// </summary>
        /// <param name="entityToDelete"></param>
        public virtual void Delete(T entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _context.Set<T>().Attach(entityToDelete);
            }
            _context.Set<T>().Remove(entityToDelete);
        }



        public virtual IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsNoTracking().Where(predicate);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public virtual async Task<T> GetByID(int Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

        public virtual async Task Save(T Item)
        {
            await _context.SaveChangesAsync();
        }
        public virtual void Update(T Item)
        {
            _context.Update(Item);

        }

        public virtual async Task SaveAll(IEnumerable<T> Items)
        {
            _context.UpdateRange(Items);
            await _context.SaveChangesAsync();
        }
        public virtual void UpdateAll(IEnumerable<T> Items)
        {
            _context.UpdateRange(Items);
        }

        public virtual async Task<int> SaveTransaction()
        {
            return await _context.SaveChangesAsync();
        }

        public void UpdateAccount(T Item)
        {
            _context.Update(Item);
            _context.SaveChanges();
        }

        public async Task<System.Data.DataTable> RawSqlQuery(string query)
        {
            using (var context = new ApplicationDbContext())
            {
                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = System.Data.CommandType.Text;

                    await context.Database.OpenConnectionAsync();

                    var dt = new System.Data.DataTable();
                    dt.Load(await command.ExecuteReaderAsync());

                    return dt;
                }
            }
        }

        public string ArabicRegex(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.Trim();
                keyword = keyword.ToLower();
                keyword = keyword.Replace('أ', 'ا');
                keyword = keyword.Replace('إ', 'ا');
                keyword = keyword.Replace('آ', 'ا');
                keyword = keyword.Replace('ى', 'ي');
                keyword = keyword.Replace('ة', 'ه');
            }
            else { keyword = string.Empty; }
            return keyword;
        }


    }
}

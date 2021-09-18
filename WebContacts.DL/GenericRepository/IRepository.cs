using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebContacts.DL.GenericRepository
{
    public interface IRepository<T> where T : class
    {

        IQueryable<T> GetAll();
        Task<T> GetByID(int Id);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        Task Save(T Item);
        Task AddAsync(T Item);
        Task SaveAll(IEnumerable<T> Items);
        Task AddAll(IEnumerable<T> Items);
        Task Delete(int PrimaryKey);
        Task DeleteWithoutSave(int PrimaryKey);
        void Delete(T entityToDelete);

        void Insert(T Item);
        void Update(T Item);
        void InsertAll(IEnumerable<T> Items);
        void UpdateAll(IEnumerable<T> Items);
        Task<int> SaveTransaction();
    }
}

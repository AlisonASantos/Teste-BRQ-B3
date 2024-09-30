using System.Linq.Expressions;
using BRQ_B3.Business.Models;

namespace BRQ_B3.Business.Intefaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> GetId(Guid id);
        Task<List<TEntity>> GetAll();
        Task<TEntity> Update(TEntity entity);
        Task Delete(Guid id);
    }
}
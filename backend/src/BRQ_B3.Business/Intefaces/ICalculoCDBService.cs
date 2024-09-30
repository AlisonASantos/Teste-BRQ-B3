using BRQ_B3.Business.Models;
using BRQ_B3.Business.Models;

namespace BRQ_B3.Business.Intefaces
{
    public interface ICalculoCDBService : IDisposable
    {
        Task<CalculoCDB> Add(CalculoCDB calculoCdb);
        Task<CalculoCDB> Update(CalculoCDB calculoCdb);
        Task<bool> Delete(Guid id);
    }
}
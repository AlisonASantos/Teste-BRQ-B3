using BRQ_B3.Business.Intefaces;
using BRQ_B3.Data.Context;
using BRQ_B3.Business.Models;

namespace BRQ_B3.Data.Repository
{
    public class CalculoCDBRepository : Repository<CalculoCDB>, ICalculoCDBRepository
    {
        public CalculoCDBRepository(MeuDbContext context) : base(context)
        {
        }
    }
}

using BRQ_B3.Business.Intefaces;
using BRQ_B3.Business.Models;
using System.Diagnostics.Metrics;

namespace BRQ_B3.Business.Services
{
    public class CalculoCDBService : ICalculoCDBService
    {
        private readonly ICalculoCDBRepository _calculoCdbRepository;

        public CalculoCDBService(ICalculoCDBRepository calculoCdbRepository)
        {
            _calculoCdbRepository = calculoCdbRepository;
        }

        public async Task<CalculoCDB> Add(CalculoCDB calculoCdb)
        {
            CalculaCdbImposto(calculoCdb);

            return await _calculoCdbRepository.Add(calculoCdb);

        }

        public async Task<CalculoCDB> Update(CalculoCDB calculoCdb)
        {
            CalculaCdbImposto(calculoCdb);
            return await _calculoCdbRepository.Update(calculoCdb);
        }

        public async Task<bool> Delete(Guid id)
        {
            await _calculoCdbRepository.Delete(id);
            return true;
        }


        private static void CalculaCdbImposto(CalculoCDB calculoCdb)
        {
            decimal valorAtual = calculoCdb.ValorInicial;
            decimal percentualImposto;

            for (int i = 0; i < calculoCdb.Meses; i++)
            {
                valorAtual *= (1 + (calculoCdb.Cdi * calculoCdb.TaxaBanco));
            }

            if (calculoCdb.Meses <= 6)
                percentualImposto = 0.225m; // 22,5%
            else if (calculoCdb.Meses <= 12)
                percentualImposto = 0.20m; // 20%
            else if (calculoCdb.Meses <= 24)
                percentualImposto = 0.175m; // 17,5%
            else
                percentualImposto = 0.15m; // 15%

            calculoCdb.ValorFinal = valorAtual * percentualImposto;
        }

        public void Dispose()
        {
            _calculoCdbRepository?.Dispose();
        }
    }
}

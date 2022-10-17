using SistemaContas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaContas.Domain.Interfaces.Repositories
{
    public interface IContaRepository
    {
        void Create(Conta conta);
        void Update(Conta conta);
        void Delete(Conta conta);
        List<Conta> GetAll(DateTime dataMin, DateTime dataMax);
        Conta GetById(Guid idConta);
    }
}

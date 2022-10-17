using Microsoft.EntityFrameworkCore;
using SistemaContas.Data.Contexts;
using SistemaContas.Domain.Entities;
using SistemaContas.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaContas.Data.Repositories
{
    public class ContaRepository : IContaRepository
    {
        public void Create(Conta conta)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Conta.Add(conta);
                sqlServerContext.SaveChanges();
            }
        }

        public void Update(Conta conta)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Entry(conta).State = EntityState.Modified;
                sqlServerContext.SaveChanges();
            }
        }

        public void Delete(Conta conta)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Conta.Remove(conta);
                sqlServerContext.SaveChanges();
            }
        }

        public List<Conta> GetAll(DateTime dataMin, DateTime dataMax)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
               return sqlServerContext.Conta.Where(c => c.Data >= dataMin && c.Data <= dataMax).OrderByDescending(c => c.Data).ToList();
            }
        }

        public Conta GetById(Guid idConta)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Conta.FirstOrDefault(c => c.IdConta.Equals(idConta));
            }
        }

        
    }
}

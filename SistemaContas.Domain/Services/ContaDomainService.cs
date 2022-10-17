using SistemaContas.Domain.Entities;
using SistemaContas.Domain.Interfaces.Reports;
using SistemaContas.Domain.Interfaces.Repositories;
using SistemaContas.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaContas.Domain.Services
{
    public class ContaDomainService : IContaDomainService
    {
        private readonly IContaRepository _contaRepository;
        private readonly IContaReport _contaReport;

        public ContaDomainService(IContaRepository contaRepository, IContaReport contaReport)
        {
            _contaRepository = contaRepository;
            _contaReport = contaReport;
        }

        public void CadastrarConta(Conta conta)
        {
            var dataAtual = DateTime.Now;

            if (conta.Data < new DateTime(dataAtual.Year, dataAtual.Month, dataAtual.Day, 0, 0, 0))
            {
                throw new Exception("O sistema não pode cadastrar contas com data retroativa.");
            }
            _contaRepository.Create(conta);
        }

        public void AtualizarConta(Conta conta)
        {
            var contaId = _contaRepository.GetById(conta.IdConta);
            if (contaId == null)
            {
                throw new Exception("A conta não foi encontrada no sistema, verifique o ID.");
            }
            _contaRepository.Update(conta);
        }

        public void ExcluirConta(Guid idconta)
        {
            var conta = _contaRepository.GetById(idconta);  
            if (conta == null)
            {
                throw new Exception("A conta não foi encontrada no sistema, verifique o ID.");
            }
            _contaRepository.Delete(conta);
        }

        public List<Conta> ConsultarContas(DateTime dataMin, DateTime dataMax)
        {
            if (dataMin > dataMax)
            {
                throw new Exception("A data de início deve ser menor ou igual a data de fim.");
            }
            return _contaRepository.GetAll(dataMin, dataMax);
        }        

        public Conta ObterConta(Guid idConta)
        {
            var conta = _contaRepository.GetById(idConta);
            if ( conta == null)
            {
                throw new Exception("A conta não foi encontrada no sistema, verifique o ID.");
            }
            return conta;
        }

        public byte[] GerarRelatorioExcel(List<Conta> contas)
        {
            if (contas == null || contas.Count == 0)
            {
                throw new Exception("Não há dados para geração do relatório excel.");
            }
           return _contaReport.CreateExcel(contas);
        }

        public byte[] GerarRelatorioPdf(List<Conta> contas)
        {
            if (contas == null || contas.Count == 0)
            {
                throw new Exception("Não há dados para geração do relatório pdf.");
            }
            return _contaReport.CreatePdf(contas);
        }
    }
}

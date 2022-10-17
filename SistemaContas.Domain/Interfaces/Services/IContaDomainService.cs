using SistemaContas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaContas.Domain.Interfaces.Services
{
    public interface IContaDomainService
    {
        void CadastrarConta(Conta conta);
        void AtualizarConta(Conta conta);
        void ExcluirConta(Guid idconta);
        List<Conta> ConsultarContas(DateTime datamin, DateTime datamax);
        Conta ObterConta(Guid idConta);

        byte[] GerarRelatorioExcel(List<Conta> contas);
        byte[] GerarRelatorioPdf(List<Conta> contas);
    }
}

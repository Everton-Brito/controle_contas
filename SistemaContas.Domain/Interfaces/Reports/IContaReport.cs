using SistemaContas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaContas.Domain.Interfaces.Reports
{
    public interface IContaReport
    {
        byte[] CreateExcel(List<Conta> contas);
        byte[] CreatePdf(List<Conta> contas);
    }
}

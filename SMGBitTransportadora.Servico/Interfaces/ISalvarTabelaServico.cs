using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMGBitTransportadora.Servico.Interfaces
{
    public interface ISalvarTabelaServico
    {
        Task SalvarTabela(DataTable tabela);
    }
}

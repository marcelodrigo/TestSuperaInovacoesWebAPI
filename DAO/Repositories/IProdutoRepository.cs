using Model.Entity.Consulta;
using Model.Entity.DB;
using System.Collections.Generic;

namespace DAO.Repositories
{
    public interface IProdutoRepository : IRepositorioBD<Produto>
    {
        List<Produto> ListarProdutos(FiltroConsultaListarProdutos filtroConsulta);
    }
}
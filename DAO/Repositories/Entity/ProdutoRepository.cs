using Model.Entity.Consulta;
using Model.Entity.DB;
using System.Collections.Generic;
using System.Linq;

namespace DAO.Repositories.Entity
{
    public class ProdutoRepository : EntityBaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(DataContext context)
            : base(context)
        { }

        public ProdutoRepository()
            : base()
        { }

        public List<Produto> ListarProdutos(FiltroConsultaListarProdutos filtroConsulta)
        {
            return _context.Produto
                .Where(p => (filtroConsulta.NomeProduto == null || filtroConsulta.NomeProduto.Trim() == "" || p.Nome.Contains(filtroConsulta.NomeProduto))
                    && (!filtroConsulta.Valor.HasValue || filtroConsulta.Valor.Value <= 0 || p.Valor == filtroConsulta.Valor.Value))
                .ToList();
        }
    }
}

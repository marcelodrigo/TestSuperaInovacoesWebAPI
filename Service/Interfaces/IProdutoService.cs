using Model.DTO;
using Model.Entity.Consulta;
using System.Collections.Generic;

namespace Service.Interfaces
{
    public interface IProdutoService
    {
        List<ProdutoDTO> ListarProdutos(FiltroConsultaListarProdutos filtroConsulta);
        ProdutoDTO ObterProduto(long idProduto);
        void RemoverProduto(long idProduto);
        void AlterarProduto(ProdutoDTO produto);
        void CriarProduto(ProdutoDTO produto);
        
    }
}

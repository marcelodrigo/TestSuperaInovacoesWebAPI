using DAO.Repositories;
using DAO.Repositories.Entity;
using Model.DTO;
using Model.Entity.Consulta;
using Model.Entity.DB;
using Service.Conversao;
using Service.Interfaces;
using System;
using System.Collections.Generic;

namespace Service.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly Lazy<IConversaoEntityDTO> _conversorEntityDTO = new Lazy<IConversaoEntityDTO>(() => new ConversaoEntityDTO());

        public List<ProdutoDTO> ListarProdutos(FiltroConsultaListarProdutos filtroConsulta)
        {
            using (IProdutoRepository ProdutoRepository = new ProdutoRepository())
            {
                List<Produto> listaProdutoEntity = ProdutoRepository.ListarProdutos(filtroConsulta);
                return _conversorEntityDTO.Value.Converter<List<Produto>, List<ProdutoDTO>>(listaProdutoEntity);
            }
        }

        public ProdutoDTO ObterProduto(long idProduto)
        {
            using (IProdutoRepository ProdutoRepository = new ProdutoRepository())
            {
                Produto produtoEntity = ProdutoRepository.ObterPeloId(idProduto);
                return _conversorEntityDTO.Value.Converter<Produto, ProdutoDTO>(produtoEntity);
            }
        }

        public void RemoverProduto(long idProduto)
        {
            using (IProdutoRepository ProdutoRepository = new ProdutoRepository())
            {
                Produto produtoEntity = ProdutoRepository.ObterPeloId(idProduto);
                ProdutoRepository.Remover(produtoEntity);
            }
        }

        public void AlterarProduto(ProdutoDTO produto)
        {
            using (IProdutoRepository ProdutoRepository = new ProdutoRepository())
            {
                Produto produtoEntity = ProdutoRepository.ObterPeloId(produto.Id);
                produtoEntity = _conversorEntityDTO.Value.Converter<ProdutoDTO, Produto>(produto, produtoEntity);
                ProdutoRepository.Alterar(produtoEntity);
            }
        }

        public void CriarProduto(ProdutoDTO produto)
        {
            using (IProdutoRepository ProdutoRepository = new ProdutoRepository())
            {
                Produto produtoEntity = new Produto();
                produtoEntity = _conversorEntityDTO.Value.Converter<ProdutoDTO, Produto>(produto, produtoEntity);
                ProdutoRepository.Inserir(produtoEntity);
            }
        }
    }
}

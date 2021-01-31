using Model.DTO;
using Model.Entity.Consulta;
using Service.Interfaces;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace TestSuperaInovacoesWebAPI.Controllers
{
    [RoutePrefix("api/v1")]
    public class ProdutoController : ApiController
    {
        private readonly Lazy<IProdutoService> _service = new Lazy<IProdutoService>(() => new ProdutoService());

        [Route("produtos")]
        [HttpGet]
        public List<ProdutoDTO> ListarProdutos(string nome = null, double? valor = null)
        {
            FiltroConsultaListarProdutos filtroConsulta = new FiltroConsultaListarProdutos()
            {
                NomeProduto = nome,
                Valor = valor
            };
            return _service.Value.ListarProdutos(filtroConsulta);
        }

        [Route("produto/{idProduto}")]
        [HttpGet]
        public ProdutoDTO ObterProduto(long idProduto)
        {
            return _service.Value.ObterProduto(idProduto);
        }

        [Route("produto")]
        [HttpPut]
        public void AlterarProduto(ProdutoDTO produto)
        {
            _service.Value.AlterarProduto(produto);
        }

        [Route("produto")]
        [HttpPost]
        public void CriarProduto(ProdutoDTO produto)
        {
            _service.Value.CriarProduto(produto);
        }

        [Route("produto/{idProduto}")]
        [HttpDelete]
        public void RemoverProduto(long idProduto)
        {
            _service.Value.RemoverProduto(idProduto);
        }


    }
}


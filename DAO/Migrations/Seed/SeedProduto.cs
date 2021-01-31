using Model.Entity.DB;
using System.Data.Entity.Migrations;

namespace DAO.Migrations.Seed
{
    public sealed class SeedProduto
    {
        private SeedProduto() { }

        public static Produto[] Seed(DataContext context)
        {
            Produto[] defaultProdutos = new Produto[]
            {
                new Produto
                {
                    Nome = "Produto 1",
                    Valor = 1.57
                },
                new Produto
                {
                    Nome = "Produto 2",
                    Valor = 3512.1
                },
                new Produto
                {
                    Nome = "Produto 3",
                    Valor = 6
                }
            };

            context.Produto.AddOrUpdate(
                produto => produto.Id,
                defaultProdutos
                );

            return defaultProdutos;
        }
    }
}

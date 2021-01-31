using System;
using System.Collections.Generic;

namespace DAO.Repositories
{
    public interface IRepositorioBD<TEntity> : IDisposable
        where TEntity : class
    {
        IDatabaseTransaction BeginTransaction();
        TEntity ObterPeloId(long id);
        List<TEntity> ObterTodos();
        TEntity Inserir(TEntity obj);
        TEntity Alterar(TEntity obj);
        List<TEntity> Alterar(List<TEntity> iEnumerable);
        TEntity Remover(TEntity obj);
    }
}

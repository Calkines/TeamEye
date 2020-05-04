using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamEye.Core.Interfaces
{
    public interface IAbstractRepository<T> : IDisposable where T : class, IEntity
    {
        void Incluir(T entity);
        void Alterar(T entity);
        T SelecionarPorId(int id);
        void Excluir(int id);
        List<T> SelecionarTodos();
        IQueryable<T> EntidadePesquisavel();
    }
}

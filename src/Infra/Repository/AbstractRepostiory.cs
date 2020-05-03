using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamEye.Core.Interfaces;

namespace TeamEye.Infra.Repository
{
    public class AbstractRepostiory<T> : IAbstractRepository<T> where T : class, IEntity
    {
        protected readonly TeamEyeEFContext _context;
        public AbstractRepostiory(TeamEyeEFContext context)
        {
            _context = context;
        }
        public virtual void Alterar(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public virtual void Dispose()
        {
            _context.Dispose();
        }

        public virtual void Excluir(int id)
        {
            var entity = SelecionarPorId(id);
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public virtual void Incluir(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public virtual T SelecionarPorId(int id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public virtual List<T> SelecionarTodos()
        {
            return _context.Set<T>().ToList();
        }
    }
}

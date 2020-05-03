using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamEye.Core.Entities;
using TeamEye.Core.Interfaces;

namespace TeamEye.Infra.Repository
{
    public class CampeonatoRepostiory : AbstractRepostiory<Campeonato>, ICampeonatoRepository
    {
        public CampeonatoRepostiory(TeamEyeEFContext context) : base(context)
        {
        }

        public override void Incluir(Campeonato entity)
        {
            //Resolve inclusão de estado
            foreach (var dc in entity.DetalhesCampeonato)
            {
                if (_context.Estados.AsQueryable().Count(x => x.Sigla == dc.Time.Estado.Sigla) > 0)
                    dc.Time.SetEstado(_context.Estados.AsQueryable().Where(x => x.Sigla == dc.Time.Estado.Sigla).FirstOrDefault());
                else
                {
                    _context.Add(dc.Time.Estado);
                    _context.SaveChanges();
                }
            }
            //Resolve inclusão de time
            foreach (var dc in entity.DetalhesCampeonato)
            {
                if (_context.Times.AsQueryable().Count(x => x.NomeNormalizado == dc.Time.NomeNormalizado && x.EstadoId == dc.Time.Estado.Id) > 0)
                    dc.SetTime(_context.Times.AsQueryable().Where(x => x.NomeNormalizado == dc.Time.NomeNormalizado && x.EstadoId == dc.Time.EstadoId).FirstOrDefault());
                else
                {
                    _context.Add(dc.Time);
                    _context.SaveChanges();
                }
            }
            //Inclui último nível (campeonato)            
            base.Incluir(entity);
        }
    }
}

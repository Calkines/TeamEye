using Microsoft.EntityFrameworkCore;
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
                    dc.SetTime(_context.Times.AsQueryable().Where(x => x.NomeNormalizado == dc.Time.NomeNormalizado && x.EstadoId == dc.Time.Estado.Id).FirstOrDefault());
                else
                {
                    _context.Add(dc.Time);
                    _context.SaveChanges();
                }
            }
            foreach (var dc in entity.DetalhesCampeonato)
            {
                dc.TimeId = dc.Time.Id;
                dc.Time.EstadoId = dc.Time.Estado.Id;
            }
            //Inclui último nível (campeonato)            
            base.Incluir(entity);
        }

        public Campeonato SelecionarCampeonatoPorAno(int ano)
        {
            return _context.Campeonatos.Where(x => x.Ano == ano)
                                        .Include(x => x.DetalhesCampeonato)                                        
                                        .ThenInclude(x => x.Time)
                                        .ThenInclude(x => x.Estado)                                        
                                        .FirstOrDefault();
        }
        public override List<Campeonato> SelecionarTodos()
        {
            return _context.Campeonatos.Include(x => x.DetalhesCampeonato)
                                        .ThenInclude(x => x.Time)
                                        .ThenInclude(x => x.Estado)
                                        .ToList();
        }
    }
}

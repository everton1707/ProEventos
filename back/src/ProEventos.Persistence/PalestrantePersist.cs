using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class ProEventosPersistence : IPalestrantePersist
    {
        private readonly ProEventosContext _context;
        public ProEventosPersistence(ProEventosContext context)
        {
            _context = context;
        }        

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedesSociais);

                if(includeEventos){
                    query = query.Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
                }
            query = query.AsNoTracking().OrderBy(p => p.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedesSociais);

                if(includeEventos){
                    query = query.Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
                }
            query = query.AsNoTracking().OrderBy(p => p.Id)
                            .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }


        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedesSociais);

                if(includeEventos){
                    query = query.Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
                }
            query = query.AsNoTracking().OrderBy(p => p.Id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }


    }
}
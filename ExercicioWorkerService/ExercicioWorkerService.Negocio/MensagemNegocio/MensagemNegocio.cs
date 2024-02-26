using ExercicioWorkerService.Infra.Entity;
using ExercicioWorkerService.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioWorkerService.Negocio.MensagemNegocio
{
    public class MensagemNegocio : IMensagemNegocio
    {
        private readonly AppDbContext _context;

        public MensagemNegocio(AppDbContext context)
        {
            _context = context; 
        }

        public async Task Incluir(MinhaMensagem minhaMensagem)
        {
            await _context.MinhaMensagem.AddAsync(minhaMensagem);
            await _context.SaveChangesAsync();
        }

        public async Task<List<MinhaMensagem>> ObterLista()
        {
            return await _context.MinhaMensagem.ToListAsync();
        }
    }
}

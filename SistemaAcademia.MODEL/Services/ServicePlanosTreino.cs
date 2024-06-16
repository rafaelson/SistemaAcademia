using SistemaAcademia.MODEL.Models;
using SistemaAcademia.MODEL.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaAcademia.MODEL.Services
{
    public class ServicePlanosTreino
    {
        public RepositoryPlanosTreino oRepositoryPlanosTreino { get; set; }
        private SistemaAcademiaContext _context;

        public ServicePlanosTreino(SistemaAcademiaContext context)
        {
            _context = context;
            oRepositoryPlanosTreino = new RepositoryPlanosTreino(context);
        }

        public async Task IncluirPlanoTreino(PlanosTreino planoTreino)
        {
            await oRepositoryPlanosTreino.IncluirAsync(planoTreino);
        }

        public async Task AlterarPlanoTreino(PlanosTreino planoTreino)
        {
            await oRepositoryPlanosTreino.AlterarAsync(planoTreino);
        }

        public async Task ExcluirPlanoTreino(int id)
        {
            var planoTreino = await oRepositoryPlanosTreino.SelecionarChaveAsync(id);
            if (planoTreino != null)
            {
                await oRepositoryPlanosTreino.ExcluirAsync(planoTreino);
            }
        }

        public async Task<PlanosTreino> SelecionarPlanoTreinoPorId(int id)
        {
            return await oRepositoryPlanosTreino.SelecionarChaveAsync(id);
        }

        public async Task<List<PlanosTreino>> SelecionarTodosPlanosTreino()
        {
            return await oRepositoryPlanosTreino.SelecionarTodosAsync();
        }
    }
}

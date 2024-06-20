using SistemaAcademia.MODEL.Models;
using SistemaAcademia.MODEL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademia.MODEL.Services
{
    public class ServiceMembros
    {
        public RepositoryMembros oRepositoryMembros { get; set; }
        private SistemaAcademiaContext _context;
        private ServicePlanosTreino _servicePlanosTreino;

        public ServiceMembros(SistemaAcademiaContext context)
        {
            _context = context;
            oRepositoryMembros = new RepositoryMembros(context);
            _servicePlanosTreino = new ServicePlanosTreino(context);
        }

        public async Task IncluirMembro(Membros membro)
        {
            await oRepositoryMembros.IncluirAsync(membro);
        }

        public async Task AlterarMembro(Membros membro)
        {
            await oRepositoryMembros.AlterarAsync(membro);
        }

        public async Task ExcluirMembro(int id)
        {
            var membro = await oRepositoryMembros.SelecionarChaveAsync(id);
            var treinos = await _servicePlanosTreino.SelecionarTodosPlanosTreino();
            var treinosMembro = treinos.Where((treino) => treino.MembroId == id);

            foreach (var item in treinosMembro)
            {
                await _servicePlanosTreino.ExcluirPlanoTreino(item.Id);
            }
            if (membro != null)
            {
                await oRepositoryMembros.ExcluirAsync(membro);
            }
        }

        public async Task<Membros> SelecionarMembroPorId(int id)
        {
            return await oRepositoryMembros.SelecionarChaveAsync(id);
        }

        public async Task<List<Membros>> SelecionarTodosMembros()
        {
            return await oRepositoryMembros.SelecionarTodosAsync();
        }
    }
}

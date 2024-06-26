﻿using SistemaAcademia.MODEL.Models;
using SistemaAcademia.MODEL.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaAcademia.MODEL.Services
{
    public class ServiceTreinadores
    {
        public RepositoryTreinadores oRepositoryTreinadores { get; set; }
        private SistemaAcademiaContext _context;
        private ServicePlanosTreino _servicePlanosTreino;

        public ServiceTreinadores(SistemaAcademiaContext context)
        {
            _context = context;
            oRepositoryTreinadores = new RepositoryTreinadores(context);
            _servicePlanosTreino = new ServicePlanosTreino(context);
        }

        public async Task IncluirTreinador(Treinadores treinador)
        {
            await oRepositoryTreinadores.IncluirAsync(treinador);
        }

        public async Task AlterarTreinador(Treinadores treinador)
        {
            await oRepositoryTreinadores.AlterarAsync(treinador);
        }

        public async Task ExcluirTreinador(int id)
        {
            var treinador = await oRepositoryTreinadores.SelecionarChaveAsync(id);
            var treinos = await _servicePlanosTreino.SelecionarTodosPlanosTreino();
            var treinosTreinador = treinos.Where((treino) => treino.TreinadorId == id);

            foreach (var item in treinosTreinador)
            {
                await _servicePlanosTreino.ExcluirPlanoTreino(item.Id);
            }
            if (treinador != null)
            {
                await oRepositoryTreinadores.ExcluirAsync(treinador);
            }
        }

        public async Task<Treinadores> SelecionarTreinadorPorId(int id)
        {
            return await oRepositoryTreinadores.SelecionarChaveAsync(id);
        }

        public async Task<List<Treinadores>> SelecionarTodosTreinadores()
        {
            return await oRepositoryTreinadores.SelecionarTodosAsync();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using SistemaAcademia.MODEL.Models;
using SistemaAcademia.MODEL.Services;
using System;
using System.Threading.Tasks;

namespace SistemaAcademia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanosTreinoController : ControllerBase
    {
        private SistemaAcademiaContext _context;
        private ServicePlanosTreino _service;

        public PlanosTreinoController(SistemaAcademiaContext context)
        {
            _context = context;
            _service = new ServicePlanosTreino(_context);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.SelecionarTodosPlanosTreino());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.SelecionarPlanoTreinoPorId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(PlanosTreino planoTreino)
        {
            await _service.IncluirPlanoTreino(planoTreino);
            return Ok("Plano de treino cadastrado com sucesso");
        }

        [HttpPut]
        public async Task<IActionResult> Put(PlanosTreino planoTreino)
        {
            await _service.AlterarPlanoTreino(planoTreino);
            return Ok("Plano de treino atualizado com sucesso");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.ExcluirPlanoTreino(id);
                return Ok("Plano de treino excluído com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

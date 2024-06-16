using Microsoft.AspNetCore.Mvc;
using SistemaAcademia.MODEL.Models;
using SistemaAcademia.MODEL.Services;
using System;
using System.Threading.Tasks;

namespace SistemaAcademia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreinadoresController : ControllerBase
    {
        private SistemaAcademiaContext _context;
        private ServiceTreinadores _service;

        public TreinadoresController(SistemaAcademiaContext context)
        {
            _context = context;
            _service = new ServiceTreinadores(_context);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.SelecionarTodosTreinadores());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.SelecionarTreinadorPorId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(Treinadores treinador)
        {
            await _service.IncluirTreinador(treinador);
            return Ok("Treinador cadastrado com sucesso");
        }

        [HttpPut]
        public async Task<IActionResult> Put(Treinadores treinador)
        {
            await _service.AlterarTreinador(treinador);
            return Ok("Treinador atualizado com sucesso");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.ExcluirTreinador(id);
                return Ok("Treinador excluído com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

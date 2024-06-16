using Microsoft.AspNetCore.Mvc;
using SistemaAcademia.MODEL.Models;
using SistemaAcademia.MODEL.Services;
using System;
using System.Threading.Tasks;

namespace SistemaAcademia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembrosController : ControllerBase
    {
        private SistemaAcademiaContext _context;
        private ServiceMembros _service;

        public MembrosController(SistemaAcademiaContext context)
        {
            _context = context;
            _service = new ServiceMembros(_context);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.SelecionarTodosMembros());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.SelecionarMembroPorId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(Membros membro)
        {
            await _service.IncluirMembro(membro);
            return Ok("Membro cadastrado com sucesso");
        }

        [HttpPut]
        public async Task<IActionResult> Put(Membros membro)
        {
            await _service.AlterarMembro(membro);
            return Ok("Membro atualizado com sucesso");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.ExcluirMembro(id);
                return Ok("Membro excluído com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

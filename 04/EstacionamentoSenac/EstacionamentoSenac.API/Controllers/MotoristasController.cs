using EstacionamentoSenac.API.Data;
using EstacionamentoSenac.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EstacionamentoSenac.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotoristasController : ControllerBase
    {
        private AppDbContext _context;

        public MotoristasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Motorista>> GetMotoristas()
        {
            return Ok(_context.Motoristas.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Veiculo> GetMotoristaById(int id)
        {
            //_context.Veiculos.FirstOrDefault(v => v.Id == id);
            var motorista = _context.Motoristas.Find(id);

            if (motorista == null)
                return NotFound();

            return Ok(motorista);
        }

        [HttpPost]
        public ActionResult<Veiculo> PostMotorista(Motorista motorista)
        {
            _context.Motoristas.Add(motorista);
            _context.SaveChanges();

            return Created();
        }

        [HttpPut("{id}")]
        public ActionResult<Motorista> PutMotorista(int id, Motorista motoristaNovo)
        {
            if (id != motoristaNovo.Id)
                return BadRequest("Veiculo informado na URL diferente do objeto JSON");

            var motoristaExistente = _context.Motoristas.Find(id);
            if (motoristaExistente == null) return NotFound();

            // Atualizar de fato o veículo
            motoristaExistente.Nome = motoristaNovo.Nome;
            motoristaExistente.VeiculoId = motoristaNovo.VeiculoId;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Motorista> DeleteMotorista (int id)
        {
            var motorista = _context.Motoristas.Find(id);
            if (motorista == null) return NotFound();

            _context.Motoristas.Remove(motorista);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

using EstacionamentoSenac.API.Controllers.Data;
using EstacionamentoSenac.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstacionamentoSenac.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private AppDbContext _context;

        public VeiculosController(AppDbContext context)
        {
            _context = context;
        }

        public ActionResult<List<Veiculo>> GetVeiculos()
        {
            return Ok(_context.Veiculos.ToList());
        }
        [HttpGet("{id}")]
        public ActionResult<Veiculo> GetVeiculoById(int id)
        {
            Veiculo veiculo = _context.Veiculos.FirstOrDefault(v => v.Id == id);

            if (veiculo == null)
                return NotFound();

            return Ok(veiculo);
        }

        [HttpPost]
        public ActionResult<Veiculo> PostVeiculo(Veiculo veiculo)
        {
            _context.Veiculos.Add(veiculo);
            _context.SaveChanges();

            return Created();
        }

        [HttpPut("{id}")]
        public ActionResult<Veiculo> PutVeiculo(int id , Veiculo veiculoNovo)
        {
            if(id!= veiculoNovo.Id)
            return BadRequest("Veiculo informado na URl diferente do objeto JSON");

            var veiculoExistente = _context.Veiculos.Find(id);
            if (veiculoExistente == null) return NotFound();

            veiculoExistente.Marca = veiculoNovo.Marca;
            veiculoExistente.Modelo = veiculoNovo.Modelo;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Veiculo> DeleteVeiculo(int id)
        {
            var veiculo = _context.Veiculos.Find(id);

            if (veiculo == null) return NotFound();

            _context.Veiculos.Remove(veiculo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}




using EstacionamentoSenac.API.Controllers.Data;
using EstacionamentoSenac.API.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class MotoristaController : ControllerBase
{
    private AppDbContext _context;

    public MotoristaController(AppDbContext context)
    {
        _context = context;
    }

    public ActionResult<List<Motorista>> GetMotorista()
    {
        return Ok(_context.Motoristas.ToList());
    }
    [HttpGet("{id}")]
    public ActionResult<Motorista> GetMotoristaById(int id)
    {
        Motorista motorista = _context.Motoristas.FirstOrDefault(v => v.Id == id);

        if (motorista == null)
            return NotFound();

        return Ok(motorista);
    }

    [HttpPost]
    public ActionResult<Motorista> PostMotorista(Motorista motorista)
    {
        _context.Motoristas.Add(motorista);
        _context.SaveChanges();

        return Created();
    }

    [HttpPut("{id}")]
    public ActionResult<Motorista> PutMotorista(int id, Motorista motoristaNovo)
    {
        if (id != motoristaNovo.Id)
            return BadRequest("Motorista informado na URl diferente do objeto JSON");

        var motoristaExistente = _context.Motoristas.Find(id);
        if (motoristaExistente == null) return NotFound();

        motoristaExistente.Nome = motoristaNovo.Nome;
        motoristaExistente.VeiculoId = motoristaNovo.VeiculoId;

        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult<Motorista> DeleteMotorista(int id)
    {
        var motorista = _context.Motoristas.Find(id);

        if (motorista == null) return NotFound();

        _context.Motoristas.Remove(motorista);
        _context.SaveChanges();
        return NoContent();
    }
}



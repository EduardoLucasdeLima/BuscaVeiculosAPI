using BuscaVeiculosAPI.Context;
using BuscaVeiculosAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BuscaVeiculosAPI.Controllers;

[Route("[controller]")]
[ApiController]
public class VeiculoController : ControllerBase
{
    private readonly AppDbContext _context;

    public VeiculoController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Veiculo>> Get()
    {
        var veiculos = _context.Veiculos.ToList();
        if (veiculos is null)
        {
            return NotFound("Veiculo não encontrado.");
        }
        return veiculos;
    }

    [HttpGet("{id:int}", Name = "ObterVeiculo")]
    public ActionResult<Veiculo> Get(int id)
    {
        var veiculo = _context.Veiculos.FirstOrDefault(c => c.Id == id);
        if (veiculo is null)
        {
            return NotFound("Veiculo não encontrado.");
        }
        return veiculo;
    }

    [HttpPost]
    public ActionResult Post(Veiculo veiculo)
    {
        if (veiculo is null)
            return BadRequest();

        _context.Veiculos.Add(veiculo);
        _context.SaveChanges();

        return new CreatedAtRouteResult("ObterVeiculo",
            new { id = veiculo.Id }, veiculo);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Veiculo veiculo)
    {
        if(id != veiculo.Id)
        {
            return BadRequest();
        }

        _context.Entry(veiculo).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(veiculo);

    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var veiculo = _context.Veiculos.FirstOrDefault(v => v.Id == id);

        if(veiculo is null)
        {
            return NotFound("Veiculo não localizado");
        }
        _context.Veiculos.Remove(veiculo);
        _context.SaveChanges();

        return Ok(veiculo);
    }

}



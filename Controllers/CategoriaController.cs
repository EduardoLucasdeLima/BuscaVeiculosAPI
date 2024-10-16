using BuscaVeiculosAPI.Context;
using BuscaVeiculosAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BuscaVeiculosAPI.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoriaController : ControllerBase
{

    private readonly AppDbContext _context;

    public CategoriaController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("veiculos")]
    public ActionResult<IEnumerable<Categoria>> GetCategoriasVeiculos()
    {
        return _context.Categorias.Include(v => v.Veiculos).Where(c => c.Id <= 5).ToList();
    }
    
    
    [HttpGet]
    public ActionResult<IEnumerable<Categoria>> Get()
    {
        {
            return _context.Categorias.AsNoTracking().ToList();
        }
    }

    [HttpGet("{id:int}", Name = "ObterCategoria")]
    public ActionResult<Categoria> Get(int id)
    {
        var categoria = _context.Categorias.AsNoTracking().FirstOrDefault(c => c.Id == id);
        if (categoria is null)
        {
            return NotFound("Categoria não encontrada.");
        }
        return categoria;
    }

    [HttpPost]
    public ActionResult Post(Categoria categoria)
    {
        if (categoria is null)
            return BadRequest();

        _context.Categorias.Add(categoria);
        _context.SaveChanges();

        return new CreatedAtRouteResult("ObterCategoria",
            new { id = categoria.Id }, categoria);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Categoria categoria)
    {
        if(id != categoria.Id)
        {
            return BadRequest();
        }
        _context.Entry(categoria).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(categoria);

    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var categoria = _context.Categorias.FirstOrDefault(v => v.Id == id);

        if (categoria is null)
        {
            return NotFound($"Categoria com id={id} não encontrada.");
        }
        _context.Categorias.Remove(categoria);
        _context.SaveChanges();

        return Ok(categoria);
    }


}

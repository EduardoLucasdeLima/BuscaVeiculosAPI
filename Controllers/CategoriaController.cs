using BuscaVeiculosAPI.Context;
using BuscaVeiculosAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet]
    public ActionResult<IEnumerable<Categoria>> Get()
    {
        var categorias = _context.Categorias.ToList();
        if(categorias is null) 
        {
            return NotFound("Categoria não encontrada.");
        }
        return categorias;
    }

    [HttpGet("{id:int}", Name="ObterCategoria")]
    public ActionResult<Categoria> Get(int id)
    {
        var categoria = _context.Categorias.FirstOrDefault(c => c.Id == id);
        if ( categoria is null)
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


}

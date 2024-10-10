using Microsoft.AspNetCore.Mvc;
using BuscaVeiculosAPI.Models;
using Microsoft.EntityFrameworkCore;
using BuscaVeiculosAPI.Context;

namespace BuscaVeiculosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlacasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PlacasController(AppDbContext context)
        {
            _context = context;
        }

        // Método para obter um veículo pela placa
        [HttpGet("{placa}")]
        public ActionResult<Veiculo> GetVeiculoByPlaca(string placa)
        {
            var veiculo = _context.Veiculos.Include(v => v.Categoria).FirstOrDefault(v => v.Placa == placa);
            if (veiculo == null)
            {
                return NotFound();
            }
            return Ok(veiculo);
        }

        // Outros métodos devem usar VeiculoId em vez de Id
    }
}

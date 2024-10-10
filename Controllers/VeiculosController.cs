using Microsoft.AspNetCore.Mvc;
using BuscaVeiculosAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using BuscaVeiculosAPI.Context;

namespace BuscaVeiculosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VeiculosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VeiculosController(AppDbContext context)
        {
            _context = context;
        }

        // Método para obter um veículo por VeiculoId
        [HttpGet("{veiculoId}")]
        public ActionResult<Veiculo> GetVeiculo(int veiculoId)
        {
            var veiculo = _context.Veiculos.Include(v => v.Categoria).FirstOrDefault(v => v.VeiculoId == veiculoId);
            if (veiculo == null)
            {
                return NotFound();
            }
            return Ok(veiculo);
        }

        // Método para adicionar um novo veículo
        [HttpPost]
        public ActionResult<Veiculo> AddVeiculo(Veiculo veiculo)
        {
            _context.Veiculos.Add(veiculo);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetVeiculo), new { veiculoId = veiculo.VeiculoId }, veiculo);
        }

        // Outros métodos (atualizar, deletar, etc.) devem usar VeiculoId em vez de Id
    }
}

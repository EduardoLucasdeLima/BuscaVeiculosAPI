using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuscaVeiculosAPI.Models;

[Table("Veiculos")]

public class Veiculo
{
    [Key]
    public int VeiculoId { get; set; } // Chave primária
    [Required]
    [StringLength(50)]
    public string? Nome { get; set; }

    [Required]
    [StringLength(50)]
    public string? Placa { get; set; }

    [Required]
    [StringLength(300)]
    public string? ImagemUrl { get; set; }
    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }
}

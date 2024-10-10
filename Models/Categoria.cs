using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BuscaVeiculosAPI.Models;

public class Categoria
{
    public Categoria()
    {
        Veiculos = new Collection<Veiculo>();
    }

    [Key]
    public int CategoriaId { get; set; }

    [Required]
    [StringLength(50)]
    public string? Nome { get; set; }

    [Required]
    [StringLength(300)]
    public string? ImagemUrl { get; set; }

    public ICollection<Veiculo>? Veiculos { get; set; }
}

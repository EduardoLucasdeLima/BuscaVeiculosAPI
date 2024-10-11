using System.ComponentModel.DataAnnotations;

namespace BuscaVeiculosAPI.Models;

public class Categoria
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string ModeloCarro { get; set; }

    [StringLength(500)]
    public string DescricaoCarro { get; set; }

    [Url]
    public string ImagemUrl { get; set; }

    // Propriedade de navegação para os veículos
    public virtual ICollection<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
}
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BuscaVeiculosAPI.Models;

public class Categoria
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string? ModeloCarro { get; set; }

    [StringLength(500)]
    public string? DescricaoCarro { get; set; }

    [Url]
    public string? ImagemUrl { get; set; }

    [JsonIgnore]
    public virtual ICollection<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
}
﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BuscaVeiculosAPI.Models;

public class Veiculo
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string? NomeCarro { get; set; }

    [Required]
    [StringLength(7)]
    public string? PlacaCarro { get; set; }

    [StringLength(500)]
    public string? DescricaoCarro { get; set; }

    [Url]
    public string? ImagemUrl { get; set; }

    [Required]
    public int CategoriaId { get; set; }

    [JsonIgnore]
    public virtual Categoria? Categoria { get; set; }
}
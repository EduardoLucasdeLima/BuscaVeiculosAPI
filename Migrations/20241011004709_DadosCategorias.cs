using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuscaVeiculosAPI.Migrations
{
    public partial class DadosCategorias : Migration
    {
        protected override void Up(MigrationBuilder mB)
        {
            mB.Sql("INSERT INTO Categorias (ModeloCarro, DescricaoCarro, ImagemUrl) VALUES " +
                   "('Hatch', 'Compacto, ágil e estiloso. Perfeito para a cidade!', 'http://exemplo.com/imagemA.jpg'), " +
                   "('Sedan', 'Elegante, espaçoso e confortável. Ideal para viagens e estilo!', 'http://exemplo.com/imagemB.jpg'), " +
                   "('SUV',   'Robustez, espaço e versatilidade. Perfeito para aventuras e conforto em família!', 'http://exemplo.com/imagemC.jpg'), " +
                   "('PickUp','Potente, versátil e pronta para o trabalho. Ideal para quem precisa de força e espaço!', 'http://exemplo.com/imagemD.jpg');");
        }

        protected override void Down(MigrationBuilder mB)
        {
            mB.Sql("DELETE FROM Categorias WHERE ModeloCarro IN ('Hatch', 'Sedan', 'SUV', 'PickUp');");
        }
    }
}

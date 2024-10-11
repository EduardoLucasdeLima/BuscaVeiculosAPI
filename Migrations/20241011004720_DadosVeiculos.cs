using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuscaVeiculosAPI.Migrations
{
    public partial class DadosVeiculos : Migration
    {
        protected override void Up(MigrationBuilder mB)
        {
            mB.Sql("INSERT INTO Veiculos (NomeCarro, PlacaCarro, DescricaoCarro, ImagemUrl, CategoriaId) VALUES " +
            "('Golf GTI', 'ABC1234', 'Hatch esportivo com motor turbo e design agressivo.', 'http://exemplo.com/imagem1.jpg', 1), " +
            "('Jetta GLI', 'XYZ5678', 'Sedan com desempenho excepcional e conforto premium.', 'http://exemplo.com/imagem2.jpg', 2), " +
            "('Tiguan R-Line', 'LMN9101', 'SUV robusto com tecnologia avançada e interior espaçoso.', 'http://exemplo.com/imagem3.jpg', 3), " +
            "('Amarok', 'OPQ2345', 'Pickup potente, ideal para trabalho e aventura.', 'http://exemplo.com/imagem4.jpg', 4);");
        }

        protected override void Down(MigrationBuilder mB)
        {
            mB.Sql("DELETE FROM Veiculos WHERE NomeCarro IN ('Golf GTI', 'Jetta GLI', 'Tiguan R-Line','Amarok');");
        }
    }
}

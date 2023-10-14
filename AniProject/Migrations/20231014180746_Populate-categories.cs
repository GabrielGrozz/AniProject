using AniProject.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AniProject.Migrations
{
    /// <inheritdoc />
    public partial class Populatecategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories(CategoryName, CategoryDescription)" +
                "VALUES('Shonen', 'Significa menino na livre tradução a partir do japonês." +
                " Este tipo de anime é direcionado ao público masculino jovem (adolescentes, principalmente)," +
                " entre os 12 e 18 anos de idade. Esta é considerada a classificação mais popular de animes e mangás." +
                "A história dos animes shounen costuma ser focada no desenvolvimento e jornada do herói, que neste caso é" +
                " do gênero masculino.')");

            migrationBuilder.Sql("INSERT INTO Categories(CategoryName, CategoryDescription)" +
                "VALUES('Seinen', 'Significa adulto ou homem adulto. Como o nome sugere, estes animes são feitos para" +
                " um público mais maduro, normalmente entre os 18 e 40 anos. Os Seinens são destinados ao gênero masculino," +
                " contendo temas complexos e que não seriam apropriados para os mais jovens.Conteúdo erótico e" +
                " cenas com muita violência também fazem parte das produções Seinen.')");

            migrationBuilder.Sql("INSERT INTO Categories(CategoryName, CategoryDescription)" +
                "VALUES('Kodomo', 'São animes feitos com foco as crianças, como o nome sugere, principalmente entre os 4 e 10 anos." +
                "As histórias Kodomo costumam transmitir importantes lições para os mais novos, como respeitar os mais velhos," +
                " por exemplo.Os enredos são simples e de fácil compreensão.A importância da amizade e a valorização de valores" +
                " fraternais e familiares também são comuns neste tipo de anime.')");

            migrationBuilder.Sql("INSERT INTO Categories(CategoryName, CategoryDescription)" +
                "VALUES('Mecha', 'Um dos mais amados subgêneros em anime e mangá é o mecha que," +
                " basicamente, consiste em robôs gigantes batendo em outras coisas gigantes, como kaijus e aliens." +
                " O mecha ficou muito popular entre as décadas de 1980-90, com a popularização de animes como Evangelion no ocidente." +
                " Não é preciso falar também que o gênero se mistura com a aventura, ação, ficção-científica e até sobre saúde mental.')");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categories");

        }
    }
}

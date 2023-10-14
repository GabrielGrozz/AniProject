using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace AniProject.Migrations
{
    /// <inheritdoc />
    public partial class Pupulateanimes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Animes(CategoryId, AnimeName, AnimeDescription ) " +
                "VALUES(1 ,'Dragon Ball Z', 'As aventuras de um poderoso guerreiro chamado Goku," +
                " seu filho Gohan e seus aliados, que se esforçam para defender a Terra das ameaças." +
                " Eles são auxiliados por um dragão que concede os desejos de quem quer que reúna" +
                " as sete Esferas do Dragão.')");

            migrationBuilder.Sql("INSERT INTO Animes(CategoryId, AnimeName, AnimeDescription ) " +
                "VALUES(1 ,'Naruto', 'Naruto é uma série de mangá escrita e ilustrada por Masashi Kishimoto," +
                " que conta a história de Naruto Uzumaki, um jovem ninja que constantemente procura por reconhecimento" +
                " e sonha em se tornar Hokage, o ninja líder de sua vila.')");

            migrationBuilder.Sql("INSERT INTO Animes(CategoryId, AnimeName, AnimeDescription ) " +
                "VALUES(2 ,'Berserk', 'Berserk é uma série de mangá escrita e ilustrada por Kentaro Miura." +
                " Situado em um mundo de fantasia sombria inspirado na Europa medieval, a história gira em torno de Guts," +
                " um solitário mercenário, e Griffith, o líder de um bando de mercenários chamado de Bando do Falcão.')");

            migrationBuilder.Sql("INSERT INTO Animes(CategoryId, AnimeName, AnimeDescription ) " +
                "VALUES(3 ,'Hamtaro', ' conta as aventuras de pequenos hamsters que saem de suas gaiolas para" +
                " se reunir com seus amigos ou ajudar os seus donos. O mangá foi criado e ilustrado por Ritsuko Kawai.')");

            migrationBuilder.Sql("INSERT INTO Animes(CategoryId, AnimeName, AnimeDescription ) " +
                "VALUES(4 ,'Darling in the Franxxx', 'Os sobreviventes de uma guerra catastrófica" +
                " contra monstros aglomeram-se em cidades-fortaleza móveis e treinam jovens para defender" +
                " a humanidade pilotando grandes robôs de batalha chamados Franxx.')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Animes");
        }
    }
}

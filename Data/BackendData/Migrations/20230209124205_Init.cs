using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackendData.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    City = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ZipCode = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Street = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    HouseNumber = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "HouseNumber", "Street", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Huangmei", "China", "44", "700 Gale Lane", "71870" },
                    { 2, "Kliwon Cibingbin", "Indonesia", "66", "98 Farragut Terrace", "88895" },
                    { 3, "Tha Muang", "Thailand", "99", "8 Pearson Drive", "71110" },
                    { 4, "Komsomolsk", "Ukraine", "30", "900 Buell Plaza", "7141KL" },
                    { 5, "Biyan", "Indonesia", "51", "53 Swallow Center", "6754RE" },
                    { 6, "South River", "Canada", "79", "2 Hansons Point", "P3Y" },
                    { 7, "Karanganyar", "Indonesia", "40", "07 Caliangt Terrace", "5552OP" },
                    { 8, "Provins", "France", "70", "52085 Swallow Alley", "7748CE" },
                    { 9, "Tylicz", "Poland", "99", "62534 Bowman Pass", "333838" },
                    { 10, "Lloydminster", "Canada", "9", "93135 Muir Hill", "S9V" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}

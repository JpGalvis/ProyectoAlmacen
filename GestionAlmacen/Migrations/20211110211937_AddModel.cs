using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionAlmacen.Migrations
{
    public partial class AddModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Almacen",
                columns: table => new
                {
                    producto = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    almacen = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    informacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    link = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Almacen", x => x.producto);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Almacen");
        }
    }
}

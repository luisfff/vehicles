using Microsoft.EntityFrameworkCore.Migrations;

namespace Vehicles.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert Into Makes (Name) Values ('Make type 1')");
            migrationBuilder.Sql("Insert Into Makes (Name) Values ('Make type 2')");

            migrationBuilder.Sql("Insert Into Models (Name, MakeId) Values ('Make1-ModelA', (Select ID from Makes where Name = 'Make type 1'))");
            migrationBuilder.Sql("Insert Into Models (Name, MakeId) Values ('Make1-ModelB', (Select ID from Makes where Name = 'Make type 1'))");
            migrationBuilder.Sql("Insert Into Models (Name, MakeId) Values ('Make1-ModelC', (Select ID from Makes where Name = 'Make type 1'))");

            migrationBuilder.Sql("Insert Into Models (Name, MakeId) Values ('Make2-ModelA', (Select ID from Makes where Name = 'Make type 2'))");
            migrationBuilder.Sql("Insert Into Models (Name, MakeId) Values ('Make2-ModelB', (Select ID from Makes where Name = 'Make type 2'))");
            migrationBuilder.Sql("Insert Into Models (Name, MakeId) Values ('Make2-ModelC', (Select ID from Makes where Name = 'Make type 2'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete From Makes");
        }
    }
}

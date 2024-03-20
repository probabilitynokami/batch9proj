using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkDesign.Migrations
{
    /// <inheritdoc />
    public partial class testmigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Distributor",
                table: "Products",
                type: "text",
                maxLength: 15,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Distributor",
                table: "Products");
        }
    }
}

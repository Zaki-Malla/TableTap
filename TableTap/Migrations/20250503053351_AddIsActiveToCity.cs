using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TableTap.Migrations
{
    /// <inheritdoc />
    public partial class AddIsActiveToCity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TbCity",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TbCity");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace surfs_up_project.Migrations
{

    /// <inheritdoc />
    public partial class InkrementId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
            name: "ProductId",
            table: "Products",
            nullable: false,
            oldClrType: typeof(int))
            .Annotation("SqlServer:Identity", "1, 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

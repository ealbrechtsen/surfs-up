using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace surfs_up_project.Migrations
{
    /// <inheritdoc />
    public partial class NyeBoards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
             table: "Products",
             columns: new[] { "ProductId", "Name", "ImagePath", "Length", "Width", "Thickness", "Volume", "Type", "Price" },
             values: new object[,]
             {

                { 5, "Surfboard A", "path/to/imageA.jpg", 6.0, 20.5, 2.75, 35.0, "Shortboard", 599.99 },
                { 6, "Surfboard B", "path/to/imageB.jpg", 7.0, 21.0, 2.85, 40.0, "Funboard", 649.99 },
                { 8, "Surfboard A", "path/to/imageA.jpg", 6.0, 20.5, 2.75, 35.0, "Shortboard", 599.99 },
                { 7, "Surfboard B", "path/to/imageB.jpg", 7.0, 21.0, 2.85, 40.0, "Funboard", 649.99 },

             });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace surfs_up_project.Migrations
{
    /// <inheritdoc />
    public partial class NytId : Migration
    {

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "Products",
               columns: new[] { "ProductId", "Name", "ImagePath", "Length", "Width", "Thickness", "Volume", "Type", "Price" },
               values: new object[,]
               {
                    { 11, "Surfboard A", "path/to/imageA.jpg", 6.0, 20.5, 2.75, 35.0, "Shortboard", 599.99 },
                    { 13, "Surfboard B", "path/to/imageB.jpg", 7.0, 21.0, 2.85, 40.0, "Funboard", 649.99 },
                   // Add more seed data as needed
               });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

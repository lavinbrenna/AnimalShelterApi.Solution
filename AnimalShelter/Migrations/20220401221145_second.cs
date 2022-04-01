using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalShelter.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    AnimalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Gender = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Breed = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    AdmissionDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.AnimalId);
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "AdmissionDate", "Breed", "Gender", "Name", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ginger Tabby", "Male", "McCavity", "Cat" },
                    { 2, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sokoke", "Female", "Grizabella", "Cat" },
                    { 3, new DateTime(2022, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tuxedo", "Male", "Mr.Mistopholes", "Cat" },
                    { 4, new DateTime(2022, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bloodhound", "Male", "Hubert", "Dog" },
                    { 5, new DateTime(2022, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Terrier", "Female", "Winky", "Dog" },
                    { 6, new DateTime(2022, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Weimaraner", "Female", "Beatrice", "Dog" },
                    { 7, new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Syrian", "Male", "Hamtaro", "Hamster" },
                    { 8, new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roborovski", "Male", "Boss", "Hamster" },
                    { 9, new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Syrian", "Male", "Howdy", "Hamster" },
                    { 10, new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mini Satin", "Male", "Roger", "Rabbit" },
                    { 11, new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Netherland Dwarf", "Male", "Thumper", "Rabbit" },
                    { 12, new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lilac", "Male", "Bunnicula", "Rabbit" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");
        }
    }
}

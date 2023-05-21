using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SM.People.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PeopleIInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CellPhone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    PublicPlace = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    District = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true),
                    City = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true),
                    ZipCode = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: true),
                    State = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModfiedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    CorporateName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    FantasyName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    NRLE = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    StateRegistration = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    CellPhone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "longtext", nullable: true),
                    PublicPlace = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    District = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true),
                    City = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true),
                    ZipCode = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: true),
                    State = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModfiedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Supplier");
        }
    }
}

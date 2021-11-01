using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Data.Migrations
{
    public partial class PostgresInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    TKey = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    MiddleInitial = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    LastName = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EMail = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DriversLicenseNumber = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LocalTimezoneCreated = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "TimezoneInfo.Local.Id"),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LocalTimezoneUpdated = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "TimezoneInfo.Local.Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MId);
                });

            migrationBuilder.CreateTable(
                name: "ProductBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    AtId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    TKey = table.Column<Guid>(type: "uuid", nullable: false),
                    MId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    AName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    AGroup = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ALoc = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    AType = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    AFormat = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    ADesc = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    ACypher = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    Remarks = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Usage = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LocalTimezoneCreated = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "TimezoneInfo.Local.Id"),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LocalTimezoneUpdated = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "TimezoneInfo.Local.Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.AtId);
                    table.ForeignKey(
                        name: "FK_Attachments_Members_MId",
                        column: x => x.MId,
                        principalTable: "Members",
                        principalColumn: "MId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    PictureUrl = table.Column<string>(type: "text", nullable: false),
                    ProductTypeId = table.Column<int>(type: "integer", nullable: false),
                    ProductBrandId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductBrands_ProductBrandId",
                        column: x => x.ProductBrandId,
                        principalTable: "ProductBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_MId",
                table: "Attachments",
                column: "MId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_TKey",
                table: "Attachments",
                column: "TKey");

            migrationBuilder.CreateIndex(
                name: "IX_Members_TKey",
                table: "Members",
                column: "TKey");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductBrandId",
                table: "Products",
                column: "ProductBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products",
                column: "ProductTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "ProductBrands");

            migrationBuilder.DropTable(
                name: "ProductTypes");
        }
    }
}

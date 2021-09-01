using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    TKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    MiddleInitial = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DriversLicenseNumber = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LocalTimezoneCreated = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "TimezoneInfo.Local.Id"),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LocalTimezoneUpdated = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "TimezoneInfo.Local.Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MId);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    AtId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    TKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    AName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    AGroup = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ALoc = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    AType = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    AFormat = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ADesc = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    ACypher = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Usage = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LocalTimezoneCreated = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "TimezoneInfo.Local.Id"),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LocalTimezoneUpdated = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "TimezoneInfo.Local.Id")
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}

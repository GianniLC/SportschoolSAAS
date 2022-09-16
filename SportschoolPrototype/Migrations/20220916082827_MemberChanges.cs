using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportschoolPrototype.Migrations
{
    public partial class MemberChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimesLeft",
                table: "Member",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimesLeft",
                table: "Member");
        }
    }
}

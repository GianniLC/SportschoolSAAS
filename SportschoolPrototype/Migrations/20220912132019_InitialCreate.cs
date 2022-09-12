using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportschoolPrototype.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    typeOfStaff = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    coachId = table.Column<int>(type: "int", nullable: true),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubscriptionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Course_Staff_coachId",
                        column: x => x.coachId,
                        principalTable: "Staff",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subscriptionId = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Member_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Subscription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    courseID = table.Column<int>(type: "int", nullable: true),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    weeklyUses = table.Column<int>(type: "int", nullable: true),
                    duration = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscription_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_coachId",
                table: "Course",
                column: "coachId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_SubscriptionId",
                table: "Course",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Member_CourseID",
                table: "Member",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_MemberId",
                table: "Subscription",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Subscription_SubscriptionId",
                table: "Course",
                column: "SubscriptionId",
                principalTable: "Subscription",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Staff_coachId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Subscription_SubscriptionId",
                table: "Course");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Subscription");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Course");
        }
    }
}

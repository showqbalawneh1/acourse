using Microsoft.EntityFrameworkCore.Migrations;

namespace Acourse.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fields",
                columns: table => new
                {
                    fieldId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fname = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fields", x => x.fieldId);
                });

            migrationBuilder.CreateTable(
                name: "uesrs",
                columns: table => new
                {
                    userId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uesrs", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    courseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cname = table.Column<string>(nullable: false),
                    describtion = table.Column<string>(nullable: true),
                    fieldId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.courseId);
                    table.ForeignKey(
                        name: "FK_courses_fields_fieldId",
                        column: x => x.fieldId,
                        principalTable: "fields",
                        principalColumn: "fieldId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "fields",
                columns: new[] { "fieldId", "description", "fname" },
                values: new object[] { 2, "scienes fields", "scienes" });

            migrationBuilder.InsertData(
                table: "fields",
                columns: new[] { "fieldId", "description", "fname" },
                values: new object[] { 1, "it fields", "it" });

            migrationBuilder.InsertData(
                table: "fields",
                columns: new[] { "fieldId", "description", "fname" },
                values: new object[] { 3, "medicin fields", "medicin" });

            migrationBuilder.InsertData(
                table: "courses",
                columns: new[] { "courseId", "cname", "describtion", "fieldId" },
                values: new object[,]
                {
                    { 3, "physics", "this is a good course", 2 },
                    { 1, "c++", "this is a good course", 1 },
                    { 2, "java", "this is a good course java", 1 },
                    { 4, "dental lab", "this is a good course", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_courses_fieldId",
                table: "courses",
                column: "fieldId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "uesrs");

            migrationBuilder.DropTable(
                name: "fields");
        }
    }
}

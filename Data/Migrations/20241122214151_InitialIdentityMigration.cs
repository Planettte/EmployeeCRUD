using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorCrudApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialIdentityMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase(
                collation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeGovtID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    EmployeeName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Designation = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    HasDependents = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.AlterDatabase(
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");
        }
    }
}

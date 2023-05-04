using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tugas4.Migrations
{
    /// <inheritdoc />
    public partial class AddTableAccountsRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_M_Accounts",
                columns: table => new
                {
                    employee_nik = table.Column<string>(type: "char(5)", nullable: false),
                    password = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Accounts", x => x.employee_nik);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TB_TR_Account_Roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account_nik = table.Column<string>(type: "char(5)", nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TR_Account_Roles", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_M_Accounts");

            migrationBuilder.DropTable(
                name: "TB_M_Roles");

            migrationBuilder.DropTable(
                name: "TB_TR_Account_Roles");
        }
    }
}

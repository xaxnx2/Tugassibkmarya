using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tugas4.Migrations
{
    /// <inheritdoc />
    public partial class Relationcardinality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "role_id",
                table: "TB_TR_Account_Roles",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(11)");

            migrationBuilder.AlterColumn<int>(
                name: "university_id",
                table: "TB_M_Educations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_profilings_education_id",
                table: "tb_tr_profilings",
                column: "education_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_TR_Account_Roles_account_nik",
                table: "TB_TR_Account_Roles",
                column: "account_nik");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TR_Account_Roles_role_id",
                table: "TB_TR_Account_Roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Educations_university_id",
                table: "TB_M_Educations",
                column: "university_id");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_Accounts_tb_m_employees_employee_nik",
                table: "TB_M_Accounts",
                column: "employee_nik",
                principalTable: "tb_m_employees",
                principalColumn: "nik",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_Educations_TB_M_Universities_university_id",
                table: "TB_M_Educations",
                column: "university_id",
                principalTable: "TB_M_Universities",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_TR_Account_Roles_TB_M_Accounts_account_nik",
                table: "TB_TR_Account_Roles",
                column: "account_nik",
                principalTable: "TB_M_Accounts",
                principalColumn: "employee_nik",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_TR_Account_Roles_TB_M_Roles_role_id",
                table: "TB_TR_Account_Roles",
                column: "role_id",
                principalTable: "TB_M_Roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_profilings_TB_M_Educations_education_id",
                table: "tb_tr_profilings",
                column: "education_id",
                principalTable: "TB_M_Educations",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_profilings_tb_m_employees_employee_nik",
                table: "tb_tr_profilings",
                column: "employee_nik",
                principalTable: "tb_m_employees",
                principalColumn: "nik",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_Accounts_tb_m_employees_employee_nik",
                table: "TB_M_Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_Educations_TB_M_Universities_university_id",
                table: "TB_M_Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_TR_Account_Roles_TB_M_Accounts_account_nik",
                table: "TB_TR_Account_Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_TR_Account_Roles_TB_M_Roles_role_id",
                table: "TB_TR_Account_Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_profilings_TB_M_Educations_education_id",
                table: "tb_tr_profilings");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_profilings_tb_m_employees_employee_nik",
                table: "tb_tr_profilings");

            migrationBuilder.DropIndex(
                name: "IX_tb_tr_profilings_education_id",
                table: "tb_tr_profilings");

            migrationBuilder.DropIndex(
                name: "IX_TB_TR_Account_Roles_account_nik",
                table: "TB_TR_Account_Roles");

            migrationBuilder.DropIndex(
                name: "IX_TB_TR_Account_Roles_role_id",
                table: "TB_TR_Account_Roles");

            migrationBuilder.DropIndex(
                name: "IX_TB_M_Educations_university_id",
                table: "TB_M_Educations");

            migrationBuilder.AlterColumn<int>(
                name: "role_id",
                table: "TB_TR_Account_Roles",
                type: "int(11)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "university_id",
                table: "TB_M_Educations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}

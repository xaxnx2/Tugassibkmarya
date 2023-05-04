﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tugas6.Context;

#nullable disable

namespace Tugas4.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20230414031747_Relationcardinality")]
    partial class Relationcardinality
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tugas4.Models.Account", b =>
                {
                    b.Property<string>("employee_nik")
                        .HasColumnType("char(5)")
                        .HasColumnName("employee_nik");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password");

                    b.HasKey("employee_nik");

                    b.ToTable("TB_M_Accounts");
                });

            modelBuilder.Entity("Tugas4.Models.Accountrole", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("id"));

                    b.Property<string>("account_nik")
                        .IsRequired()
                        .HasColumnType("char(5)")
                        .HasColumnName("account_nik");

                    b.Property<int>("role_id")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.HasKey("id");

                    b.HasIndex("account_nik");

                    b.HasIndex("role_id");

                    b.ToTable("TB_TR_Account_Roles");
                });

            modelBuilder.Entity("Tugas4.Models.Education", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("degree")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasColumnName("degree");

                    b.Property<string>("gpa")
                        .IsRequired()
                        .HasColumnType("varchar(5)")
                        .HasColumnName("gpa");

                    b.Property<string>("major")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("major");

                    b.Property<int?>("universityid")
                        .HasColumnType("int")
                        .HasColumnName("university_id");

                    b.HasKey("id");

                    b.HasIndex("universityid");

                    b.ToTable("TB_M_Educations");
                });

            modelBuilder.Entity("Tugas4.Models.Employee", b =>
                {
                    b.Property<string>("NIK")
                        .HasColumnType("char(5)")
                        .HasColumnName("nik");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime")
                        .HasColumnName("birth_date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("first_name");

                    b.Property<int>("Gender")
                        .HasColumnType("int")
                        .HasColumnName("gender");

                    b.Property<DateTime>("HiringDate")
                        .HasColumnType("datetime")
                        .HasColumnName("hiring_date");

                    b.Property<string>("LastName")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("last_name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("phone_number");

                    b.HasKey("NIK");

                    b.ToTable("tb_m_employees");
                });

            modelBuilder.Entity("Tugas4.Models.Profiling", b =>
                {
                    b.Property<string>("EmployeeNIK")
                        .HasColumnType("char(5)")
                        .HasColumnName("employee_nik");

                    b.Property<int>("EducationId")
                        .HasColumnType("int")
                        .HasColumnName("education_id");

                    b.HasKey("EmployeeNIK");

                    b.HasIndex("EducationId")
                        .IsUnique();

                    b.ToTable("tb_tr_profilings");
                });

            modelBuilder.Entity("Tugas4.Models.Role", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("id");

                    b.ToTable("TB_M_Roles");
                });

            modelBuilder.Entity("Tugas4.Models.University", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Name");

                    b.HasKey("id");

                    b.ToTable("TB_M_Universities");
                });

            modelBuilder.Entity("Tugas4.Models.Account", b =>
                {
                    b.HasOne("Tugas4.Models.Employee", "Employee")
                        .WithOne("Account")
                        .HasForeignKey("Tugas4.Models.Account", "employee_nik")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Tugas4.Models.Accountrole", b =>
                {
                    b.HasOne("Tugas4.Models.Account", "Account")
                        .WithMany("Accountrole")
                        .HasForeignKey("account_nik")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Tugas4.Models.Role", "Role")
                        .WithMany("Accountrole")
                        .HasForeignKey("role_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Tugas4.Models.Education", b =>
                {
                    b.HasOne("Tugas4.Models.University", "University")
                        .WithMany("Educations")
                        .HasForeignKey("universityid")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("University");
                });

            modelBuilder.Entity("Tugas4.Models.Profiling", b =>
                {
                    b.HasOne("Tugas4.Models.Education", "Education")
                        .WithOne("Profiling")
                        .HasForeignKey("Tugas4.Models.Profiling", "EducationId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Tugas4.Models.Employee", "Employee")
                        .WithOne("Profiling")
                        .HasForeignKey("Tugas4.Models.Profiling", "EmployeeNIK")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Education");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Tugas4.Models.Account", b =>
                {
                    b.Navigation("Accountrole");
                });

            modelBuilder.Entity("Tugas4.Models.Education", b =>
                {
                    b.Navigation("Profiling")
                        .IsRequired();
                });

            modelBuilder.Entity("Tugas4.Models.Employee", b =>
                {
                    b.Navigation("Account")
                        .IsRequired();

                    b.Navigation("Profiling")
                        .IsRequired();
                });

            modelBuilder.Entity("Tugas4.Models.Role", b =>
                {
                    b.Navigation("Accountrole");
                });

            modelBuilder.Entity("Tugas4.Models.University", b =>
                {
                    b.Navigation("Educations");
                });
#pragma warning restore 612, 618
        }
    }
}
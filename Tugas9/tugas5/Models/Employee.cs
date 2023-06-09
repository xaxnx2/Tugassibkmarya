﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Tugas6.Models
{
    [Table("tb_m_employees")]
    public class Employee
    {


        [Key, Column("nik", TypeName = "char(5)")]
        public string NIK { get; set; }
        [Column("first_name", TypeName = "varchar(50)")]
        public string FirstName { get; set; }
        [Column("last_name", TypeName = "varchar(50)")]
        public string? LastName { get; set; }
        [Column("birth_date", TypeName = "datetime")]
        public DateTime BirthDate { get; set; }
        [Column("gender")]
        public Gender Gender { get; set; }
        [Column("hiring_date", TypeName = "datetime")]
        public DateTime HiringDate { get; set; }
        [Column("email", TypeName = "varchar(50)")]
        public string Email { get; set; }
        [Column("phone_number", TypeName = "varchar(50)")]
        public string PhoneNumber { get; set; }

        //cardinality
        [JsonIgnore]
        public Profiling? Profiling { get; set; }
        [JsonIgnore]
        public Account? Account { get; set; }
    }
    public enum Gender
    {
        Male,
        Female
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tugas4.Models
{

    [Table("tb_tr_profilings")]
    public class Profiling
    {
        [Key, Column("employee_nik", TypeName = "char(5)")]
        public string EmployeeNIK { get; set; }
        [Column("education_id")]
        public int EducationId { get; set; }
    }
}

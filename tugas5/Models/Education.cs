using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Tugas6.Models
{
    [Table("TB_M_Educations")]
    public class Education
    {
        [Key, Column("id")]
        public int id { get; set; }
        [Column("major", TypeName = "varchar(100)")]
        public string major { get; set; }
        [Column("degree", TypeName = "varchar(10)")]
        public string degree { get; set; }
        [Column("gpa", TypeName = "varchar(5)")]
        public string gpa { get; set; }
        [Column("university_id")]
        public int? universityid { get; set; }

        //cardinality
        [JsonIgnore]
        public University? University { get; set; }
        [JsonIgnore]
        public Profiling? Profiling { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tugas4.Models
{
    [Table("TB_M_Universities")]
    public class University
    {
        [Key, Column("id")]
        public int id { get; set; }
        [Column("Name", TypeName = "varchar(100)")]
        public string name { get; set; }

    }
}

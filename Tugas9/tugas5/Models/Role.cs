using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models
{
    [Table("TB_M_Roles")]
    public class Role
    {
        [Key, Column("id")]
        public int id { get; set; }
        [Column("name", TypeName = "varchar(50)")]
        public string name { get; set; }

        //cardinality
        [JsonIgnore]
        public ICollection<Accountrole>? Accountrole { get; set; }
    }
}

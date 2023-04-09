using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tugas4.Models
{
    [Table("TB_TR_Account_Roles")]
    public class Accountrole
    {
        [Key, Column("id")]
        public int id { get; set; }
        [Column("account_nik", TypeName = "char(5)")]
        public string account_nik { get; set; }
        [Column("role_id")]
        public int role_id { get; set; }
    }
}

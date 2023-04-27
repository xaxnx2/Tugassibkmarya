using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tugas4.Models
{
    [Table("TB_M_Accounts")]
    public class Account
    {
        [Key, Column("employee_nik", TypeName = "char(5)")]
        public string employee_nik { get; set; }
        [Column("password", TypeName = "varchar(255)")]
        public string password { get; set; }

        //cardinality
        public Employee Employee { get; set; }
        public ICollection<Accountrole> Accountrole { get; set; }

    }
}

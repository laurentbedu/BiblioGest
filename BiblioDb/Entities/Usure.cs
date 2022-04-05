using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioDb.Entities
{
    [Table("usure")]
    public partial class Usure
    {
        public Usure()
        {
            Exemplaires = new HashSet<Exemplaire>();
        }

        [Key]
        [Column("Id_usure")]
        public int IdUsure { get; set; }
        [Column("etat")]
        [StringLength(255)]
        [Unicode(false)]
        public string? Etat { get; set; }
        [Column("deleted")]
        public bool Deleted { get; set; }

        [InverseProperty("IdUsureNavigation")]
        public virtual ICollection<Exemplaire> Exemplaires { get; set; }
    }
}

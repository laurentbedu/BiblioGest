using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioDb.Entities
{
    [Table("editeur")]
    public partial class Editeur
    {
        public Editeur()
        {
            Exemplaires = new HashSet<Exemplaire>();
            Reservations = new HashSet<Reservation>();
        }

        [Key]
        [Column("Id_editeur")]
        public int IdEditeur { get; set; }
        [Column("nom")]
        [StringLength(255)]
        [Unicode(false)]
        public string? Nom { get; set; }
        [Column("deleted")]
        public bool Deleted { get; set; }

        [InverseProperty("IdEditeurNavigation")]
        public virtual ICollection<Exemplaire> Exemplaires { get; set; }
        [InverseProperty("IdEditeurNavigation")]
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioDb.Entities
{
    [Table("livre")]
    public partial class Livre
    {
        public Livre()
        {
            Exemplaires = new HashSet<Exemplaire>();
            Reservations = new HashSet<Reservation>();
            IdAuteurs = new HashSet<Auteur>();
            IdMotcles = new HashSet<Motcle>();
            IdThemes = new HashSet<Theme>();
        }

        [Key]
        [Column("Id_livre")]
        public int IdLivre { get; set; }
        [Column("titre")]
        [StringLength(255)]
        [Unicode(false)]
        public string? Titre { get; set; }
        [Column("isbn")]
        [StringLength(255)]
        [Unicode(false)]
        public string? Isbn { get; set; }
        [Column("deleted")]
        public bool Deleted { get; set; }

        [InverseProperty("IdLivreNavigation")]
        public virtual ICollection<Exemplaire> Exemplaires { get; set; }
        [InverseProperty("IdLivreNavigation")]
        public virtual ICollection<Reservation> Reservations { get; set; }

        [ForeignKey("IdLivre")]
        [InverseProperty("IdLivres")]
        public virtual ICollection<Auteur> IdAuteurs { get; set; }
        [ForeignKey("IdLivre")]
        [InverseProperty("IdLivres")]
        public virtual ICollection<Motcle> IdMotcles { get; set; }
        [ForeignKey("IdLivre")]
        [InverseProperty("IdLivres")]
        public virtual ICollection<Theme> IdThemes { get; set; }
    }
}

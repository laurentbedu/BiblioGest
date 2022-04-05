using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioDb.Entities
{
    [Table("exemplaire")]
    public partial class Exemplaire
    {
        public Exemplaire()
        {
            Emprunts = new HashSet<Emprunt>();
        }

        [Key]
        [Column("Id_exemplaire")]
        public int IdExemplaire { get; set; }
        [Column("date_achat", TypeName = "date")]
        public DateTime? DateAchat { get; set; }
        [Column("emplacement")]
        [StringLength(255)]
        [Unicode(false)]
        public string? Emplacement { get; set; }
        [Column("deleted")]
        public bool Deleted { get; set; }
        [Column("Id_editeur")]
        public int IdEditeur { get; set; }
        [Column("Id_usure")]
        public int IdUsure { get; set; }
        [Column("Id_livre")]
        public int IdLivre { get; set; }

        [ForeignKey("IdEditeur")]
        [InverseProperty("Exemplaires")]
        public virtual Editeur IdEditeurNavigation { get; set; } = null!;
        [ForeignKey("IdLivre")]
        [InverseProperty("Exemplaires")]
        public virtual Livre IdLivreNavigation { get; set; } = null!;
        [ForeignKey("IdUsure")]
        [InverseProperty("Exemplaires")]
        public virtual Usure IdUsureNavigation { get; set; } = null!;
        [InverseProperty("IdExemplaireNavigation")]
        public virtual ICollection<Emprunt> Emprunts { get; set; }
    }
}

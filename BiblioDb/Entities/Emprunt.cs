using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioDb.Entities
{
    [Table("emprunt")]
    public partial class Emprunt
    {
        [Key]
        [Column("Id_emprunt")]
        public int IdEmprunt { get; set; }
        [Column("date_sortie", TypeName = "date")]
        public DateTime? DateSortie { get; set; }
        [Column("date_retour", TypeName = "date")]
        public DateTime? DateRetour { get; set; }
        [Column("deleted")]
        public bool Deleted { get; set; }
        [Column("Id_exemplaire")]
        public int IdExemplaire { get; set; }
        [Column("Id_abonne")]
        public int IdAbonne { get; set; }

        [ForeignKey("IdAbonne")]
        [InverseProperty("Emprunts")]
        public virtual Abonne IdAbonneNavigation { get; set; } = null!;
        [ForeignKey("IdExemplaire")]
        [InverseProperty("Emprunts")]
        public virtual Exemplaire IdExemplaireNavigation { get; set; } = null!;
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioDb.Entities
{
    [Table("reservation")]
    public partial class Reservation
    {
        [Key]
        [Column("Id_reservation")]
        public int IdReservation { get; set; }
        [Column("date_reservation", TypeName = "date")]
        public DateTime? DateReservation { get; set; }
        [Column("deleted")]
        public bool Deleted { get; set; }
        [Column("Id_editeur")]
        public int? IdEditeur { get; set; }
        [Column("Id_livre")]
        public int IdLivre { get; set; }
        [Column("Id_abonne")]
        public int IdAbonne { get; set; }

        [ForeignKey("IdAbonne")]
        [InverseProperty("Reservations")]
        public virtual Abonne IdAbonneNavigation { get; set; } = null!;
        [ForeignKey("IdEditeur")]
        [InverseProperty("Reservations")]
        public virtual Editeur? IdEditeurNavigation { get; set; }
        [ForeignKey("IdLivre")]
        [InverseProperty("Reservations")]
        public virtual Livre IdLivreNavigation { get; set; } = null!;
    }
}

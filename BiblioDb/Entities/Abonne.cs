using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioDb.Entities
{
    [Table("abonne")]
    [Index("Email", Name = "UQ__abonne__AB6E6164154836A2", IsUnique = true)]
    public partial class Abonne
    {
        public Abonne()
        {
            Emprunts = new HashSet<Emprunt>();
            Reservations = new HashSet<Reservation>();
        }

        [Key]
        [Column("Id_abonne")]
        public int IdAbonne { get; set; }
        [Column("nom")]
        [StringLength(255)]
        [Unicode(false)]
        public string? Nom { get; set; }
        [Column("prenom")]
        [StringLength(255)]
        [Unicode(false)]
        public string? Prenom { get; set; }
        [Column("adresse")]
        [StringLength(255)]
        [Unicode(false)]
        public string? Adresse { get; set; }
        [Column("date_adhesion", TypeName = "date")]
        public DateTime? DateAdhesion { get; set; }
        [Column("matricule")]
        [StringLength(255)]
        [Unicode(false)]
        public string? Matricule { get; set; }
        [Column("telephone")]
        [StringLength(255)]
        [Unicode(false)]
        public string? Telephone { get; set; }
        [Column("date_naissance", TypeName = "date")]
        public DateTime? DateNaissance { get; set; }
        [Column("email")]
        [StringLength(255)]
        [Unicode(false)]
        public string? Email { get; set; }
        [Column("password")]
        [StringLength(255)]
        [Unicode(false)]
        public string? Password { get; set; }
        [Column("deleted")]
        public bool Deleted { get; set; }
        [Column("Id_categorie")]
        public int IdCategorie { get; set; }

        [ForeignKey("IdCategorie")]
        [InverseProperty("Abonnes")]
        public virtual Categorie IdCategorieNavigation { get; set; } = null!;
        [InverseProperty("IdAbonneNavigation")]
        public virtual ICollection<Emprunt> Emprunts { get; set; }
        [InverseProperty("IdAbonneNavigation")]
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}

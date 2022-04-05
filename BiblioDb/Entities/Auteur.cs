using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioDb.Entities
{
    [Table("auteur")]
    public partial class Auteur
    {
        public Auteur()
        {
            IdLivres = new HashSet<Livre>();
        }

        [Key]
        [Column("Id_auteur")]
        public int IdAuteur { get; set; }
        [Column("nom")]
        [StringLength(255)]
        [Unicode(false)]
        public string? Nom { get; set; }
        [Column("prenom")]
        [StringLength(255)]
        [Unicode(false)]
        public string? Prenom { get; set; }
        [Column("deleted")]
        public bool Deleted { get; set; }

        [ForeignKey("IdAuteur")]
        [InverseProperty("IdAuteurs")]
        public virtual ICollection<Livre> IdLivres { get; set; }
    }
}

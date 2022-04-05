using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioDb.Entities
{
    [Table("categorie")]
    public partial class Categorie
    {
        public Categorie()
        {
            Abonnes = new HashSet<Abonne>();
        }

        [Key]
        [Column("Id_categorie")]
        public int IdCategorie { get; set; }
        [Column("titre")]
        [StringLength(255)]
        [Unicode(false)]
        public string? Titre { get; set; }
        [Column("deleted")]
        public bool Deleted { get; set; }

        [InverseProperty("IdCategorieNavigation")]
        public virtual ICollection<Abonne> Abonnes { get; set; }
    }
}

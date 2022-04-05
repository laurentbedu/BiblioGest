using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioDb.Entities
{
    [Table("motcle")]
    public partial class Motcle
    {
        public Motcle()
        {
            IdLivres = new HashSet<Livre>();
        }

        [Key]
        [Column("Id_motcle")]
        public int IdMotcle { get; set; }
        [Column("mot")]
        [StringLength(255)]
        [Unicode(false)]
        public string? Mot { get; set; }
        [Column("deleted")]
        public bool Deleted { get; set; }

        [ForeignKey("IdMotcle")]
        [InverseProperty("IdMotcles")]
        public virtual ICollection<Livre> IdLivres { get; set; }
    }
}

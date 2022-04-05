using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioDb.Entities
{
    [Table("theme")]
    public partial class Theme
    {
        public Theme()
        {
            IdLivres = new HashSet<Livre>();
        }

        [Key]
        [Column("Id_theme")]
        public int IdTheme { get; set; }
        [Column("titre")]
        [StringLength(255)]
        [Unicode(false)]
        public string? Titre { get; set; }
        [Column("deleted")]
        public bool Deleted { get; set; }

        [ForeignKey("IdTheme")]
        [InverseProperty("IdThemes")]
        public virtual ICollection<Livre> IdLivres { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppSolid.Models.Entities
{
    public class ArticleEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Body { get; set; } = null!;

        public DateTime Published { get; set; }

        public bool IsPublished { get; set; }

        public string Author { get; set; } = null!;
        public string Category { get; set; } = null!;

    }
}

using AppSolid.Models.Entities;

namespace AppSolid.Models.Dtos
{
    public class ArticleResponse : ArticleEntity
    {
        public string Title { get; set; } = null!;
        public string Body { get; set; } = null!;
        public DateTime Published { get; set; }
        public bool IsPublished { get; set; }
        public string Author { get; set; } = null!;
        public string Category { get; set; } = null!;

        public string Succeeded { get; set; } = "Det gick bra";
    }
}

using AppSolid.Models.Entities;

namespace AppSolid.Models.Dtos
{
    public class ArticleRequest : ArticleEntity 
    {
        public string Title { get; set; } = null!;
        public string Body { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Category { get; set; } = null!;
        


    }
}

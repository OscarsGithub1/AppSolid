using AppSolid.Models.Dtos;
using AppSolid.Models.Entities;

namespace WebApplication8.Factory
{




    public static class ArticleRequestFactory
    {
        public static ArticleEntity CreateArticle(ArticleRequest request)
        {
            var article = new ArticleEntity
            {
                Title = request.Title,
                Body = request.Body,
                Author = request.Author,
                Id = request.Id,
                IsPublished = request.IsPublished,
                Published = request.Published,



            };

            // Set any other properties or perform additional operations on the article as needed

            return article;
        }
    }

}

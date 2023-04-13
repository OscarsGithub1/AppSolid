using AppSolid.Models.Dtos;
using System.Collections.Generic;
using AppSolid.Models.Dtos; 
using AppSolid.Models.Dtos;

namespace WebApplication8.Repositories
{
    public interface IArticleRepository
    {
        void Add(ArticleRequest request);
        ArticleResponse GetById(int id);
        IEnumerable<ArticleResponse> GetAll();
        IEnumerable<ArticleResponse> GetAllPublished();
        IEnumerable<ArticleResponse> GetAllUnpublished();
        void Update(int id, ArticleRequest request);
        void Delete(int id);
    }
}

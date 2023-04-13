using System;
using System.Collections.Generic;
using System.Linq;
using AppSolid.Contexts;
using AppSolid.Models.Dtos;
using AppSolid.Models.Entities;
using WebApplication8.Factory;
using AppSolid.Models.Dtos;
using AppSolid.Contexts;
using AppSolid.Models.Dtos;

namespace WebApplication8.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly DataContext _context;

        public ArticleRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(ArticleRequest request)
        {
            var article = ArticleRequestFactory.CreateArticle(request);
            _context.Article.Add(article);
            _context.SaveChanges();
        }

        public ArticleResponse GetById(int id)
        {
            var article = _context.Article.FirstOrDefault(a => a.Id == id);

            if (article == null)
            {
                return null;
            }

            var response = new ArticleResponse
            {
                Id = article.Id,
                Title = article.Title,
                Body = article.Body,
                Author = article.Author,
                Published = article.Published,
                IsPublished = article.IsPublished
            };

            return response;
        }

        public IEnumerable<ArticleResponse> GetAll()
        {
            var articles = _context.Article.ToList();

            var response = articles.Select(article => new ArticleResponse
            {
                Id = article.Id,
                Title = article.Title,
                Body = article.Body,
                Author = article.Author,
                Published = article.Published,
                IsPublished = article.IsPublished
            });

            return response;
        }

        public void Update(int id, ArticleRequest request)
        {
            var article = _context.Article.FirstOrDefault(a => a.Id == id);

            if (article == null)
            {
                return;
            }

            article.Title = request.Title;
            article.Body = request.Body;
            article.Author = request.Author;
            article.Published = request.Published;
            article.IsPublished = request.IsPublished;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var article = _context.Article.FirstOrDefault(a => a.Id == id);

            if (article == null)
            {
                return;
            }

            _context.Article.Remove(article);
            _context.SaveChanges();
        }

        public IEnumerable<ArticleResponse> GetAllPublished()
        {
            var articles = _context.Article.Where(a => a.IsPublished).ToList();

            var response = articles.Select(article => new ArticleResponse
            {
                Id = article.Id,
                Title = article.Title,
                Body = article.Body,
                Author = article.Author,
                Published = article.Published,
                IsPublished = article.IsPublished
            });

            return response;
        }

        public IEnumerable<ArticleResponse> GetAllUnpublished()
        {
            var articles = _context.Article.Where(a => !a.IsPublished).ToList();

            var response = articles.Select(article => new ArticleResponse
            {
                Id = article.Id,
                Title = article.Title,
                Body = article.Body,
                Author = article.Author,
                Published = article.Published,
                IsPublished = article.IsPublished
            });

            return response;
        }
    }
}
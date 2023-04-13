using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppSolid.Contexts;
using AppSolid.Models.Dtos;
using AppSolid.Models.Entities;
using AppSolid.Factory;
using AppSolid.Models.Dtos;
using AppSolid.Contexts;
using AppSolid.Models.Dtos;
using WebApplication8.Factory;

namespace WebApplication8.Controllers
{
   // [Route("api/[controller]")]
 //   [ApiController]
    public class ArticleService : ControllerBase
    {
        private readonly DataContext _context;

        public ArticleService(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(ArticleRequest request)
        {
            var article = ArticleRequestFactory.CreateArticle(request);
            _context.Article.Add(article);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = article.Id }, article);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var article = _context.Article.FirstOrDefault(a => a.Id == id);

            if (article == null)
            {
                return NotFound();
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

            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetAll()
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
            }).ToList();

            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ArticleRequest request)
        {
            var article = _context.Article.FirstOrDefault(a => a.Id == id);

            if (article == null)
            {
                return NotFound();
            }

            article.Title = request.Title;
            article.Body = request.Body;
            article.Author = request.Author;
            article.Published = request.Published;
            article.IsPublished = request.IsPublished;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var article = _context.Article.FirstOrDefault(a => a.Id == id);

            if (article == null)
            {
                return NotFound();
            }

            _context.Article.Remove(article);
            _context.SaveChanges();

            return NoContent();
        }

    }
}

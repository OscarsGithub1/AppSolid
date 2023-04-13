using Microsoft.AspNetCore.Mvc;
using AppSolid.Models.Dtos;
using AppSolid.Models.Entities;
using AppSolid.Contexts;


namespace WebApplication8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly ArticleService _articleService;

        public ArticlesController(DataContext context)
        {
            _articleService = new ArticleService(context);
        }

        [HttpPost]

        //ArticleRequest
        public IActionResult CreateArticle(ArticleRequest request)
        {
            var result = _articleService.Create(request);

            if (result == null)
            {
                return BadRequest();
            }

       /*Kan vara fel */    return CreatedAtAction(nameof(GetArticle), new { result = request.Id }, result);
        }

        [HttpGet("{id}")]
        public IActionResult GetArticle(int id)
        {
            var result = _articleService.Get(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllArticles()
        {
            var result = _articleService.GetAll();

            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateArticle(int id, ArticleRequest request)
        {
            var result = _articleService.Update(id, request);

            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteArticle(int id)
        {
            var result = _articleService.Delete(id);

            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
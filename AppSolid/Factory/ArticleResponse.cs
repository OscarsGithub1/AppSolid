using AppSolid.Models.Dtos;
using AppSolid.Models.Dtos;


public static class ArticleResponseFactory
{
    public static ArticleResponse CreateArticleResponse(string title, string body, DateTime published, bool ispublished, string author)
    {
        // Create a new instance of ArticleResponse
        var articleResponse = new ArticleResponse();

        // Set the properties of the ArticleResponse object
        articleResponse.Title = title;
        articleResponse.Body = body;
        articleResponse.IsPublished = ispublished;
        articleResponse.Published = published;
        articleResponse.Author = author;


        // Return the ArticleResponse object
        return articleResponse;


        //


        //
    }
}
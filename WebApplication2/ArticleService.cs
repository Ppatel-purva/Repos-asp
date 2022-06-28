using Microsoft.EntityFrameworkCore;

namespace WebApplication_empty_minimul
{
    public class ArticleService:IArticleService
    {
        public readonly ApiContext _context;

        public ArticleService (ApiContext contaxt)
        {
            _context = contaxt;
        }
        public async Task<IResult> GetArticles()
        {

            return Results.Ok(await _context.Articles.ToListAsync());
        }
        public async Task<IResult> GetArticlesById(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            return article!=null?Results.Ok(article):Results.NotFound();
        }
        public async Task<IResult> CreateArticle(ArticleRequest articleRequest)
        {
            var createArticle = _context.Articles.Add(new Article
            {
                Title = articleRequest.Title?? String.Empty,
                Contact = articleRequest.Contact?? String.Empty,
                PublishedAt= articleRequest.Public
            });
        }
        
        //GetArticle() { }
        //GetArticleById() { }

    }
}

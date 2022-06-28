
namespace WebApplication_empty_minimul
{
    public class IArticleService
    {
        Task<IResult> GetArticles();

        Task<IResult> GetArticlesById(int id);

        Task<IResult> CreateArticale( ArticleRequest artical);


        Task<IResult> UpdateArticle(int id, ArticleRequest article);

        Task<IResult> DeleteArticle(int id);

         
    }
}

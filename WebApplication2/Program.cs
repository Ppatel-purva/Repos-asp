using Microsoft.EntityFrameworkCore;
using WebApplication_empty_minimul;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApiContext> (opt => opt.UseInMemoryDatabase("api"));
builder.Services.AddScoped<ArticleService, ArticleService>();


var app =builder.Build();

app.MapGet("/articles", async (ArticleService articleService) => await articleService.GetArticles());
app.MapGet("/articles/{id}", async (int id,ArticleService articleService) => await articleService.GetArticlesById(id));
app.MapGet("/articles", async (ArticleRequest articleRequest,ArticleService articleServices) => await articleService.CreateArticle(articleRequest));
app.MapGet("/articles/{id}", async (int id, ArticleRequest, arteicleRequest,ArticleService articleServices) => await articleService.UpdateArticle(id,articleRequest));
app.MapGet("/articles/{id}", async (int id, ArticleService, arteicleService, ArticleService articleServices) => await articleService.DeleteArticle(id));
//app.MapGet("/", () => MyHendler.Hello());

//app.MapGet ("/sum", (int? n1 ,int? n2) => 
//{ 
//    n1 = 10; 
//    n2 = 20;
//   return n1 + n2; 
//});

//app.MapGet("/sum{n1}/{n2}", (int? n1, int? n2) => n1 + n2);

//app.Urls.Add("https://localhost:3000");
//app.Urls.Add("https://localhost:5000");

app.Run();

//class MyHendler
//{
//    public static string Hello()
//    {
 //       return "hello purva";
 //   }
//}

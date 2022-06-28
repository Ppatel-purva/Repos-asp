using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Admin_detail.Data;
using Admin_detail;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Admin_detailContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Admin_detailContext")));
var app = builder.Build();

app.MapGet("/admin_details", async (Admin_detailContext myadmin) =>
{
    var admin =await myadmin.Admin.ToListAsync();
    return Results.Ok(admin);
});

app.MapGet("/admin_details{id}", async (Admin_detailContext myadmin, int id) =>
{
    var admin = await myadmin.Admin.FindAsync();
    return Results.Ok(admin);
});
app.MapPost("/admin_details/create", async (Admin Admin,Admin_detailContext myadmin) =>
     {
         myadmin.Admin.Add(Admin);
         await myadmin.SaveChangesAsync();
         return Results.Ok();
     });

app.MapPut("/admin_details/update", async (Admin Admin, Admin_detailContext myadmin) =>
 {
        var update = await myadmin.Admin.FindAsync(Admin.Id);
        if(update == null)
        {
         return Results.NotFound();
        }
     update.admin_first_name = Admin.admin_first_name;
     update.admin_last_name = Admin.admin_last_name;
     update.admin_password = Admin.admin_password;
     update.admin_token =Admin.admin_token;
     update.admin_id = Admin.admin_id;
     await myadmin.SaveChangesAsync();
     return Results.NoContent();
     
 });

app.MapDelete("/admin/delete/{id}", async (Admin_detailContext myadmin, int id) =>
{
   var delAdmin = await myadmin.Admin.FindAsync(id);
    if (delAdmin == null) 
    {
        return Results.NoContent();
    }
    myadmin.Admin.Remove(delAdmin);
    await myadmin.SaveChangesAsync();
    return Results.Ok();
});
    

app.Run();

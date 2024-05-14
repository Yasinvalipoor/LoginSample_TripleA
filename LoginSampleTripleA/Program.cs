using LoginSampleTripleA.infra;
using LoginSampleTripleA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<LoginDbContext>(c=>c.UseSqlServer(builder.Configuration.GetConnectionString("LoginDbCnn")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>(c =>
{
    // شخصی سازی پسوورد - 1  
    //------------------
    //c.Password.RequiredLength = 4;
    //c.Password.RequiredUniqueChars = 2;
    //c.Password.RequireNonAlphanumeric = false;
    //c.Password.RequireUppercase = false;
    //c.Password.RequireLowercase = false;
    //c.Password.RequireDigit = false;
    //------------------
}).AddEntityFrameworkStores<LoginDbContext>().AddUserValidator<CustomUserValidator>();
//.AddPasswordValidator<UserNamePasswordValidator>();// شخصی سازی پسوورد - 2  



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.MapRazorPages();

app.MapDefaultControllerRoute();



app.Run();

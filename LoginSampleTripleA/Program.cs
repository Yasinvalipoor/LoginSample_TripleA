using LoginSampleTripleA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<LoginDbContext>(c=>c.UseSqlServer(builder.Configuration.GetConnectionString("LoginDbCnn")));
builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<LoginDbContext>();

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

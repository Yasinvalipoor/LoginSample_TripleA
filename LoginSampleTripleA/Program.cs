﻿using LoginSampleTripleA.infra;
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
}).AddEntityFrameworkStores<LoginDbContext>();
//.AddUserValidator<CustomUserValidator>(); // شخصی سازی ایمیل کاربری
//.AddPasswordValidator<UserNamePasswordValidator>();// شخصی سازی پسوورد - 2  

builder.Services.AddAuthorization(c =>
{
    c.AddPolicy("IsAdmin", pb =>
    {
        pb.RequireRole("Admin").RequireClaim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", "Mohamad","Shayan");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.MapRazorPages();

app.UseAuthentication();

app.UseAuthorization(); //Use After app.UseAuthentication();

app.MapDefaultControllerRoute();



app.Run();

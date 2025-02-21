using MenuGraphQl_API.Database;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System;
using MenuGraphQl_API.Querys;
using MenuGraphQl_API.Mutations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(config =>
{
    config.UseSqlite("Data Source=Database\\menuGraphQl.db");
});

builder.Services.AddGraphQLServer().AddQueryType<MenuQuery>()
                                   .AddMutationType<MenuMutation>()
                                   .AddProjections()
                                   .AddFiltering()
                                   .AddSorting();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGraphQL("/graphql");

app.Run();

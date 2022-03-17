using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stefanini_API.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseCors(MyAllowSpecificOrigins);

#region PESSOA-API
app.MapGet("/pessoas/", async () =>
{
    AppDbContext dbContext = new();
    return await dbContext.Pessoas.ToListAsync();
});

app.MapGet("/pessoas/{id}", async (int id) =>
{
    AppDbContext dbContext = new();
    return await dbContext.Pessoas.FirstOrDefaultAsync(p => p.Id == id);
});

app.MapPost("/pessoas", async (Pessoa pessoa) =>
{
    AppDbContext dbContext = new();
    dbContext.Pessoas.Add(pessoa);
    await dbContext.SaveChangesAsync();

    return pessoa;
});

app.MapPut("/pessoas/{id}", async (int id, Pessoa pessoaUpdt) =>
{
    AppDbContext dbContext = new();
    var pessoa = await dbContext.Pessoas.FirstOrDefaultAsync(p => p.Id == id);

    pessoa.Cpf = pessoaUpdt.Cpf;
    pessoa.Nome = pessoaUpdt.Nome;
    pessoa.Idade = pessoaUpdt.Idade;
    pessoa.IdCidade = pessoaUpdt.IdCidade;

    await dbContext.SaveChangesAsync();

    return pessoa;
});

app.MapDelete("pessoas/{id}", async (int id) =>
{
    AppDbContext dbContext = new();
    var pessoa = await dbContext.Pessoas.FirstOrDefaultAsync(p => p.Id == id);

    if(pessoa != null)
    {
        dbContext.Pessoas.Remove(pessoa);
        await dbContext.SaveChangesAsync();
    }
});
#endregion

#region CIDADE-API
app.MapGet("/cidades/", async () =>
{
    AppDbContext dbContext = new();
    return await dbContext.Cidades.ToListAsync();
});

app.MapGet("/cidades/{id}", async (int id) =>
{
    AppDbContext dbContext = new();
    return await dbContext.Cidades.FirstOrDefaultAsync(p => p.Id == id);
});

app.MapPost("/cidades", async (Cidade cidade) =>
{
    AppDbContext dbContext = new();
    dbContext.Cidades.Add(cidade);
    await dbContext.SaveChangesAsync();

    return cidade;
});

app.MapPut("/cidades/{id}", async (int id, Cidade cidadeUpdt) =>
{
    AppDbContext dbContext = new();
    var cidade = await dbContext.Cidades.FirstOrDefaultAsync(p => p.Id == id);

    cidade.Nome = cidadeUpdt.Nome;
    cidade.Uf = cidadeUpdt.Uf;

    await dbContext.SaveChangesAsync();

    return cidade;
});

app.MapDelete("cidades/{id}", async (int id) =>
{
    AppDbContext dbContext = new();
    var cidade = await dbContext.Cidades.FirstOrDefaultAsync(p => p.Id == id);

    if (cidade != null)
    {
        dbContext.Cidades.Remove(cidade);
        await dbContext.SaveChangesAsync();
    }
});
#endregion


app.Run();

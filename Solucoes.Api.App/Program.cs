using Microsoft.EntityFrameworkCore;
using Solucoes.Api.App.Contexto;
using Solucoes.Api.Mapper;
using Solucoes.Api.Repositorios;
using Solucoes.Api.Service.Cadastro;
using Solucoes.Api.Service.Movimentacao;
using Solucoes.Modelo.Contexto;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.EnableSensitiveDataLogging();
});

builder.Services.AddTransient<AppDbContextFactory>();
builder.Services.AddTransient(opt => opt.GetService<AppDbContextFactory>().CreateDbContext());

builder.Services.AddTransient<UsuarioRepositorio>();
builder.Services.AddTransient<SetorEmpresaRepositorio>();
builder.Services.AddTransient<ReuniaoRepositorio>();
builder.Services.AddTransient<ReuniaoItemRepositorio>();
builder.Services.AddTransient<PlataformaRepositorio>();
builder.Services.AddTransient<PessoaRepositorio>();
//builder.Services.AddTransient<LogMovimentacaoRepositorio>();
builder.Services.AddTransient<EnderecoRepositorio>();
builder.Services.AddTransient<EmpresaRepositorio>();
builder.Services.AddTransient<ContatoRepositorio>();
builder.Services.AddTransient<ChamadoItemRepositorio>();
builder.Services.AddTransient<ChamadoRepositorio>();

builder.Services.AddTransient<UsuarioService>();
builder.Services.AddTransient<PlataformaService>();
builder.Services.AddTransient<SetorEmpresaService>();
//builder.Services.AddTransient<LogMovimentacaoService>();
builder.Services.AddTransient<PessoaService>();
builder.Services.AddTransient<EmpresaService>();
builder.Services.AddTransient<ContatoService>();
builder.Services.AddTransient<EnderecoService>();



builder.Services.AddTransient<Mapper>();

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

app.Run();

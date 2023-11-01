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
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "SolucoesAPI", Version = "v1"});

});

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.EnableSensitiveDataLogging();
});

builder.Services.AddTransient<AppDbContextFactory>();
builder.Services.AddTransient(opt => opt.GetService<AppDbContextFactory>().CreateDbContext());


/*Repositorios*/

builder.Services.AddTransient<ContatoRepositorio>();
builder.Services.AddTransient<EmpresaRepositorio>();
builder.Services.AddTransient<EnderecoRepositorio>();
builder.Services.AddTransient<PessoaRepositorio>();
builder.Services.AddTransient<PessoaEmpresaRepositorio>();
builder.Services.AddTransient<PlataformaRepositorio>();
builder.Services.AddTransient<SetorEmpresaRepositorio>();
builder.Services.AddTransient<TicketAcaoRepositorio>();
builder.Services.AddTransient<TicketRepositorio>();
builder.Services.AddTransient<UsuarioRepositorio>();
builder.Services.AddTransient<TicketAgrupamentoRepositorio>();
builder.Services.AddTransient<TicketRelacionamentoRepositorio>();

//builder.Services.AddTransient<LogMovimentacaoRepositorio>();


/*Services*/

builder.Services.AddTransient<UsuarioService>();
builder.Services.AddTransient<PlataformaService>();
builder.Services.AddTransient<SetorService>();
//builder.Services.AddTransient<LogMovimentacaoService>();
builder.Services.AddTransient<PessoaService>();
builder.Services.AddTransient<EmpresaService>();
builder.Services.AddTransient<ContatoService>();
builder.Services.AddTransient<EnderecoService>();
builder.Services.AddTransient<UsuarioService>();
builder.Services.AddTransient<TicketAcaoMovService>();
builder.Services.AddTransient<TicketMovService>();
builder.Services.AddTransient<TicketAgrupamentoMovService>();
builder.Services.AddTransient<TicketRelacionamentoMovService>();



builder.Services.AddTransient<Mapper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opt =>
    {
        opt.SwaggerEndpoint("/swagger/v1/swagger.json", "SolucoesAPI v1");
        opt.RoutePrefix = String.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

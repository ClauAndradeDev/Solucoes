using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Solucoes.Api.App.Contexto;
using Solucoes.Api.Mapper;
using Solucoes.Api.Repositorios;
using Solucoes.Api.Service.Cadastro;
using Solucoes.Api.Service.Movimentacao;
using Solucoes.Modelo.Contexto;
using System.Text;

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

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true, // Defina como true se desejar validar o emissor (issuer)
            ValidateAudience = true, // Defina como true se desejar validar a audiência
            ValidateLifetime = true, // Defina como true se desejar validar a validade do token
            ValidateIssuerSigningKey = true, // Defina como true se desejar validar a chave de assinatura
            ValidIssuer = "solucoes_issuer",
            ValidAudience = "solucoes_audience",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("c2157d46fa4cb606e924ab1d1e0e1d5b868adf9a8d690fd41820fa8433e475b4"))
        };
    });

/*Repositorios*/

builder.Services.AddTransient<ContatoRepositorio>();
builder.Services.AddTransient<EmpresaRepositorio>();
builder.Services.AddTransient<EnderecoRepositorio>();
builder.Services.AddTransient<PessoaRepositorio>();
builder.Services.AddTransient<PessoaEmpresaRepositorio>();
builder.Services.AddTransient<PlataformaRepositorio>();
builder.Services.AddTransient<SetorRepositorio>();
builder.Services.AddTransient<TicketAcaoRepositorio>();
builder.Services.AddTransient<TicketRepositorio>();
builder.Services.AddTransient<UsuarioRepositorio>();
builder.Services.AddTransient<TicketAgrupamentoRepositorio>();
builder.Services.AddTransient<TicketRelacionamentoRepositorio>();
builder.Services.AddTransient<ReuniaoRepositorio>();
builder.Services.AddTransient<ReuniaoAcaoRepositorio>();

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
builder.Services.AddTransient<TicketAcaoService>();
builder.Services.AddTransient<TicketService>();
builder.Services.AddTransient<TicketAgrupamentoService>();
builder.Services.AddTransient<TicketRelacionamentoService>();
builder.Services.AddTransient<ReuniaoService>();
builder.Services.AddTransient<ReuniaoAcaoService>();



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

var devCliente = "http://localhost:4200";
app.UseCors(x => 
x.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()
.WithOrigins(devCliente));

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

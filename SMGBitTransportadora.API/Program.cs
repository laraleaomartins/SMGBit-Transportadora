using Microsoft.EntityFrameworkCore;
using SMGBitTransportadora.Aplicacao.Interfaces;
using SMGBitTransportadora.Aplicacao.Servicos;
using SMGBitTransportadora.Infra.Contexto;
using SMGBitTransportadora.Infra.Repositorio.Interfaces;
using SMGBitTransportadora.Infra.Repositorio.Mapeamento;
using SMGBitTransportadora.Infra.Repositorio.Servicos;
using SMGBitTransportadora.Servico.Interfaces;
using SMGBitTransportadora.Servico.Servicos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TransportadoraContexto>(x => x.UseSqlServer("Persist Security Info=False;Integrated Security=true;Initial Catalog=Planilhas;server=(local);TrustServerCertificate=True"));
builder.Services.AddScoped<IBaixarTabelaServico, BaixarTabelaServico>();
builder.Services.AddScoped<ISalvarTabelaServico, SalvarTabelaServico>();
builder.Services.AddScoped<ITransportadoraServico, TransportadoraServico>();
builder.Services.AddScoped<ITransportadoraServicoCliente, TransportadoraServicoCliente>();
builder.Services.AddScoped<ICalcularFreteServico, CalcularFreteServico>();
builder.Services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
builder.Services.AddAutoMapper(typeof(ConfiguracaoMapeamento));


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

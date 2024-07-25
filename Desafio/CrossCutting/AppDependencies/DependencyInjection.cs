using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Domain.Commands.Pedidos;
using Domain.Commands.Pedidos.Adicionar;
using Domain.Commands.Pedidos.Alterar;
using Domain.Commands.Pedidos.Excluir;
using Domain.Interfaces;
using Domain.Shared;
using FluentValidation;
using Infra.Context;
using Infra.Queries;
using Infra.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.AppDependencies;

public static class DependencyInjection
{
    public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
    {
           services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IPedidoRepository, PedidoRepository>();

        services.AddScoped<IPedidoService, PedidoService>();

        var myHandlers = AppDomain.CurrentDomain.Load("Domain");
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(myHandlers));

        services.AddAutoMapper(typeof(DependencyInjection).Assembly);
        services.AddAutoMapper(typeof(PedidoProfile));

        services.AddScoped<IPedidoQuery, PedidoQuery>();

        services.AddScoped<IRequestHandler<AdicionarPedidoCommand, Response<PedidoCommand>>, AdicionarPedidoCommandHandler>();
        services.AddTransient<IValidator<AdicionarPedidoCommand>, AdicionarPedidoCommandValidator>();
        services.AddTransient<IValidator<ItemCommand>, ItemCommandValidator>();

        services.AddScoped<IRequestHandler<ExcluirPedidoCommand, Response<PedidoCommand>>, ExcluirPedidoCommandHandler>();
        services.AddTransient<IValidator<ExcluirPedidoCommand>, ExcluirPedidoCommandValidator>();

        services.AddScoped<IRequestHandler<AlterarPedidoCommand, Response<PedidoCommand>>, AlterarPedidoCommandHandler>();
        services.AddTransient<IValidator<AlterarPedidoCommand>, AlterarPedidoCommandValidator>();
      
       
        return services;
    }
    
}

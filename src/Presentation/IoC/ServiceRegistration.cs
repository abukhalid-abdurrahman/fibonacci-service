using Entity.Configs;
using Microsoft.Extensions.Options;
using UseCase.Abstraction.FibonacciSubsequence;
using UseCase.Implementation.FibonacciSubsequence;
using Repository.Implementation.FibonacciSubsequence;
using Repository.Abstraction.FibonacciSubsequence;
using FluentValidation;
using Entity.DTO.FibonacciSubsequence;
using Entity.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;

namespace Presentation.IoC;

public static class ServiceRegistration
{
    public static void RegisterService(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IFibonacciSubsequenceFromCacheUseCase, FibonacciSubsequenceFromCacheInteractor>();
        builder.Services.AddTransient<IFibonacciSubsequenceGeneratorUseCase, FibonacciSubsequenceGeneratorInteractor>();
        builder.Services.AddTransient<IFibonacciSubsequenceProviderUseCase, FibonacciSubsequenceProviderInteractor>();
        builder.Services.AddTransient<IFibonacciSubsequenceRepository, FibonacciSubsequenceRepository>();
    }

    public static void RegisterConfigs(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<DistributedCacheOption>(builder.Configuration.GetSection("DistributedCache"));
        builder.Services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<DistributedCacheOption>>().Value);
    }

    public static void RegisterDistributedCache(this WebApplicationBuilder builder)
    {
        builder.Services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = builder.Configuration["DistributedCache:Host"];
            options.InstanceName = "FibonacciSubsequenceInstance";
        });
    }

    public static void RegisterValidators(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IValidator<FibonacciSubsequenceRequest>, FibonacciSubsequenceRequestValidator>();
        builder.Services.AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters();
    }
}

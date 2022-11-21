using Entity.Configs;
using Microsoft.Extensions.Options;
using UseCase.Abstraction.FibonacciSubsequence;
using UseCase.Implementation.FibonacciSubsequence;
using Repository.Implementation.FibonacciSubsequence;
using Repository.Abstraction.FibonacciSubsequence;

var builder = WebApplication.CreateBuilder(args);

// TODO: Create file that stores all services configs.
builder.Services.AddTransient<IFibonacciSubsequenceFromCacheUseCase, FibonacciSubsequenceFromCacheInteractor>();
builder.Services.AddTransient<IFibonacciSubsequenceGeneratorUseCase, FibonacciSubsequenceGeneratorInteractor>();
builder.Services.AddTransient<IFibonacciSubsequenceProviderUseCase, FibonacciSubsequenceProviderInteractor>();
builder.Services.AddTransient<IFibonacciSubsequenceRepository, FibonacciSubsequenceRepository>();

builder.Services.Configure<DistributedCacheOption>(builder.Configuration.GetSection("DistributedCache"));
builder.Services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<DistributedCacheOption>>().Value);

builder.Services.AddStackExchangeRedisCache(options =>
 {
     options.Configuration = "localhost:6379";
     options.InstanceName = "SampleInstance";
 });

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

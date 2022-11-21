using Microsoft.AspNetCore.Mvc;
using Presentation;
using Presentation.IoC;
using Presentation.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ApiBehaviorOptions>(o => 
{
    o.SuppressModelStateInvalidFilter = true;
});

builder.RegisterConfigs();
builder.RegisterService();
builder.RegisterDistributedCache();
builder.RegisterValidators();

builder.Services.AddControllers(o => 
{
    o.Filters.Add(typeof(ValidationModelStateAttribute));
    o.Filters.Add<ExceptionHandlerMiddleware>();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

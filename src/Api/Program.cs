using Presentation.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterConfigs();
builder.RegisterService();
builder.RegisterDistributedCache();
builder.RegisterValidators();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

using Microsoft.AspNetCore.Builder;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.ClearProviders();//Default olarak bunun kayd� var. IoC kay�t yapmak zorunda kalm�yoruz.
builder.Logging.AddConsole();
builder.Logging.AddDebug();
var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
var builder = WebApplication.CreateBuilder(args);
//Service (Container)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();//Service controller'ý keþfetmeli
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
//app.MapGet("/", () => "Hello World!");

app.Run();

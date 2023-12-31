var builder = WebApplication.CreateBuilder(args);
//Service (Container)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();//Service controller'� ke�fetmeli
builder.Services.AddSwaggerGen();
var app = builder.Build();
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
//app.MapGet("/", () => "Hello World!");
app.Run();
using MyBBSWebApi.BLL;
using MyBBSWebApi.BLL.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// IoC
builder.Services.AddSingleton<IUserBll, UserBll>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(build =>
{
    build.SetIsOriginAllowed(_ => true)
        .AllowCredentials()
        .AllowAnyHeader();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
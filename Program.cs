using Api.net.Middlewears;
using Api.net.Services;
using webapi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlServer<TareasContext>("Data Source=DESKTOP-3M7LV35\\SQLEXPRESS; Initial Catalog= TareasDb; user id=sa;password=pass123456; Trusted_Connection=SSPI;MultipleActiveResultSets=true;Trust Server Certificate=true");

// builder.Services.AddScoped<IHelloWorldService, HelloWorldService>();
builder.Services.AddScoped<IHelloWorldService>(p=> new HelloWorldService());
builder.Services.AddScoped<ICategoriaSerices,  CategoriaServices  >();
builder.Services.AddScoped<ITareasServices, TareasServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.UseWelcomePage();

app.UseTimeMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();

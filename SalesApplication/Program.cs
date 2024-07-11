using SalesApplication.App_Start;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add the Startup class
builder.Services.AddTransient<Config>();

var startup = new Config(builder.Configuration);

// Manually call the ConfigureServices method
startup.ConfigureServices(builder.Services);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

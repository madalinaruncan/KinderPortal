using API.Data;
using API.Data.Service;
using API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.UseCors(options => options.AllowAnyHeader().AllowCredentials().AllowAnyMethod().WithOrigins(builder.Configuration["JWT:ClientUrl"]));


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

DbInitiallizer.InitializeDatabase(app);
using var scope = app.Services.CreateScope();
try
{
    var contextSeedService = scope.ServiceProvider.GetService<ContextSeedService>();
    await contextSeedService.InitializeContextAsync();
}
catch (Exception ex)
{
    var logger = scope.ServiceProvider.GetService<ILogger<Program>>();
    logger.LogError(ex.Message, "Failed to initialize and seed the database");
}

app.Run();

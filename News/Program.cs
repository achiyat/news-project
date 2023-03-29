using Microsoft.AspNetCore.Cors.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var provider = builder.Services.BuildServiceProvider();
//var configuration = provider.GetRequiredService<IConfiguration>();

builder.Services.AddCors(options =>
{
    //var frontendUrl = configuration.GetValue<string>("frontend_url");

    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader();
    });
});

//// Added to use the react
//var corsBuilder = new CorsPolicyBuilder();
//corsBuilder.AllowAnyHeader();
//corsBuilder.AllowAnyMethod();
//corsBuilder.AllowAnyOrigin();
////corsBuilder.AllowCredentials();
//builder.Services.AddCors(options => { options.AddPolicy("AllowAll", corsBuilder.Build()); });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
//what we add
//app.UseHttpsRedirection();
//app.UseRouting();
//app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

//app.UseAuthorization();

////app.MapControllers();


//// Enable CORS
//app.UseCors("AllowAll");

//app.Run();
using System.Text.Json.Serialization;
using JwtWebApi.Extensions;
using JwtWebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

{
    // Add services to the container.
    builder.Services.AddAppilication(builder.Configuration);
    builder.Services.AddIdentity(builder.Configuration);
    builder.Services.AddDependencyInjection();

    builder.Services.AddControllers()
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions
                            .Converters
                            .Add(new JsonStringEnumConverter());
                    });
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();

{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseMiddleware<JwtMiddleware>();

    app.MapControllers();

    app.Run();
}

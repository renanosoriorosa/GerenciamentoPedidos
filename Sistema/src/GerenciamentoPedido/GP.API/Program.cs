using GP.API.Configuration;
using GP.Data.Context;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GPContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentityConfig(builder.Configuration);

builder.Services.AddJWTConfig(builder.Configuration);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddApiConfig();

builder.Services.AddSwaggerConfig();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMvc();

builder.Services.ResolveDependencies();

var app = builder.Build();
var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

app.UseApiConfig(app.Environment);

app.MapControllers();

app.UseSwaggerConfig(apiVersionDescriptionProvider);

app.Run();

using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Almacen_Back;
using Almacen_Back.Data;
using Almacen_Back.Repository.Interfaces;
using Almacen_Back.Repository;
using Almacen_Back.Services;
using Almacen_Back.Services.Interfaces;
using Almacen_Back.Conf;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<Almacen_Back_Context>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("Almacen_Back_Context") ?? throw new InvalidOperationException("Connection string 'Almacen_Back_Context' not found.")));

// Add services to the container.

//Mapper configuration
IMapper mapper = MappingConf.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Repositories configuration
RepositoriesConf.add(builder);

//Services configuration
ServicesConf.add(builder);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                System.Text.Encoding.ASCII.GetBytes(
                    builder.Configuration.GetSection("AppSetting:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
    
builder.Services.AddSwaggerGen(c =>
{
    c.OperationFilter<SecurityRequirementsOperationFilter>();

    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Autorization Standar, usar Bearer. Ejemplo \"bearer {token}\"",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
    });
}
);
builder.Services.AddCors();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Conexion BD
builder.Services.AddSqlServer<Almacen_Back_Context>(builder.Configuration.GetConnectionString("cnLocal"));

var app = builder.Build();

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

app.Run();
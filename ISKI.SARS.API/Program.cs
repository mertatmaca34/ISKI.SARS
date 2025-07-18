using ISKI.Core.CrossCuttingConcerns.Exceptions.ExceptionHandling;
using ISKI.Core.Security.JWT;
using ISKI.OpcUa.Client;
using ISKI.SARS.Application;
using ISKI.SARS.Infrastructure;
using ISKI.SARS.Infrastructure.Persistence;
using ISKI.SARS.Worker;
using ISKI.SARS.API.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// 🔐 TokenOptions config
var tokenOptions = builder.Configuration
    .GetSection(ApiConstants.ApiConstants.TokenOptionsSection)
    .Get<TokenOptions>();
builder.Services.Configure<TokenOptions>(
    builder.Configuration.GetSection(ApiConstants.ApiConstants.TokenOptionsSection));

// 🔑 JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = tokenOptions!.Issuer,
            ValidAudience = tokenOptions!.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey))
        };
    });

// 📦 MediatR & AutoMapper
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddHttpContextAccessor();
builder.Services.AddIskiOpcUaClient();
builder.Services.AddHostedService<Worker>();

// 📚 Application & Infrastructure servisleri
builder.Services.AddApplicationServices();

builder.Services.AddInfrastructureServices(
    builder.Configuration.GetConnectionString(ApiConstants.ApiConstants.DefaultConnection)!);

// 🔐 CORS (Opsiyonel açılabilir)
builder.Services.AddCors(options =>
{
options.AddPolicy(ApiConstants.ApiConstants.AllowAllCorsPolicy, builder => builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

// 📖 Controller + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc(ApiConstants.ApiConstants.SwaggerVersion,
        new OpenApiInfo
        {
            Title = ApiConstants.ApiConstants.SwaggerTitle,
            Version = ApiConstants.ApiConstants.SwaggerVersion
        });

    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        Scheme = ApiConstants.ApiConstants.JwtScheme,
        BearerFormat = ApiConstants.ApiConstants.JwtBearerFormat,
        Name = ApiConstants.ApiConstants.AuthorizationHeader,
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "JWT Token header'ına 'Bearer {token}' formatında girin.",

        Reference = new OpenApiReference
        {
            Id = ApiConstants.ApiConstants.BearerReference,
            Type = ReferenceType.SecurityScheme
        }
    };

    opt.AddSecurityDefinition(ApiConstants.ApiConstants.BearerReference, jwtSecurityScheme);

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            jwtSecurityScheme,
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

// 🌐 Environment config
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// 🔥 Global hata yönetimi
app.UseMiddleware<ExceptionMiddleware>();

// 🔑 Auth
app.UseAuthentication();
app.UseAuthorization();

app.UseCors(ApiConstants.ApiConstants.AllowAllCorsPolicy);

app.MapControllers();

// 🔧 Veritabanı oluşturma ve migration uygulama
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<SarsDbContext>();
    dbContext.Database.EnsureCreated();
}

app.Run();

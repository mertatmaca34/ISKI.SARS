using ISKI.Core.CrossCuttingConcerns.Exceptions.ExceptionHandling;
using ISKI.Core.Security.JWT;
using ISKI.SARS.Application;
using ISKI.SARS.Infrastructure;
using ISKI.SARS.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// 🔐 TokenOptions config
var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
builder.Services.Configure<TokenOptions>(builder.Configuration.GetSection("TokenOptions"));

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

// 📚 Application & Infrastructure servisleri
builder.Services.AddApplicationServices();

builder.Services.AddInfrastructureServices(builder.Configuration.GetConnectionString("DefaultConnection")!);

// 🔐 CORS (Opsiyonel açılabilir)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder => builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

// 📖 Controller + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "ISKI.SARS API", Version = "v1" });

    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        Scheme = "bearer",
        BearerFormat = "JWT",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "JWT Token header'ına 'Bearer {token}' formatında girin.",

        Reference = new OpenApiReference
        {
            Id = "Bearer",
            Type = ReferenceType.SecurityScheme
        }
    };

    opt.AddSecurityDefinition("Bearer", jwtSecurityScheme);

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

app.UseCors("AllowAll");

app.MapControllers();

// 🔧 Veritabanı oluşturma ve migration uygulama
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<SarsDbContext>();
    dbContext.Database.EnsureCreated();
}

app.Run();

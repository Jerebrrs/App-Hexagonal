using App_Hexagonal.Api.Middleware;
using App_Hexagonal.Infrastructura.student.persistence.mapping;
using Microsoft.EntityFrameworkCore;
using App_Hexagonal.Infrastructura.data;
using App_Hexagonal.Infrastructura;
using App_Hexagonal.Application;
using App_Hexagonal.Application.Common.security;
using App_Hexagonal.Api.Middleware.tenant;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using App_Hexagonal.Infrastructura.identity.entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

StudentMappingConfig.Register();

var builder = WebApplication.CreateBuilder(args);

// -------------------- DB --------------------
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSql"))
);

// -------------------- JWT --------------------
var jwtSection = builder.Configuration.GetSection("Jwt");
var secretKey = Encoding.UTF8.GetBytes(jwtSection["Key"]!);

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)
            )
        };
    });


// -------------------- AUTHORIZATION --------------------
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(Policies.TenantAdmin,
        policy => policy.RequireRole(Roles.Admin));

    options.AddPolicy(Policies.TenantUser,
        policy => policy.RequireAuthenticatedUser());
});

// -------------------- Layers --------------------
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services
    .AddIdentityCore<ApplicationUser>(options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
    })
    .AddRoles<IdentityRole<Guid>>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Nuestra API utiliza la Autenticación JWT usando el esquema Bearer. \n\r\n\r" +
                     "Ingresa la palabra a continuación el token generado en login.\n\r\n\r" +
                     "Ejemplo: \"12345abcdef\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
      {
        new OpenApiSecurityScheme
        {
          Reference = new OpenApiReference
          {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
          },
          Scheme = "oauth2",
          Name = "Bearer",
          In = ParameterLocation.Header
        },
        new List<string>()
      }
    });
});

var app = builder.Build();

// =======================
// Middleware pipeline
// =======================

//Usar en caso de necesitar debugear el token. 
// app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<JwtDebugMiddleware>();

app.UseAuthentication();
app.UseMiddleware<TenantContextMiddleware>();
app.UseAuthorization();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
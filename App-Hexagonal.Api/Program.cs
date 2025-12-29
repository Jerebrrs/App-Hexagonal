using App_Hexagonal.Api.Middleware;
using App_Hexagonal.Infrastructura.student.persistence.mapping;
using Microsoft.EntityFrameworkCore;
using App_Hexagonal.Infrastructura.data;
using App_Hexagonal.Infrastructura;
using App_Hexagonal.Application;
using App_Hexagonal.Infrastructura.identity.config;
using App_Hexagonal.Application.Common.security;
using App_Hexagonal.Api.Middleware.tenant;

StudentMappingConfig.Register();

var builder = WebApplication.CreateBuilder(args);
var dbConnectionString = builder.Configuration.GetConnectionString("ConexionSql");
if (string.IsNullOrWhiteSpace(dbConnectionString))
{
    throw new InvalidOperationException("La ConnectionString 'ConexionSql' no está configurada.");
}

// Registrar AppDbContext con la cadena de conexión de appsettings
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(dbConnectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Capas
builder.Services.AddApplication();
builder.Services.AddInfrastructure();


// Identity 
builder.Services.AddIdentityConfiguration();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(Policies.TenantAdmin, policy =>
        policy.RequireRole(Roles.Admin));

    options.AddPolicy(Policies.TenantUser, policy =>
        policy.RequireAuthenticatedUser());
});
var app = builder.Build();
app.UseMiddleware<TenantContextMiddleware>();

app.UseMiddleware<ErrorHandlingMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.MapControllers();

app.Run();

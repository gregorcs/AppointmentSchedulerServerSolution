using AppointmentSchedulerServer.DbConnections;
using AppointmentSchedulerServer.Repositories;
using AppointmentSchedulerServer.Repositories.Implementations;
using AppointmentSchedulerServer.Repositories.Interfaces;
using AppointmentSchedulerServerTests.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddSingleton(new SqlServerDbConnectionFactory("Server=hildur.ucn.dk;Database=CSC-CSD-S212_10407644;User Id=CSC-CSD-S212_10407644;Password=Password1!;"));
builder.Services.AddSingleton<IAccountDAO, AccountDAO>();
builder.Services.AddSingleton<IEmployeeDAO, EmployeeDAO>();
builder.Services.AddSingleton<IAccountDAO, AccountDAO>();
builder.Services.AddSingleton<IAppointmentDAO, AppointmentDAO>();
builder.Services.AddSingleton<IEmployeeDAO, EmployeeDAO>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Authorization with bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(JWTHandler.jwtString)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
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

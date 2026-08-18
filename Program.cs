using ATIEnvioSMS.Helper;
using ATIEnvioSMS.LayerData.Data;
using ATIEnvioSMS.LayerData.Models.DTOs.Security;
using ATIEnvioSMS.LayerData.Repository.Implementations;
using ATIEnvioSMS.LayerData.Repository.Implementations.cod;
using ATIEnvioSMS.LayerData.Repository.Implementations.sms;
using ATIEnvioSMS.LayerData.Repository.Implementations.sys;
using ATIEnvioSMS.LayerData.Repository.Interfaces;
using ATIEnvioSMS.LayerData.Repository.Interfaces.cod;
using ATIEnvioSMS.LayerData.Repository.Interfaces.sms;
using ATIEnvioSMS.LayerData.Repository.Interfaces.sys;
using ATIEnvioSMS.LayerLogic.Mapper;
using ATIEnvioSMS.LayerLogic.Services.Implementations.cod;
using ATIEnvioSMS.LayerLogic.Services.Implementations.security;
using ATIEnvioSMS.LayerLogic.Services.Implementations.sms;
using ATIEnvioSMS.LayerLogic.Services.Implementations.sys;
using ATIEnvioSMS.LayerLogic.Services.Interfaces.cod;
using ATIEnvioSMS.LayerLogic.Services.Interfaces.security;
using ATIEnvioSMS.LayerLogic.Services.Interfaces.sms;
using ATIEnvioSMS.LayerLogic.Services.Interfaces.sys;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var jwtSettings = JwtSettingsHelper.GetJwtSettingsFromEnvironment(builder);
var secretKey = Encoding.UTF8.GetBytes(jwtSettings.Key);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(op =>
{
    op.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        RequireExpirationTime = true,
        IssuerSigningKey = new SymmetricSecurityKey(secretKey),
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero,
    };
    op.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            if (context.Exception is SecurityTokenExpiredException)
            {
                context.Response.StatusCode = 401;
                context.Response.ContentType = "application/json";
                return context.Response.WriteAsync(JsonSerializer.Serialize(new
                {
                    error = "invalid_token",
                    message = "Token inválido"
                }));
            }
            // Otros errores
            context.Response.StatusCode = 401;
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddAuthorization();

//registro del servicio de AutoMapper y los Profile
builder.Services.AddAutoMapper(config => config.AddProfile<MappingProfile>());
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped(typeof(IBaseReadOnlyRepository<>), typeof(BaseReadOnlyRepository<>));
builder.Services.AddScoped(typeof(IBaseFullRepository<>), typeof(BaseFullRepository<>));
builder.Services.AddScoped<IAuditoriumRepository, AuditoriumRepository>();
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IContactoRepository, ContactoRepository>();
builder.Services.AddScoped<IGrupoContactoRepository, GrupoContactoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddScoped<IAuditoriumUseCases, AuditoriumUseCaseServices>();
builder.Services.AddScoped<IEmpresaUseCases, EmpresaUseCaseServices>();
builder.Services.AddScoped<IContactoUseCases, ContactoUseCaseServices>();
builder.Services.AddScoped<IGrupoContactosUseCases, GrupoContactosUseCaseServices>();
builder.Services.AddScoped<IUsuarioUseCases, UsuarioUseCaseServices>();

builder.Services.AddScoped<IJwtTokenUseCases, JwtTokenUseCaseServices>();
builder.Services.AddScoped<IAuthUseCases, AuthUseCaseServices>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ENVIO_SMS_ATI API",
        Description = "Un ASP.NET Core Web API para administrar los procesos de envios de SMS de la UNE",
        // TermsOfService = new Uri("https://example.com/terms"),
        //Contact = new OpenApiContact
        //{
        //    Name = "Dirección de Informática OC",
        //    //    Url = new Uri("https://example.com/contact")
        //}
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Por favor entre un token válido",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                      //  new string[] { }
                    }
                });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("PoliticaCORS", app =>
    {
        app.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<SistemaDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("BDConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI(c=>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ENVIO_SMS API v1");
    });
//}

//app.UseHttpsRedirection();

app.UseCors("PoliticaCORS");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

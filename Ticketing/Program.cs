using Datalayer.Context;
using Domain.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Ticketing.Extensions;
using Ticketing.Middleware;

var builder = WebApplication.CreateBuilder(args);
Common.Helper.ConfigurationManager.Configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Context
builder.Services.AddDbContext<TicketingContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr"), providerOptions => providerOptions.EnableRetryOnFailure()));
#endregion

#region Authentication
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(config =>
{
    config.SignIn.RequireConfirmedEmail = false;
    config.User.RequireUniqueEmail = false;

    // Password requirements,
    config.Password.RequireDigit = false;
    config.Password.RequiredLength = 3;
    config.Password.RequiredUniqueChars = 0;
    config.Password.RequireLowercase = false;
    config.Password.RequireNonAlphanumeric = false;
    config.Password.RequireUppercase = false;
    config.Lockout.MaxFailedAccessAttempts = 3;
    config.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(1);
})
    .AddEntityFrameworkStores<TicketingContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});
#endregion

#region IOC
builder.Services.AddTransient<IJWTExtension, JwtExtension>();
Contract.StartUp.Start(builder.Services);
builder.Services.AddMediatR(typeof(Contract.StartUp).Assembly);
#endregion

#region Redis
builder.Services.AddDistributedMemoryCache();
var isRedisActive = builder.Configuration["UseRedis:Value"];
var redisConnection = builder.Configuration["RedisConnection:Redis"];

if (isRedisActive?.ToLower() == "true")
{
    builder.Services.AddStackExchangeRedisCache(options =>
    {
        options.Configuration = redisConnection;
        options.InstanceName = "Ticketing_Core_";
    });
}


#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<JWTMiddleware>();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllers();



app.Run();

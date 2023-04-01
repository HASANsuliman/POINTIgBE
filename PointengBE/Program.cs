using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using PointengBE.Models.Context;
using PointengBE.Services;
using PointengBE.Services.Authrize;
using PointengBE.Services.Interfaaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PointingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PointingSystemContext") ?? throw new InvalidOperationException("Connection string 'PointingSystemContext' not found.")));
//PointingSystemProduction
//PointingSystemContext
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPlanInterface, PlanService>();
builder.Services.AddScoped<IdirctInterface, DirectService>();
builder.Services.AddScoped<IdirctPromInterface, DirectPromService>();
builder.Services.AddScoped<ISubDirectInterface, SubDirectService>();
builder.Services.AddScoped<ISubDirectPromInterface, SubDirectPromService>();

builder.Services.AddScoped<AuthInterface, AuthServices>();
builder.Services.AddScoped<ICalculationInterface, CalculationService>();


//Auth
builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});

builder.Services.AddScoped<IClaimsTransformation, AuthClaims>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", builder => builder
        .RequireAuthenticatedUser()
        .RequireClaim("license", "Admin"));
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("HOU", builder => builder
        .RequireAuthenticatedUser()
        .RequireClaim("license", "HOU"));
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("SalesSupport", builder => builder
        .RequireAuthenticatedUser()
        .RequireClaim("license", "SalesSupport"));
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("User", builder => builder
        .RequireAuthenticatedUser()
        .RequireClaim("license", "q"));
});
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                         // builder.AllowAnyOrigin();
                          builder.AllowAnyHeader();
                          builder.AllowAnyMethod();
                          //builder.AllowAnyOrigin();
                          builder.SetIsOriginAllowed(origin => true);
                          //builder.WithOrigins("http://thserv207:5003");
                          builder.AllowCredentials();
                          builder.WithExposedHeaders();
                        
                      });
});
builder.Services.AddControllersWithViews()
  .AddNewtonsoftJson(options =>
  options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
var app = builder.Build();
    app.UseSwagger();
    app.UseSwaggerUI();

//app.UseHttpsRedirection();
//app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

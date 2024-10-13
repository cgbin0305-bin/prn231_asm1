using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Models.Model;
using AuctionHistory = Repository.AuctionHistory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DI
builder.Services.AddDbContext<KoiFishAuctionDbContext>(opt => opt.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<AuctionHistory.IAuctionHistoryRepository, AuctionHistory.AuctionHistoryRepository>();


// setup OData
builder.Services.AddControllers().AddOData(options => {
    options.EnableQueryFeatures()
        .AddRouteComponents("odata", GetEdmModel()); // Register OData routes
});

//setup jwt
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JWTSection:SecretKey").Value)),
            ValidIssuer = builder.Configuration.GetSection("JWTSection:Issuer").Value,
            ValidAudience = builder.Configuration.GetSection("JWTSection:Audience").Value,
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

app.UseAuthorization();

app.MapControllers();

app.Run();

static IEdmModel GetEdmModel() {
    var odataBuilder = new ODataConventionModelBuilder();

    var newSet = odataBuilder.EntitySet<Models.Model.AuctionHistory>("AuctionHistory");
    newSet.EntityType.HasKey(a => a.HistoryId);
    return odataBuilder.GetEdmModel();
}
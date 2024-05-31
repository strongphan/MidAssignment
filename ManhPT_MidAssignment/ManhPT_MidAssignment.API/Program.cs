using ManhPT_MidAssignment.Application.IRepository;
using ManhPT_MidAssignment.Application.IRpository;
using ManhPT_MidAssignment.Application.Services.BookService;
using ManhPT_MidAssignment.Application.Services.CategoryService;
using ManhPT_MidAssignment.Application.Services.TokenService;
using ManhPT_MidAssignment.Application.Services.UserService;
using ManhPT_MidAssignment.Infrastructure.Data;
using ManhPT_MidAssignment.Infrastructure.Repository;
using ManhPT_MidAssignment.Infrastructure.TokenService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Db connection
var connectionString = builder.Configuration.GetConnectionString("BookManager");
builder.Services.AddDbContext<LibraryContext>(options => options.UseSqlServer(connectionString));

//Add Mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Add JWT
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false; // Add this line
        options.SaveToken = true; // Add this line
        options.TokenValidationParameters = TokenService.GetTokenValidationParameters(builder.Configuration);
    });

//Add Authen in swagger
builder.Services.AddSwaggerGen(opt =>
{
    var securitySchema = new OpenApiSecurityScheme
    {
        Name = "JWT Authentication",
        Description = "Enter JWT Bearer",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };
    opt.AddSecurityDefinition("Bearer", securitySchema);
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { securitySchema, new[] { "Bearer" } }
    });
});

// Token services
builder.Services.AddScoped<ITokenService, TokenService>();

//User services
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IUserService, UserService>();

//Book services
builder.Services.AddScoped<IBookRepo, BookRepo>();
builder.Services.AddScoped<IBookService, BookService>();

//Category services
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

//Borrowing services
builder.Services.AddScoped<IBookBorrowingRequestRepo, BookBorrowingRequestRepo>();

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

using BlazorEcomm_BUSINESS.Repository;
using BlazorEcomm_BUSINESS.Repository.IRepository;
using BlazorEcomm_DATA.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddCors(o => o.AddPolicy("BlazorEcomm", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

// Requires AutoMapper.Extensions.Microsoft.DependencyInjection package to be installed
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// AddCors service is registered above
app.UseCors("BlazorEcomm");

app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();
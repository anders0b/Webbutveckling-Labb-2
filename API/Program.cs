using API.Endpoints;
using System.Text.Json.Serialization;
using DataAccess.ServiceExtensions;
using Services;
using Services.Interfaces;


var builder = WebApplication.CreateBuilder(args);

//var connectionString = builder.Configuration.GetConnectionString("AndersBrodContext");
//builder.Services.AddDbContext<AndersBrodContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddAndersBrodContext(builder.Configuration);
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderDetailsService, OrderDetailsService>();
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();
app.MapProductEndpoints();
app.MapCategoryEndpoints();
app.MapOrderEndpoints();
app.MapCustomerEndpoints();
app.MapOrderDetailsEndpoints();

app.Run();

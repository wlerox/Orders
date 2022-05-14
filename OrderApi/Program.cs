using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Order.Api.BackgroundService;
using Order.Business.Abstract;
using Order.Business.Concrete;
using Order.Business.Model;
using Order.DataAccess;
using Order.DataAccess.Abstract;
using Order.DataAccess.Concrete;
using Order.DataAccess.Mapper;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
//builder.Configuration.AddJsonFile("appsettings.json");
//serilog
var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

//swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
                  options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); ;

builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<IOrderRepo, OrderRepo>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICacheService, CacheService>();
builder.Services.AddSingleton<IRabitMQService, RabitMQService>();
builder.Services.AddSingleton<ISendMailService, SendMailService>();

//rabbitmq connectionstring
var rabbitConnectionString = builder.Configuration.GetSection("RabbitMQ");
builder.Services.Configure<RabbitOptions>(rabbitConnectionString);

//bacground services
builder.Services.AddHostedService<MailSenderBackgroundService>();

//Add mapper
builder.Services.AddAutoMapper(typeof(AppProfile));

//sqlserver connection 
var dbConnectionString = builder.Configuration.GetConnectionString("OrderDb");
builder.Services.AddDbContext<OrderDbContext>(x => { x.UseSqlServer(dbConnectionString,
    providerOptions => providerOptions.EnableRetryOnFailure());});

//redis connection 
var redisConnectionString = builder.Configuration.GetConnectionString("RedisConnect");
builder.Services.AddStackExchangeRedisCache(x => x.Configuration=redisConnectionString);

var app = builder.Build();
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
//OrderDbContext dbContext = app.Services.GetRequiredService<OrderDbContext>();
//dbContext.Database.EnsureCreated();
app.UseSwagger();
//app.MapGet("/", () => "Hello World!");
app.UseHttpsRedirection();
//app.UseAuthorization();
app.MapControllers();

app.UseSwaggerUI();

app.Run();

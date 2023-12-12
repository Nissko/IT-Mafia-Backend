using BackendMafia.Applications.Gun.Queries;
using Domain.Entities.ShopAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using UI.Applications.Gun.Commands.StoreGuns;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000") // Укажите URL вашего React-фронтенда
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

//RegisterDbContext
builder.Services.AddDbContext<MafiaApiDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//RegisterMediatR Methods
builder.Services.AddTransient<IRequestHandler<GetGunsQuery, IEnumerable<Gun>>, GetGunsQueryHandler>();
builder.Services.AddTransient<IRequestHandler<StoreGunsCommand, Unit>, StoreGunsCommandHandler>();

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
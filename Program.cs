using Microsoft.EntityFrameworkCore;
using Nightclub.Data;
using NightClub.Repositories;
using NightClub.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
#region Repositories
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IHealthcareProviderRepository, HealthcareProviderRepository>();
// builder.Services.AddScoped<IHistoryClientVisitsRepository, HistoryClientVisitsRepository>();
// builder.Services.AddScoped<ISchedulesWorkerRepository, SchedulesWorkerRePository>();
builder.Services.AddScoped<IStatusWorkerRepository, StatusWorkerRepository>();
// builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<ITypeDocumentRepository, TypeDocumentRepository>();
builder.Services.AddScoped<ITypeMoneyRepository, TypeMoneyRepository>();
builder.Services.AddScoped<ITypesWorkerRepository, TypesWorkerRepository>();
builder.Services.AddScoped<IWorkerRepository, WorkerRepository>();
#endregion

#region Services
builder.Services.AddScoped<ITypeDocumentService, TypeDocumentService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IWorkerService, WorkerService>();
builder.Services.AddScoped<ITypesMoneyService, TypesMoneyService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<ITypesWorkerService, TypesWorkerService>();
builder.Services.AddScoped<IStatusWorkersService, StatusWorkersService>();
builder.Services.AddScoped<IHealthcareProviderService, HealthcareProviderService>();

#endregion

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseURL"));
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



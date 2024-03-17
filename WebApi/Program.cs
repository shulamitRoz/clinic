using System.Text.Json.Serialization;
using WebApi;
using WebApi.Core;
using WebApi.Core.Models;
using WebApi.Core.ServiesModeld;
using WebApi.Data;
using WebApi.Data.DataRepository;
using WebApi.Servies.serviesRepository;
using WebApi.Servies.ServiesRepository;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions( option=>{
    option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    option.JsonSerializerOptions.WriteIndented=true;    

});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<DataContext>();


builder.Services.AddScoped<IDoctor, DoctorRepository>();
builder.Services.AddScoped<IPatient, PatientsRepository>();
builder.Services.AddScoped<ITurn, TurnRepository>();

builder.Services.AddScoped<IDoctorServies, DoctorServies>();
builder.Services.AddScoped<IPatientServies, PatientServies>();
builder.Services.AddScoped<ITurnServices, TurnServies>();

var policy = "policy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policy, policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
builder.Services.AddAutoMapper(typeof(MappingProfile));
//builder.Services.AddSingleton<Mapping>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(policy);

app.MapControllers();

app.Run();


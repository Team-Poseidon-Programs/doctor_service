using Doctor_Business_Logic;
using Doctor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<Doctor.Entities.DoctorContext>();
builder.Services.AddScoped<ILogic, Logic>();
builder.Services.AddScoped<IDoctor<Doctor.Entities.Doctor>,Doctorrepo>();
builder.Services.AddScoped<IDoctorAv<Doctor.Entities.DoctorAvailability>, DoctorAv>();
builder.Services.AddScoped<Mapper>();


builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("corspolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

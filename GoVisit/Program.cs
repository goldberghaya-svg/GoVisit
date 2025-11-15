
using FluentValidation;
using FluentValidation.AspNetCore;
using GoVisit.Domain;
using GoVisit.Repo;
using GoVisit.Validations;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers().AddFluentValidation();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddMongoDB<AppointmentsContext>("mongodb+srv://goldberghaya_db_user:jGGUzmEppjMQzYd5@cluster0.gg7ly0k.mongodb.net/?appName=Cluster0", "Appointments");
builder.Services.AddTransient<IAppiontmentsForUserRepository, AppiontmentsForUserRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddValidatorsFromAssemblyContaining<AppointmentsForUserValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CancelMeetingRequestValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI(c => {
    c.RoutePrefix = string.Empty;
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
}
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using DAL;
using DogsAPI.Services;
using DogsAPI.Routes;
using DogsAPI.Providers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using DogsAPI.Options;
using DogsAPI.OptionsSetup;
using Hellang.Middleware.ProblemDetails;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddProblemDetails();
builder.Services.addDAL();
builder.Services.addServices();
builder.Services.addProviders();
builder.Services.addOptions();

builder.Services.AddAuthentication(x => {
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer();
builder.Services.AddAuthorization();

builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.mapCharities();
app.mapDogs();
app.mapAuth();

//app.UseProblemDetails();
app.UseAuthorization();


app.Run();



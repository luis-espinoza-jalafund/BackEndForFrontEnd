using BackEndForFrontEnd.Infraestructure;
using BackEndForFrontEnd.RequestPipeline;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddInfraestructure(builder.Configuration);

var app = builder.Build();
app.InitializeDatabase();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BACKEND FOR FRONTEND - API V1 ");
    });
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.Run();

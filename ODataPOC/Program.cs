using Microsoft.AspNetCore.OData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddOData(options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(conf =>
{
    conf.SwaggerDoc("web", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "OData - Web",
        Description = "Web endpoint for Odata",
    });

    conf.SwaggerDoc("mobile", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "OData - Mobile",
        Description = "Mobile endpoint for Odata",
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(conf =>
    {
        conf.SwaggerEndpoint("/swagger/web/swagger.json", "Web API V1");
        conf.SwaggerEndpoint("/swagger/mobile/swagger.json", "Mobile API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

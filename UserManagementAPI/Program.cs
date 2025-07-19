using UserManagementAPI.Endpoints;
using UserManagementAPI.Extensions;
using UserManagementAPI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSwaggerDocumentation();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "UserManagementAPI v1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
    });
}
app.MapUserEndpoints();

app.Run();

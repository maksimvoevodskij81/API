
using TaskAPI.Installers;
using TaskAPI.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.InstallServicesInAssembly(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error-development");
}
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

var swaggerOptions = new SwaggerOptions();
app.Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);
app.UseSwagger(options => options.RouteTemplate = swaggerOptions.JsonRoute);
app.UseSwaggerUI(options => options.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description));
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.UseAuthorization();

app.MapControllers();

app.Run();

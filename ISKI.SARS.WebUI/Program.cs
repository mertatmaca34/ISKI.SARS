using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(typeof(ISKI.SARS.WebUI.Mapping.WebUiMappingProfile));
builder.Services.AddScoped<ISKI.SARS.WebUI.Services.TokenService>();
builder.Services.AddScoped<ISKI.SARS.WebUI.Services.ApiService>();
builder.Services.AddHttpClient<ISKI.SARS.WebUI.Services.ApiService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"] ?? "https://localhost:5001/");
});

builder.Host.UseSerilog((ctx, cfg) => cfg.ReadFrom.Configuration(ctx.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseMiddleware<ISKI.SARS.WebUI.Middlewares.AuthRedirectMiddleware>();

app.MapRazorPages();

app.Run();

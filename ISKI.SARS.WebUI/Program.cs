var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddHttpClient<ISKI.SARS.WebUI.Services.ApiService>(client =>
{
    var baseUrl = builder.Configuration.GetValue<string>("ApiBaseUrl");
    client.BaseAddress = new Uri(baseUrl ?? "http://localhost:5000");
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ISKI.SARS.WebUI.Services.TokenService>();
builder.Services.AddAutoMapper(typeof(ISKI.SARS.WebUI.Mapping.WebUiMappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapDefaultControllerRoute();
app.Run();

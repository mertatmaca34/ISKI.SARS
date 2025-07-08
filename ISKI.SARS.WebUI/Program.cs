var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpClient<ISKI.SARS.WebUI.Services.ApiService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ISKI.SARS.WebUI.Services.TokenService>();
builder.Services.AddAutoMapper(typeof(ISKI.SARS.WebUI.Mapping.WebUiMappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapDefaultControllerRoute();
app.Run();

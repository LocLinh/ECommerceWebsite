using CustomersSite.Services;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient("APIClient", config =>
{
    config.BaseAddress = new Uri(builder.Configuration["BaseURL"]);
});
var BaseURL = new Uri(builder.Configuration["BaseURL"]);
builder.Services
    .AddRefitClient<IProductApiClient>()
    .ConfigureHttpClient(c => c.BaseAddress = BaseURL);
builder.Services
    .AddRefitClient<IUserApiClient>()
    .ConfigureHttpClient(c => c.BaseAddress = BaseURL);
builder.Services
    .AddRefitClient<IAuthApiClient>()
    .ConfigureHttpClient(c => c.BaseAddress = BaseURL);
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

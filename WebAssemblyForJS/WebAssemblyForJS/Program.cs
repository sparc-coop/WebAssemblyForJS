using Microsoft.Extensions.DependencyInjection;
using WebAssemblyForJS.Client.Pages;
using WebAssemblyForJS.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents(
    //options =>
    //{
    //    options.RootComponents.RegisterCustomElements<Counter>(identifier: "quote",
    //    javaScriptInitializer: "initializeComponent");
    //}
    );

//builder.RootComponents.RegisterCustomElement<Counter>("my-counter");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(WebAssemblyForJS.Client._Imports).Assembly);

app.Run();

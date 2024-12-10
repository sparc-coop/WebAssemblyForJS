using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebAssemblyForJS.Client.Pages;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.RegisterForJavaScript<Quote>(identifier: "quote",
javaScriptInitializer: "initializeComponent");

//builder.RootComponents.RegisterCustomElement<Counter>("my-counter");

await builder.Build().RunAsync();

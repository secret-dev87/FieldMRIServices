using FieldMRIServicesServices.Data;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using FieldMRIServices.Data;
using FieldMRIServices.Extensions.Services;
using FieldMRIServices.Extensions.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllersWithViews();



builder.Services.AddSyncfusionBlazor();
builder.Services.AddScoped<IIventoryServices, InventoryServices>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);


//builder.Services.AddSyncfusionBlazor();

var connectionString = builder.Configuration.GetConnectionString("FMIconnection")
          ?? throw new InvalidOperationException("Connection 'FMIventoryDbContext' not found");

builder.Services.AddDbContext<FMIventoryDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<FMIventoryDbContext>();

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NCaF5cXmZCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWXlfdXVQR2BdWUF1X0U=");



builder.Services.AddScoped<TokenProvider>();

var app = builder.Build();

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NBaF5cXmZCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWXtfdnVSQ2ddV0R+WEA=");


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler(exceptionHandlerApp =>
    {
        exceptionHandlerApp.Run(async context =>
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            // using static System.Net.Mime.MediaTypeNames;
            context.Response.ContentType = Text.Plain;

            await context.Response.WriteAsync("An exception was thrown.");

            var exceptionHandlerPathFeature =
                context.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
            {
                await context.Response.WriteAsync(" The file was not found.");
            }

            if (exceptionHandlerPathFeature?.Path == "/")
            {
                await context.Response.WriteAsync(" Page: Home.");
            }
        });
    }); app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

using InventoryManagement.Models;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.controller;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddDbContext<InventoryManagementContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("db_ConnStr"));

});

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<InventoryManagementContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("db_ConnStr")));


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "allowInventoryCors",
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader().AllowAnyMethod()
                          .SetIsOriginAllowedToAllowWildcardSubdomains();
                      });
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors("allowInventoryCors");

app.UseAuthorization();

app.MapRazorPages();

app.MapTblUsersInfoEndpoints();

app.MapControllers();
app.Run();

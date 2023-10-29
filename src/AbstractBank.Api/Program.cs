using AbstractBank.Domain.CustomerAggregate;
using AbstractBank.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddWebApiServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app
    .UseHttpsRedirection()
    .UseAuthorization();

app.MapControllers();

// Note:
// This is not very good practice and better to have EF Migrations in place 
// but I opt to this piece of code to make things easy to run from stratch 
// without manual DB creation and to save some development time.
using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    if (context.Database.EnsureCreated())
    {
        context.Customers.Add(new Customer(Guid.Parse("6b6c6976-3322-4f22-a157-2ef09ecc393c"), "User Name", "User Surname"));
    }

    context.SaveChanges();
}

app.Run();

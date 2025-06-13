using Microsoft.EntityFrameworkCore;
using ExpenseTracker.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register EF Core with SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=expenses.db"));

//To allow requests from devEnvironment
var DevCorsPolicy = "_DevCorsPolicy";
//To allow requests from Prod environment
var ProdCorsPolicy = "_ProdCorsPolicy";


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: DevCorsPolicy,
        policy =>
        {
            policy.WithOrigins("https://localhost:3000") // React dev server
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });

    options.AddPolicy(name: ProdCorsPolicy,
        policy =>
        {
            policy.WithOrigins("https://expensetrackerbackend-1-r4ic.onrender.com/") // React dev server
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //Enables the use of the CORS policy
    app.UseCors(DevCorsPolicy);
}
else
{
    app.UseCors(ProdCorsPolicy);
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "🚀 Welcome to the Expense Tracker API! Visit /api/expenses to explore.");

// Seed the DB
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate(); // applies any pending migrations
    SeedData.Initialize(dbContext);
}

app.Run();
using AtChalenge.Core.Interfaces;
using AtChalenge.Core.Services;
using AtChalenge.Infrastructure.Data;
using AtChalenge.Infrastructure.Filters;
using AtChalenge.Infrastructure.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
const string AllowAllHeadersPolicy = "AllowAllHeadersPolicy";
// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();


builder.Services.AddCors(options => {

    options.AddPolicy(name: AllowAllHeadersPolicy, b =>
    {
        b.SetIsOriginAllowed(o => new Uri(o).Host == "localhost")
        .AllowAnyHeader().AllowAnyMethod();
    });
});
builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddDbContext<AtChalengeContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("AtChalenge"))
    );
    builder.Services.AddTransient<IGenderService, GenderService>();
    builder.Services.AddTransient<IGenderRepository, GenderRepository>();
    builder.Services.AddTransient<IMovieService, MovieService>();
    builder.Services.AddTransient<IMovieRepository, MovieRepository>();
    builder.Services.AddTransient<ICommentService, CommentService>();
    builder.Services.AddTransient<ICommentRepository, CommentRepository>();


builder.Services.AddMvc(options => {
    options.Filters.Add<ValidationFilter>();
}).AddFluentValidation(options =>
{
    options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Archivos")),
    RequestPath = new PathString("/Archivos")
});
app.UseCors(AllowAllHeadersPolicy);
app.UseAuthorization();

app.MapControllers();

app.Run();

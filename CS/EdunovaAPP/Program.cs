using EdunovaAPP.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Prilagodba za dokumentaciju
builder.Services.AddSwaggerGen(sgo =>
{
    var o = new Microsoft.OpenApi.Models.OpenApiInfo()
    {
        Title = "Edunova API",
        Version = "v1",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact()
        {
            Email = "tjakopec@gmail.com",
            Name = "Tomislav Jakopec"
        },
        Description = "Ovo je dokumentacija za Edunova API",
        License = new Microsoft.OpenApi.Models.OpenApiLicense()
        {
            Name = "Edukacijska licenca"
        }

    };
    sgo.SwaggerDoc("v1", o);

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    sgo.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
});

// Svi se od svuda na sve moguće načine mogu spojiti na naš API
//builder.Services.AddCors(opcije =>
//{
//    opcije.AddPolicy("CorsPolicy",
//        builder =>
//            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
//            );
//});

// dodavanje baze podataka
builder.Services.AddDbContext<EdunovaContext>(o =>
    o.UseSqlServer(builder.Configuration.GetConnectionString(name: "EdunovaContext"))
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI(opcije =>
    {
        opcije.ConfigObject.AdditionalItems.Add("requestSnippetsEnabled", true);
    });
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseStaticFiles();

//app.UseCors("CorsPolicy");

// Potrebno za produkciju
app.UseDefaultFiles();
app.UseDeveloperExceptionPage();
app.MapFallbackToFile("index.html");

app.Run();

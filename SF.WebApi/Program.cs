
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SF.DAL;
using SF.WebApi.BL;
using SF.WebApi.BL.Middleware;
using SF.WebApi.BL.Services;

namespace SF.WebApi;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        //� UI swagger ����������� ���� �����������
        builder.Services.AddSwaggerGen(s =>
        {
            s.SwaggerDoc("v1", new OpenApiInfo { Title = "CarChargingStationMobile", Version = "v1" });            
            s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });
            s.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });

            List<string> xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList();
            foreach (string fileName in xmlFiles)
            {
                string xmlFilePath = Path.Combine(AppContext.BaseDirectory, fileName);
                if (System.IO.File.Exists(xmlFilePath))
                    s.IncludeXmlComments(xmlFilePath, includeControllerXmlComments: true);
            }
        });

        builder.Services.AddTransient<IJwtService, JwtService>();
        builder.Services.AddTransient<IUserService, UserService>();
        builder.Services.AddTransient<IAuthService, AuthService>();

        ///��� ����� ���������� ����� ��
        builder.Services.AddDbContext<DataDbContext>(opt => opt.UseInMemoryDatabase("UseInMemoryDatabase"));

        builder.Services.AddAutoMapper(typeof(MapBL));

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        await SeedData.CreatedAdmin(app);

        app.UseMiddleware<AuthMiddleWare>();

        app.Run();
    }
}
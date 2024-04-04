using AutoMapper;
using BLL;
using DAL;
using ENTITIES.Context;

namespace WebApiBloggingPlatform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container. 
            builder.Services.AddScoped<IPostService, PostService>();
            builder.Services.AddScoped<IPostRepository, PostRepository>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();
            builder.Services.AddDbContext<BloggingPlatformContext>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // This configuration tells AutoMapper to scan the assembly (or assemblies)
            // for classes that inherit from Profile and automatically register them.

            // Register the dependency of Mapper configuration
            // and the profile (MyMappingProfille.cs) that I have created.
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyMappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

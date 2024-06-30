using API.Data;
using API.Data.Repository;
using API.Data.Service;
using API.Entities;
using API.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddCors();
            services.AddScoped<IRepository<Preschooler>, PreschoolerRepository>();
            services.AddScoped<PreschoolerService>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddScoped<JWTService>();
            services.AddScoped<EmailService>();
            services.AddScoped<ContextSeedService>();

            services.AddIdentityCore<User>(options =>
            {   //password config
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                //email confirmation
                options.SignIn.RequireConfirmedEmail = true;
            })
    .AddRoles<IdentityRole>() //be able to add roles
    .AddRoleManager<RoleManager<IdentityRole>>() //be able to make use of RoleManager
            .AddEntityFrameworkStores<ApplicationDbContext>() //provides the context
    .AddSignInManager<SignInManager<User>>() //make use of SigInManager
    .AddUserManager<UserManager<User>>() //make use of UserManager to create users
    .AddDefaultTokenProviders(); //generate tokens for email confirmation

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true, //validate token based on the key provided in config
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"])), //issuer signin key based on JWT:key
            ValidIssuer = config["JWT:Issuer"], //api url
            ValidateIssuer = true, //validate the issuer
            ValidateAudience = false // do not validate the audience (Angular app)
        };
    });


            return services;
        }
    }
}

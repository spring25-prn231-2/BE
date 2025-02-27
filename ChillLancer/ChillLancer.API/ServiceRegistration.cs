using ChillLancer.BusinessService.BusinessModels;
using ChillLancer.BusinessService.Extensions;
using ChillLancer.BusinessService.Interfaces;
using ChillLancer.BusinessService.Services;
using ChillLancer.Repository;
using ChillLancer.Repository.Interfaces;
using ChillLancer.Repository.Models;
using ChillLancer.Repository.Repositories;
using Mapster;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

namespace ChillLancer.API
{
    public static class ServiceRegistration
    {
        public static IServiceCollection DependencyInjectionServices(this IServiceCollection services, IConfiguration configuration)
        {
            //System Services
            services.InjectDbContext(configuration);
            services.InjectBusinessServices();
            services.InjectRepository();
            services.ConfigCORS();
            services.ConfigKebabCase();
            services.ConfigMapster();
            //services.ConfigOData();

            return services;
        }

        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        private static IServiceCollection InjectDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("LocalSQL");
            services.AddDbContext<ChillLancerDbContext>(options => options.UseSqlServer(connectionString));
            return services;
        }

        private static IServiceCollection InjectBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IProposalService, ProposalService>();
            services.AddScoped<ICategoryService, CategoryService>();

            //Add other BusinessServices here...

            return services;
        }

        private static IServiceCollection InjectRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //---------------------------------------------------------------------------
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IProposalRepository, ProposalRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            //Add other Repository here...

            return services;
        }

        private static IServiceCollection ConfigKebabCase(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Conventions.Add(new RouteTokenTransformerConvention(new KebabRouteTransform()));
            }).AddNewtonsoftJson(options =>
            {//If using NewtonSoft in project then must orride default Naming rule of System.text
                options.SerializerSettings.ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new KebabCaseNamingStrategy()
                };
            });

            services.AddSwaggerGen(c => { c.SchemaFilter<KebabSwaggerSchema>(); });
            return services;
        }

        private static IServiceCollection ConfigCORS(this IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("AllowAll", b => b.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()));
            return services;
        }

        private static IServiceCollection ConfigMapster(this IServiceCollection services)
        {
            //services.AddMapster();
            //TypeAdapterConfig<AccountRequested, Account>.NewConfig().IgnoreNullValues(true);
            //TypeAdapterConfig<OrderDetail_InfoDto, OrderDetail>.NewConfig().IgnoreNullValues(true)
            //    .Map(destination => destination.Id, startFrom => startFrom.OrderDetailId);
            TypeAdapterConfig<Proposal, ProposalBM>.NewConfig()
            .Map(dest => dest.ProjectId, src => src.Project.Id)
            .Map(dest => dest.AccountId, src => src.Freelancer.Id)
            .IgnoreNullValues(true);
            return services;
        }
        //Chua biet cau hinh nen tam thoi de day thoi
        //private static IServiceCollection ConfigOData(this IServiceCollection services)
        //{
        //    services.AddControllers().AddOData(options =>
        //    {
        //        options.Select().Expand().Filter().OrderBy().Count().SkipToken().AddRouteComponents("odata", model);
        //    }); 

        //    return services;
        //}
    }
}

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
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICertificationService, CertificationService>();
            services.AddScoped<IEducationService, EducationService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<ISkillService, SkillService>();

            //Add other BusinessServices here...

            return services;
        }

        private static IServiceCollection InjectRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //---------------------------------------------------------------------------
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICertificationRepository, CertificationRepository>();
            services.AddScoped<IEducationRepository, EducationRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();

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
            //========================[ Language ]========================
            //AccountLanguage => LanguageBM
            TypeAdapterConfig<AccountLanguage, LanguageBM>.NewConfig()
                .Map(dest => dest.Id, src => src.LanguageId)
                .Map(dest => dest.Name, src => src.Language.Name)
                .Map(dest => dest.Status, src => src.Language.Status);

            //LanguageBM => AccountLanguage
            TypeAdapterConfig<LanguageBM, AccountLanguage>.NewConfig()
                .Map(dest => dest.LanguageId, src => src.Id)
                .Ignore(dest => dest.Account)
                .Ignore(dest => dest.Language);

            //========================[ Skill ]========================
            //SkillBM => ProjectSkill
            TypeAdapterConfig<SkillBM, ProjectSkill>.NewConfig()
                .Map(dest => dest.SkillId, src => src.Id)
                .Ignore(dest => dest.Project)
                .Ignore(dest => dest.SkillId);

            //SkillBM => ProposalSkill
            TypeAdapterConfig<SkillBM, ProposalSkill>.NewConfig()
                .Map(dest => dest.SkillId, src => src.Id)
                .Ignore(dest => dest.Proposal)
                .Ignore(dest => dest.SkillId);

            //========================[ Certification ]========================
            //CertificationBM => Certification
            TypeAdapterConfig<CertificationBM, Certification>.NewConfig()
                .Map(dest => dest.Freelancer, src => new Account { Id = src.FreeLancerId });

            //========================[ Education ]========================
            //EducationBM => Education
            TypeAdapterConfig<EducationBM, Education>.NewConfig()
                .Map(dest => dest.Freelancer, src => new Account { Id = src.FreeLancerId });
            return services;
        }
    }
}

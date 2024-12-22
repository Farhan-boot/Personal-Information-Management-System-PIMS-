using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PTSL.DgFood.Common.Dictionaries;
using PTSL.DgFood.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.DgFood.Api.Helpers
{
    public static class ConfigureServiceExtensions
    {
        public static void ConfigureDatabases(
           this IServiceCollection services,
           string identicaMyCoreAuthConfigDatabaseConnection)
        {
            services.AddDbContext<DgFoodReadOnlyCtx>(item => item.UseSqlServer(identicaMyCoreAuthConfigDatabaseConnection), ServiceLifetime.Scoped);
            services.AddDbContext<DgFoodWriteOnlyCtx>(item => item.UseSqlServer(identicaMyCoreAuthConfigDatabaseConnection), ServiceLifetime.Scoped);

            using (IServiceScope serviceScope = services.BuildServiceProvider().CreateScope())
            {
                using (DgFoodWriteOnlyCtx authContext = serviceScope.ServiceProvider.GetRequiredService<DgFoodWriteOnlyCtx>())
                {
                    authContext.Database.EnsureCreated();

                    #region Configuration Dictionaries (Authentication Operation,Login Type,Organization Relationship,Residence Relationship)
                    ConfigurationDictionaries configurationDictionaries = new ConfigurationDictionaries();

                    //configurationDictionaries.AuthenticationOperationDictionary = authContext.Set<AuthenticationOperation>()
                    //    .ToDictionary(x => x.Id, x => x.Name);

                    //configurationDictionaries.LoginTypeDictionary = authContext.Set<LoginType>()
                    //    .ToDictionary(x => x.Id, x => x.Name);

                    //configurationDictionaries.OrganizationRelationshipDictionary = authContext.Set<OrganizationRelationship>()
                    //    .ToDictionary(x => x.Id, x => x.Name);

                    //configurationDictionaries.ResidenceRelationshipDictionary = authContext.Set<ResidenceRelationship>()
                    //    .ToDictionary(x => x.Id, x => x.Name);

                    services.AddSingleton(configurationDictionaries);
                    #endregion

                }
            }
        }
    }
}

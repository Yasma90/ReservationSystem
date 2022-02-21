using System;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using ReservationSystem.Persistence;
using ReservationSystem.Persistence.Repository;
using ReservationSystem.Persistence.UnitOfWork;
using ReservationSystem.Persistence.Repository.Interfaces;
using ReservationSystem.Persistence.UnitOfWork.Interfaces;

namespace ReservationSystem.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ReservationSysDbContext>(opt => opt
                .UseSqlServer(connectionString, sql => sql.MigrationsAssembly(typeof(ReservationSysDbContext)
                    .GetTypeInfo().Assembly.GetName().Name))); 
            services.AddScoped<IContactTypeRepository, ContactTypeRepository>();
            services.AddScoped<IContactRespository, ContactRespository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddDbInitializer(this IServiceCollection services) =>
            services.AddScoped<IDbInitializer, DbInitializer>();

    }
}

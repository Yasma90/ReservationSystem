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
using ReservationSystem.Persistence.Repository.Interface;
using ReservationSystem.Persistence.UnitOfWork.Interfaces;

namespace ReservationSystem.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ReservationSysDbContext>(opt => opt
                .UseSqlServer(connectionString, sql => sql.MigrationsAssembly(typeof(ReservationSysDbContext)
                    .GetTypeInfo().Assembly.GetName().Name))
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                .EnableSensitiveDataLogging());
            services.AddTransient<IContactRespository, ContactRespository>();
            services.AddTransient<IReservationRepository, ReservationRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }

    }
}

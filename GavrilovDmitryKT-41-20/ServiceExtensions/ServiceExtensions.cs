using GavrilovDmitryKT_41_20.Interfaces.SubjectInterfaces;

namespace GavrilovDmitryKT_41_20.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ISubjectService, SubjectService>();

            return services;
        }
    }
}

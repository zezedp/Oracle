using CertManager.Application.UseCases.Certificate.Create;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CertManager.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration config)
        {
            AddUseCases(services);
        }

        private static void AddUseCases(this IServiceCollection services) {
            services.AddScoped<ICreateCertificateUseCase, CreateCertificateUseCase>();
        }
    }
}

using Application.ViewModels.User;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ServicesExtentions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddTransient<IValidator<LoginRequest>, LoginValidation>();
            services.AddTransient<IValidator<RegisterRequest>, RegisterValidation>();
        }
    }
}


using Application.Commands.Activity;
using Application.Mapper;
using Application.Validators;
using Application.Validators.Activities;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var assembly = typeof(ApplicationRegistration).Assembly;
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            services.AddMapperServices();

            //services.AddFluentValidationAutoValidation();
            services.AddScoped<IValidator<CreateActivityRequest>, CreateActivityValidator>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(Validation<,>));

            return services;
        }
    }
}

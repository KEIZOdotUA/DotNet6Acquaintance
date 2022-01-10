using API.Filters;
using Core.Extensions;
using Core.Interfaces;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

/// <summary>
/// Register application services extension.
/// </summary>
public static class RegisterApplicationServicesExtension
{
    /// <summary>
    /// Registers application services.
    /// </summary>
    /// <param name="services">Application services instance.</param>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase(CommonConstants.DbName));
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        var assembly = AppDomain.CurrentDomain.Load(CommonConstants.CoreProjectName);
        services.AddMediatR(assembly);
        services.AddAutoMapper(assembly);

        services.AddMvc(options =>
        {
            options.Filters.Add(typeof(HttpGlobalExceptionFilter));
        });
    }
}

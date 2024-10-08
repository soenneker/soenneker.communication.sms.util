using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Communication.Sms.Client.Registrars;
using Soenneker.Communication.Sms.Util.Abstract;

namespace Soenneker.Communication.Sms.Util.Registrars;

/// <summary>
/// A utility library for Azure Communication Services SMS operations
/// </summary>
public static class AzureSmsUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IAzureSmsUtil"/> as a singleton service. <para/>
    /// </summary>
    public static void AddAzureSmsUtilAsSingleton(this IServiceCollection services)
    {
        services.AddSmsClientUtilAsSingleton();
        services.TryAddSingleton<IAzureSmsUtil, AzureSmsUtil>();
    }

    /// <summary>
    /// Adds <see cref="IAzureSmsUtil"/> as a scoped service. <para/>
    /// </summary>
    public static void AddAzureSmsUtilAsScoped(this IServiceCollection services)
    {
        services.AddSmsClientUtilAsScoped();
        services.TryAddScoped<IAzureSmsUtil, AzureSmsUtil>();
    }
}

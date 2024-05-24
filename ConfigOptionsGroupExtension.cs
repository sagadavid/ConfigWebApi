namespace ConfigWebApi;

public static class ConfigOptionsGroupExtension
{
  public static IServiceCollection GroupConfigOptions(this IServiceCollection services, IConfiguration configuration)
  {
    services.Configure<ConfigurationOptions>(configuration.GetSection(ConfigurationOptions.SectionName));

    services.Configure<ConfigOps>(ConfigOps.SystemConfigSectionName, configuration.GetSection($"{ConfigOps.SectionName}:{ConfigOps.SystemConfigSectionName}"));

    services.Configure<ConfigOps>(ConfigOps.BusinessConfigSectionName, configuration.GetSection($"{ConfigOps.SectionName}:{ConfigOps.BusinessConfigSectionName}"));

    return services;
  }
}

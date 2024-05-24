namespace ConfigWebApi;
//strongly typed access to configuration settings
public class ConfigurationOptions
{
  public const string SectionName = "Database";
  public string Type { get; set; } = string.Empty;
  public string ConnectionString { get; set; } = string.Empty;

}



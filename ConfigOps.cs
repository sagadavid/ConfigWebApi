namespace ConfigWebApi;

public class ConfigOps
{
  public const string SectionName = "DataPool";
  public const string SystemConfigSectionName = "System";
  public const string BusinessConfigSectionName = "Business";
  public string Type { get; set; } = string.Empty;
  public string ConnectionString { get; set; } = string.Empty;
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigWebApi;

[ApiController]
[Route("[controller]")]
public class ConfigurationController(IConfiguration configuration) : ControllerBase
{
  [HttpGet]
  [Route("keyCall")]
  public ActionResult GetKey()
  {
    //hardcoded config access
    var key2Call = configuration["Key2BCalled"];
    return Ok(key2Call);
  }

  [HttpGet]
  [Route("configByHardCode")]
  public ActionResult GetDBConfig()
  {
    //hardcoded config access.. hierarchi provided by {:}
    var type = configuration["Database:Type"];
    var conString = configuration["Database:ConnectionString"];
    return Ok(new { Type = type, ConnectionString = conString });

  }

  [HttpGet]
  [Route("configByBinder")]
  public ActionResult GetConfigOptions()
  {
    //strongly typed acces to config options
    var configOptions = new ConfigurationOptions();
    configuration.Bind(ConfigurationOptions.SectionName, configOptions);
    return Ok(new { configOptions.Type, configOptions.ConnectionString });
  }

  [HttpGet]
  [Route("configByGeneric")]
  public ActionResult GetConfigurationGenericType()
  {
    var configOptionsGenericType = configuration.GetSection(ConfigurationOptions.SectionName).Get<ConfigurationOptions>();
    return Ok(new { configOptionsGenericType?.Type, configOptionsGenericType?.ConnectionString });
  }

  [HttpGet]
  [Route("configByDI")]
  public ActionResult GetConfigByDI([FromServices] IOptions<ConfigurationOptions> configo)
  {
    var config = configo.Value;
    return Ok(new { config.Type, config.ConnectionString });
  }

  [HttpGet]
  [Route("configSnapshot")]
  public ActionResult GetConfigSnapshot([FromServices] IOptionsSnapshot<ConfigurationOptions> configo)
  {
    var config = configo.Value;
    return Ok(new { config.Type, config.ConnectionString });
  }

  [HttpGet]
  [Route("configMonitor")]
  public ActionResult GetConfigMonitor([FromServices] IOptionsMonitor<ConfigurationOptions> configo)
  {
    var config = configo.CurrentValue;
    return Ok(new { config.Type, config.ConnectionString });
  }

  [HttpGet]
  [Route("configMultipleSections")]
  public ActionResult GetConfigMultipleSections([FromServices] IOptionsSnapshot<ConfigOps> ops)
  {
    var systemConfig = ops.Get(ConfigOps.SystemConfigSectionName);
    var businessConfig = ops.Get(ConfigOps.BusinessConfigSectionName);

    return Ok(new
    {
      SystemConfig = systemConfig,
      BusinessConfig = businessConfig
    });
  }

}

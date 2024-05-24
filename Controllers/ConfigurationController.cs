using Microsoft.AspNetCore.Mvc;

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
  [Route("configHardCoded")]
  public ActionResult GetDBConfig()
  {
    //hardcoded config access.. hierarchi provided by {:}
    var type = configuration["Database:Type"];
    var conString = configuration["Database:ConnectionString"];
    return Ok(new { Type = type, ConnectionString = conString });

  }

  [HttpGet]
  [Route("configWithBinder")]
  public ActionResult GetConfigOptions()
  {
    //strongly typed acces to config options
    var configOptions = new ConfigurationOptions();
    configuration.Bind(ConfigurationOptions.SectionName, configOptions);
    return Ok(new { configOptions.Type, configOptions.ConnectionString });
  }

  [HttpGet]
  [Route("configWithGeneric")]
  public ActionResult GetConfigurationGenericType()
  {
    var configOptionsGenericType = configuration.GetSection(ConfigurationOptions.SectionName).Get<ConfigurationOptions>();
    return Ok(new { configOptionsGenericType?.Type, configOptionsGenericType?.ConnectionString });
  }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SriSloka.Data;
using SriSloka.Model;

namespace SriSloka.Api.Controllers
{
  [Route("api/[controller]")]
  public class BaseApiController : Controller
  {
    #region Constructor
    public BaseApiController(
      SriSlokaDbContext context,
      RoleManager<IdentityRole> roleManager,
      UserManager<ApplicationUser> userManager,
      IConfiguration configuration
    )
    {
      // Instantiate the required classes through DI
      DbContext = context;
      RoleManager = roleManager;
      UserManager = userManager;
      Configuration = configuration;

      // Instantiate a single JsonSerializerSettings object
      // that can be reused multiple times.
      JsonSettings = new JsonSerializerSettings()
      {
        Formatting = Formatting.Indented
      };

    }
    #endregion

    #region Shared Properties
    protected SriSlokaDbContext DbContext { get; private set; }
    protected RoleManager<IdentityRole> RoleManager { get; private set; }
    protected UserManager<ApplicationUser> UserManager { get; private set; }
    protected IConfiguration Configuration { get; private set; }
    protected JsonSerializerSettings JsonSettings { get; private set; }
    #endregion
  }
}

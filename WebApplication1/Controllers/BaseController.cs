using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Base Controller 
    /// </summary>

    [Route("api/v{version:apiversion}/[controller]")]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class BaseController : ControllerBase
    {
        #region Protected Members
        private string GetInnerException(Exception ex)
        {
            if (ex.InnerException != null)
            {
                return
                    $"{ex.InnerException.Message + "( \n " + ex.Message + " \n )"} > {GetInnerException(ex.InnerException)} ";
            }
            return string.Empty;
        }
        #endregion
    }
}
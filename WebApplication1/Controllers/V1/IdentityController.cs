
using BLL.UsersBLL;
using Common.OutputResult;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ViewModels.UsersViewModels;

namespace WebApplication1.Controllers.V1
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    public class IdentityController : BaseController
    {
        #region Property
        private readonly IUsersService _usersService;
        #endregion
        #region Constructor
        public IdentityController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        #endregion

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ApiResult<string>> Login([FromBody] UsersLoginDTO loginViewModel, CancellationToken cancellationToken)
        {
            try
            {
                return await _usersService.Login(loginViewModel.Password , loginViewModel.Username, cancellationToken);
            }
            catch (Exception ex)
            {
                return new ApiResult<string>(false, ApiResultStatusCode.BadRequest, null, true, ex.Message);
            }
        }
        [HttpGet("GetUsersList")]
        public async Task<ApiResult<List<UsersListDTO>>> GetUsersList()
        {
            try
            {
                return await _usersService.GetUsersList();
            }
            catch (Exception ex)
            {
                return new ApiResult<List<UsersListDTO>>(false, ApiResultStatusCode.BadRequest, null, true, ex.Message);
            }
        }


    }
}

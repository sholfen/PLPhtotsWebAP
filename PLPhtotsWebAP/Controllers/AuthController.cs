using Microsoft.AspNetCore.Mvc;
using PLPhtotsWebAP.Models;
using PLPhtotsWebAP.Services;

namespace PLPhtotsWebAP.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserAppService _userAppService;

        public AuthController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginModel loginModel)
        {
            var isLogin = await _userAppService.Login(loginModel.UserName, loginModel.Password);
            if (isLogin)
            {
                return Redirect("/Upload/UploadPic");
            }

            return Redirect("/Home/Index");
        }

        public async Task<IActionResult> Logout()
        {
            await _userAppService.Logout();
            return Redirect("/Home/Index");
        }
    }
}

using June2026.Domain.Features.User;
using Microsoft.AspNetCore.Mvc;

namespace June2026.MvcApp.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [ActionName("Index")]
        public async Task<IActionResult> UserListAsync()
        {
            UserListResponseModel model = await _userService.GetUsersAsync(new UserListRequestModel());
            return View("UserList", model);
        }
    }
}

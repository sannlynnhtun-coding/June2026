using June2026.Domain.Features.User;
using Microsoft.AspNetCore.Mvc;

namespace June2026.MvcApp2.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [ActionName("Index")]
        public async Task<IActionResult> UserList()
        {
            UserListResponseModel model = await _userService.GetUsersAsync(new UserListRequestModel { });
            return View("UserList", model);
        }

        [ActionName("Create")]
        public IActionResult UserCreate()
        {
            return View("UserCreate");
        }

        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> UserSaveAsync(UserCreateRequestModel requestModel)
        {
            UserCreateResponseModel model = await _userService.CreateUserAsync(requestModel);
            return Redirect("/User/Index");
        }

        // user/edit/1
        [ActionName("Edit")]
        public async Task<IActionResult> UserEdit(int id)
        {
            UserEditResponseModel model = await _userService.GetUserAsync(new UserEditRequestModel { UserId = id });    
            return View("UserEdit", model);
        }

        [HttpPost]
        [ActionName("Update")]
        public async Task<IActionResult> UserUpdateAsync(int id, UserPatchRequestModel requestModel)
        {
            requestModel.UserId = id;
            UserPatchResponseModel model = await _userService.PatchUserAsync(requestModel);
            return Redirect("/User/Index");
        }

        [ActionName("Delete")]
        public async Task<IActionResult> UserDelete(int id)
        {
            UserDeleteResponseModel model = await _userService.DeleteUserAsync(new UserDeleteRequestModel { UserId = id });
            return Redirect("/User/Index");
        }
    }
}

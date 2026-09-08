using June2026.Domain.Features.User;
using Microsoft.AspNetCore.Mvc;

namespace June2026.MvcApp2.Controllers
{
    // ViewBag
    // ViewData
    // TempData
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
            List<UserRoleModel> roles = new List<UserRoleModel>
            {
                new UserRoleModel("Admin", "Administrator"),
                new UserRoleModel("User", "Regular User"),
                new UserRoleModel("Guest", "Guest User")
            };
            //ViewBag.Roles = roles;  
            ViewData["Roles"] = roles;

            return View("UserCreate", new UserCreateRequestModel());
        }

        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> UserSaveAsync(UserCreateRequestModel requestModel)
        {
            List<UserRoleModel> roles = new List<UserRoleModel>
            {
                new UserRoleModel("Admin", "Administrator"),
                new UserRoleModel("User", "Regular User"),
                new UserRoleModel("Guest", "Guest User")
            };
            ViewData["Roles"] = roles;

            bool isSuccess = false;
            string message = string.Empty;
            if (string.IsNullOrEmpty(requestModel.Username))
            {
                message = "Invalid Username.";
                TempData["IsSuccess"] = isSuccess;
                TempData["Message"] = message;
                //return Redirect("/User/Create");
                return View("UserCreate", requestModel);
            }
            if (string.IsNullOrEmpty(requestModel.Password))
            {
                message = "Invalid Password.";
                TempData["IsSuccess"] = isSuccess;
                TempData["Message"] = message;
                //return Redirect("/User/Create");
                return View("UserCreate", requestModel);
            }
            if (string.IsNullOrEmpty(requestModel.RoleCode) || requestModel.RoleCode == "0")
            {
                message = "Invalid Role.";
                TempData["IsSuccess"] = isSuccess;
                TempData["Message"] = message;
                //return Redirect("/User/Create");
                return View("UserCreate", requestModel);
            }

            UserCreateResponseModel model = await _userService.CreateUserAsync(requestModel);

            isSuccess = model.IsSuccess;
            message = model.Message;

            TempData["IsSuccess"] = isSuccess;
            TempData["Message"] = message;

            //ViewBag.IsSuccess = model.IsSuccess;
            //ViewData["IsSuccess"] = model.IsSuccess;
            //TempData["IsSuccess"] = model.IsSuccess; // redirect

            //ViewBag.Message = model.Message;
            //ViewData["Message"] = model.Message;
            //TempData["Message"] = model.Message; // redirect

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

    public record UserRoleModel(string RoleCode, string RoleName);

    public class UserRoleModel2
    {
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
    }
}

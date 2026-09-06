namespace June2026.MvcApp3.Controllers;

public class UserController : Controller
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    public async Task<IActionResult> IndexAsync()
    {
        return View();
    }

    public async Task<IActionResult> UserList()
    {
        var model = await _userService.GetUsersAsync(new UserListRequestModel());
        return Json(model);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ActionName("Save")]
    public async Task<IActionResult> UserSaveAsync(UserCreateRequestModel requestModel)
    {
        UserCreateResponseModel model = await _userService.CreateUserAsync(requestModel);
        return Json(model);
    }

    public async Task<IActionResult> Edit(int id)
    {
        UserEditResponseModel model = await _userService.GetUserAsync(new UserEditRequestModel { UserId = id });
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> UserUpdateAsync(int id, UserPatchRequestModel requestModel)
    {
        requestModel.UserId = id;
        UserPatchResponseModel model = await _userService.PatchUserAsync(requestModel);
        return Json(model);
    }

    [HttpPost]
    public async Task<IActionResult> UserDelete(UserDeleteRequestModel requestModel)
    {
        UserDeleteResponseModel model = await _userService.DeleteUserAsync(requestModel);
        return Json(model);
    }
}

using June2026.Database.AppDbContextModels;
using June2026.Domain.Features.User;
using June2026.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace June2026.WebApi.Controllers;

// api/user
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsersAsync()
    {
        var model = await _userService.GetUsersAsync(new UserListRequestModel());
        if (model.IsSuccess)
        {
            return Ok(model);
        }
        else
        {
            return BadRequest(model);
        }
    }

    // api/user/edit/1
    // api/user/1
    [HttpGet("edit/{id}")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserAsync(int id)
    {
        return Ok(await _userService.GetUserAsync(new UserEditRequestModel { UserId = id }));
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserAsync([FromBody] UserCreateRequestModel requestModel)
    {
        return Ok(await _userService.CreateUserAsync(requestModel));
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchUserAsync(int id, UserPatchRequestModel requestModel)
    {
        requestModel.UserId = id;
        return Ok(await _userService.PatchUserAsync(requestModel));
    }

    // api/user?userId=1 => [FromQuery]
    [HttpDelete("{UserId}")]
    public async Task<IActionResult> DeleteUserAsync([FromRoute] UserDeleteRequestModel requestModel)
    {
        return Ok(await _userService.DeleteUserAsync(requestModel));
    }
}


//public class Book
//{
//    public int Id { get; set; } 
//    public int Qty { get; set; }
//}

//public class OrderRequestModel
//{
//    public List<Book> Books { get; set; }
//}

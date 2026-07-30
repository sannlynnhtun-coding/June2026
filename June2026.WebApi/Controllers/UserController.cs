using June2026.Database.AppDbContextModels;
using June2026.Domain.Features.User;
using June2026.Domain.Models;
using June2026.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace June2026.WebApi.Controllers;

// api/user
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController()
    {
        _userService = new UserService();
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        var model = _userService.GetUsers(new UserListRequestModel());
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
    public IActionResult GetUser(int id)
    {
        return Ok(_userService.GetUser(new UserEditRequestModel { UserId = id }));
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] UserCreateRequestModel requestModel)
    {
        return Ok(_userService.CreateUser(requestModel));
    }

    [HttpPatch("{id}")]
    public IActionResult PatchUser(int id, UserPatchRequestModel requestModel)
    {
        requestModel.UserId = id;
        return Ok(_userService.PatchUser(requestModel));
    }

    // api/user?userId=1 => [FromQuery]
    [HttpDelete("{UserId}")]
    public IActionResult DeleteUser([FromRoute] UserDeleteRequestModel requestModel)
    {
        return Ok(_userService.DeleteUser(requestModel));
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
using June2026.Database.AppDbContextModels;
using June2026.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace June2026.WebApi.Controllers;

// api/user
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly AppDbContext _db;

    public UserController()
    {
        _db = new AppDbContext();
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        var lst = _db.TblUsers.ToList();
        return Ok(lst);

        //return StatusCode(500, "Frontend Developer Tawthar");
    }

    // api/user/edit/1
    // api/user/1
    [HttpGet("edit/{id}")]
    [HttpGet("{id}")]
    public IActionResult GetUser(int id)
    {
        var item = _db.TblUsers.FirstOrDefault(x => x.UserId == id);
        if (item is null)
        {
            return NotFound("User doesn't exist.");
        }
        return Ok(item);
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] UserCreateRequestModel requestModel)
    {
        TblUser user = new TblUser
        {
            Password = requestModel.Password,
            Username = requestModel.Username
        };
        _db.TblUsers.Add(user);
        int result = _db.SaveChanges();

        UserCreateResponseModel model = new UserCreateResponseModel
        {
            IsSuccess = result > 0,
            Message = result > 0 ? "Saving Successful." : "Saving Failed.",
            UserId = user.UserId
        };

        return Ok(model);
    }

    //[HttpPost("Test")]
    //public IActionResult Test(OrderRequestModel requestModel)
    //{
    //    return Ok();
    //}

    [HttpPut]
    public IActionResult UpsertUser()
    {
        return Ok("Create User");
    }

    [HttpPatch("{id}")]
    public IActionResult PatchUser(int id, UserPatchRequestModel requestModel)
    {
        var item = _db.TblUsers.FirstOrDefault(x => x.UserId == id);
        if (item is null)
        {
            return NotFound(new UserPatchResponseModel
            {
                Message = "User doesn't exist"
            });
        }

        //if (string.IsNullOrEmpty(requestModel.Username))
        //{
        //    return NotFound(new UserPatchResponseModel
        //    {
        //        Message = "User doesn't exist"
        //    });
        //}
        //if (string.IsNullOrEmpty(requestModel.Username))
        //{
        //    return NotFound(new UserPatchResponseModel
        //    {
        //        Message = "User doesn't exist"
        //    });
        //}

        //item.Username = requestModel.Username;
        //item.Password = requestModel.Password;


        if (!string.IsNullOrEmpty(requestModel.Username))
        {
            item.Username = requestModel.Username;
        }
        if (!string.IsNullOrEmpty(requestModel.Password))
        {
            item.Password = requestModel.Password;
        }

        int result = _db.SaveChanges();

        UserPatchResponseModel model = new UserPatchResponseModel
        {
            IsSuccess = result > 0,
            Message = result > 0 ? "Updating Successful." : "Updating Failed.",
        };

        return Ok(model);
    }

    // api/user?userId=1 => [FromQuery]
    [HttpDelete("{UserId}")]
    public IActionResult DeleteUser([FromRoute] UserDeleteRequestModel requestModel)
    {
        var item = _db.TblUsers.FirstOrDefault(x => x.UserId == requestModel.UserId);
        if (item is null)
        {
            return NotFound(new UserPatchResponseModel
            {
                Message = "User doesn't exist"
            });
        }

        _db.Remove(item);
        int result = _db.SaveChanges();

        UserDeleteResponseModel model = new UserDeleteResponseModel
        {
            IsSuccess = result > 0,
            Message = result > 0 ? "Deleting Successful." : "Deleting Failed.",
        };
        return Ok(model);
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
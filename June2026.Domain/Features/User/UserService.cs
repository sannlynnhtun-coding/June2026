using June2026.Database.AppDbContextModels;
using June2026.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace June2026.Domain.Features.User;

public class UserService
{
    private readonly AppDbContext _db;

    public UserService()
    {
        _db = new AppDbContext();
    }

    public UserListResponseModel GetUsers(UserListRequestModel requestModel)
    {
        try
        {
            var lst = _db.TblUsers.ToList();

            List<UserModel> users = new List<UserModel>();

            foreach (var item in lst)
            {
                UserModel user = new UserModel
                {
                    UserId = item.UserId,
                    Username = item.Username
                };
                users.Add(user);
            }

            return new UserListResponseModel
            {
                IsSuccess = true,
                Message = "Users fetched successfully.",
                Users = users
                //Users = lst.Select(x => new UserModel
                //{
                //    UserId = x.UserId,
                //    Username = x.Username
                //}).ToList()
            };
        }
        catch (Exception ex)
        {
            return new UserListResponseModel
            {
                IsSuccess = false,
                Message = ex.ToString(),
            };
        }
    }

    public UserEditResponseModel GetUser(UserEditRequestModel requestModel)
    {
        try
        {
            var item = _db.TblUsers.FirstOrDefault(x => x.UserId == requestModel.UserId);
            if (item is null)
            {
                return new UserEditResponseModel
                {
                    IsSuccess = false,
                    Message = "User doesn't exist."
                };
            }
            return new UserEditResponseModel
            {
                IsSuccess = true,
                Message = "User fetched successfully.",
                UserId = item.UserId,
                UserName = item.Username
            };
        }
        catch (Exception ex)
        {
            return new UserEditResponseModel
            {
                IsSuccess = false,
                Message = ex.ToString(),
            };
        }
    }

    public UserCreateResponseModel CreateUser(UserCreateRequestModel requestModel)
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

        return model;
    }

    public UserPatchResponseModel PatchUser(UserPatchRequestModel requestModel)
    {
        var item = _db.TblUsers.FirstOrDefault(x => x.UserId == requestModel.UserId);
        if (item is null)
        {
            return new UserPatchResponseModel
            {
                Message = "User doesn't exist"
            };
        }

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

        return model;
    }

    public UserDeleteResponseModel DeleteUser(UserDeleteRequestModel requestModel)
    {
        var item = _db.TblUsers.FirstOrDefault(x => x.UserId == requestModel.UserId);
        if (item is null)
        {
            return new UserDeleteResponseModel
            {
                Message = "User doesn't exist"
            };
        }

        _db.Remove(item);
        int result = _db.SaveChanges();

        UserDeleteResponseModel model = new UserDeleteResponseModel
        {
            IsSuccess = result > 0,
            Message = result > 0 ? "Deleting Successful." : "Deleting Failed.",
        };
        return model;
    }
}

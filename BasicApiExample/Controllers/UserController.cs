using BasicApiExample.Models;
using BasicApiExample.Repositories.Interfaces;
using CoreApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BasicApiExample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUser _user;
        public UserController(IUser user) 
        {
            _user = user;
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            try
            {
                var newUser = _user.CreateUser(user);
                if (newUser != null)
                {
                    return CustomResult("User Created", newUser, HttpStatusCode.Created);
                }
                else
                {
                    return CustomResult("Failed to Create User",HttpStatusCode.BadRequest);
                }
            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message,HttpStatusCode.BadRequest);
            }

            
            

        }

        [HttpGet]
        public IActionResult GetAllUser()
        {
            try
            {
                var users = _user.Users();
                if (users != null)
                {
                    return CustomResult("Data is loaded",users,HttpStatusCode.OK);
                }
                else
                {
                    return CustomResult("No data available",HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message,HttpStatusCode.BadRequest);
            }
            
            
        }

        [HttpGet]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var user = _user.GetUserById(id);
                if (user != null)
                {
                    return CustomResult("User Found",user,HttpStatusCode.OK);
                }
                else
                {
                    return CustomResult("User not Found",HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message,HttpStatusCode.BadRequest);
            }
            

        }

        [HttpPut]

        public IActionResult Edit(User user)
        {
            try
            {
                var UpdatedUser = _user.UpdateUser(user);
                if (UpdatedUser != null)
                {
                    return CustomResult("User data is Updated",UpdatedUser, HttpStatusCode.OK);

                }
                else
                {
                    return CustomResult("User not Found",HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message,HttpStatusCode.BadRequest);
            }
            
            
        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                if (id != 0)
                {
                    _user.DeleteUser(id);
                    return CustomResult("Delete Successful",HttpStatusCode.OK);
                }
                else
                {
                    return CustomResult("User not found",HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
            
        }

        [HttpGet("name")]
        public IActionResult SearchName(string name)
        {
            try
            {
                var user = _user.SearchUser(name);
                if (user != null)
                {
                    return CustomResult("Data found !", user, HttpStatusCode.OK);
                }
                else
                {
                    return CustomResult("User not Found", HttpStatusCode.NotFound);
                }
            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message,HttpStatusCode.BadRequest);
            }
            
            
        }

        [HttpGet("users")]
        public IActionResult SearchUsers(string text) 
        {

            try
            {
                var user = _user.SearchUsers(text);
                if (user != null)
                {
                    return CustomResult("Data found !", user, HttpStatusCode.OK);
                }
                else
                {
                    return CustomResult("User not Found", HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }

        }

        [HttpGet("page")]
        public IActionResult Page(int page=1,int dataSize = 1)
        {
            try
            {
                var data = _user.GetUsersPg(page, dataSize);
                if(data !=null)
                {
                    return CustomResult($"Data Found at {page}, No of Data {dataSize}  ", data, HttpStatusCode.OK);
                }
                else
                {
                    return CustomResult($"Data not found at Page no {page}",HttpStatusCode.NotFound);
                }
                
            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
            
        }


    }
}

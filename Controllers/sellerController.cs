using Ecommerce_Core_WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.VisualBasic;
using System;
using System.Threading.Tasks;

namespace Ecommerce_Core_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class sellerController : ControllerBase
    {
        private IUserRepositoty _userRepositoty;

        public sellerController(IUserRepositoty userRepositoty)
        {
            _userRepositoty = userRepositoty;
        }

        [HttpPost]
        public ActionResult<user> userSignUp(user user)
        {
            try
            {
                var result = _userRepositoty.addUser(user);
                if (result is null)
                {
                    return BadRequest();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "service could not add the user");
            }
;
        }

        
        [HttpGet]
        [Route("{email}/{password}")]
        public async Task<ActionResult<user>> getUser(string email, string password)
        //public ActionResult<user> getUser(user user)
        {
            //user tempUser = new user() {email=   user.email , password = user.password };
            user tempUser = new user() { email = email, password = password };

            try
            {
                var result = await _userRepositoty.GetUser(new user() { email = tempUser.email, password = tempUser.password });
                if (result is null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, "user not found");
            }
        }

        [Route("search/{name}")]
        [HttpGet]
        public async Task<ActionResult<user>> searchUser(string name)
        {
            try
            {
                var user = await _userRepositoty.Search(new Models.user() { name = name });
                if (user != null)
                {
                    return Ok(user);
                }
                return BadRequest("user not found");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

    }
}

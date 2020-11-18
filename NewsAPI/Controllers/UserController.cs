using Entities;
using Microsoft.AspNetCore.Mvc;
using NewsAPI.Aspect;
using Service;
using Service.Exceptions;
using System.Net;
using System.Threading.Tasks;
namespace NewsAPI.Controllers
{
    /*
   * As in this assignment, we are working with creating RESTful web service, hence annotate
   * the class with [ApiController] annotation and define the controller level route as per 
   * REST Api standard.
   */
    [ExceptionHandler]
    public class UserController : ControllerBase
    {
        /*
        * UserService should  be injected through constructor injection. 
        * Please note that we should not create service object using the new keyword
        */
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        /*
        * Example: //GET: api/user
        * Define a handler method which will get the user details by a userId.
        * This handler method should return any one of the status messages basis on
        * different situations: 
        * 1. 200(OK) - If the user details found successfully.
        * 2. 404(NOT FOUND) - If the userprofile with specified userid doesn't exist. 
        * This handler method should map to the URL "/api/user/{userId}" using HTTP GET method
        * 3. 500 (Internal Server Error),means that server cannot process the request 
          for an unknown reason.
        */
        [HttpGet]
        [Route("api/user/{userId}")]
        public async Task<IActionResult> Get(string userId)
        {

            var newsList = await _userService.GetUser(userId);

            return Ok(newsList);

        }

        /*
         * Define a handler method which will create a specific user profile by reading the
         * Serialized object from request body and save the user details in a userprofile table
         * in the database.
         * 
         * This handler method should
         * return any one of the status messages basis on different situations: 
         * 1. 201(CREATED) - If the user profile details created successfully. 
         * 2. 409(CONFLICT) - If the userId conflicts
         * This handler method should map to the URL "/api/user" using HTTP POST method
         * 3. 500 (Internal Server Error),means that server cannot process the request 
         *    for an unknown reason.
         */
        [HttpPost]
        [Route("api/user")]
        public async Task<IActionResult> Post([FromBody]UserProfile user)
        {

            var newsList = await _userService.AddUser(user);

            return Created("", newsList);

        }
        /*
         * Define a handler method which will update a specific user by reading the
         * Serialized object from request body and save the updated user details in
         * a userprofile table in database.
         * This handler method should return any one of the status
         * messages basis on different situations: 
         * 1. 200(OK) - If the reminder updated
         * successfully. 
         * 2. 404(NOT FOUND) - If the userprofile with specified userid doesn't exist. 
         * 
         * This handler method should map to the URL "/api/reminder/{id}" using HTTP PUT
         * method.
         * 3. 500(Internal Server Error),means that server cannot process the request 
         *    for an unknown reason.
         */
        [HttpPut]
        [Route("api/user/{userId}")]
        public async Task<IActionResult> Put(string userId, UserProfile user)
        {

            var newsList = await _userService.UpdateUser(userId, user);

            return Ok(newsList);

        }
        /*
        * Define a handler method which will delete a user from a database.
        * 
        * This handler method should return any one of the status messages basis on
        * different situations: 
        * 1. 200(OK) - If the user deleted successfully from database. 
        * 2. 404(NOT FOUND)-If the user with specified userrId is not found. 
        * 
        * This handler method should map to the URL "/api/user/{id}" using HTTP Delete
        * method" where "id" should be replaced by a valid userId without {}
        * 3. 500(Internal Server Error),means that server cannot process the request 
        *    for an unknown reason.
        */
        [HttpDelete]
        [Route("api/user/{userId}")]
        public async Task<IActionResult> Delete(string userId)
        {

            var newsList = await _userService.DeleteUser(userId);

            return Ok(newsList);
        }
    }
}

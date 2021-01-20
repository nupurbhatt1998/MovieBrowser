/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;*/
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Movie.modal;
using Movie.DAL;

namespace Movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        

        [HttpGet]
        public JsonResult GetDetails(int imdbID)
        {
            UserDAL userDAL = new UserDAL();
            return userDAL.GetDetails(imdbID, _configuration);
        }

        

     /*   [HttpPost]
        public void Post(User_Details user)
        {
            UserDAL userDAL = new UserDAL();
            userDAL.PostData(user,_configuration);
        }*/
    }
}

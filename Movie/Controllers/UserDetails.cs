using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Movie.DAL;
using Microsoft.AspNetCore.Hosting;
using System.IO;
namespace Movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetails : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public UserDetails(IConfiguration configuration,IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        
        [HttpGet]
        public JsonResult Get(string Title)
        {
            UserDAL userDAL = new UserDAL();
            return userDAL.GetData(Title, _configuration);
        }

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string fileName = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + fileName;

                using(var stream=new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                return new JsonResult(fileName);

            }catch(Exception ex)
            {
                return new JsonResult("exception");
            }
        }

    }
}

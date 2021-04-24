using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RestroOwners.DbModels;

namespace RestroOwners.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestroOwnerController : ControllerBase
    {
        RestroDBContext _context;

        IConfiguration _config;

        public RestroOwnerController(IConfiguration config, RestroDBContext context)
        {
            _context = context;
            _config = config;
        }


        // POST: api/Login

        [HttpPost]
        public ActionResult AddUser([FromBody] OwnerModel userModel)
        {
            OwnerRestro ownerRestro = new OwnerRestro()
            {
                OUserName = userModel.OUserName,
                OEmail = userModel.OEmail,
                OPassword = userModel.OPassword
            };
            _context.OwnerRestro.Add(ownerRestro);
            _context.SaveChanges();
            return Ok("User Added");
        }


        [Route("[action]")]
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login([FromBody] OwnerModel login)
        {
            ActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private string GenerateJSONWebToken(OwnerModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private OwnerModel AuthenticateUser(OwnerModel login)
        {
            var authUser = _context.OwnerRestro.FirstOrDefault(userInfo => userInfo.OUserName == login.OUserName);
            OwnerModel user = null;


            //Validate the User Credentials    
            //Demo Purpose, I have Passed HardCoded User Information    
            if (login.OUserName == authUser.OUserName && login.OPassword == authUser.OPassword)
            {
                user = new OwnerModel { OUserName = login.OUserName, OEmail = login.OEmail };
            }
            return user;
        }
        // GET: api/RestroOwner
        [HttpGet]
        public ActionResult Get()
        {
            var user = _context.OwnerRestro.ToList();
            return Ok(user);
        }

        //// GET: api/RestroOwner/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/RestroOwner
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/RestroOwner/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}

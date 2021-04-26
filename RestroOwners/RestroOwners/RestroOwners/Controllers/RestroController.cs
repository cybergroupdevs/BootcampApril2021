using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestroOwners.DbModels;

namespace RestroOwners.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestroController : ControllerBase
    {

        RestroDBContext _context;



        public RestroController(RestroDBContext context)
        {
            _context = context;

        }

        // GET: api/Restro
        [Authorize]
        [HttpGet]
        public ActionResult Get()
        {
            var user = _context.Restros.ToList();
            return Ok(user);
        }

        // GET: api/Restro/5
        [HttpGet("{id}", Name = "Get")]
        public Restros GetUserByID(int id)
        {
            var user = _context.Restros.FirstOrDefault(restros => restros.Id == id);
            return user;
        }

        // POST: api/Restro
        
        
        [HttpPost]
        [Authorize]
        public ActionResult Add([FromBody] RestrosRequest userRequest)
        {
            Restros restros = new Restros()
            {
                RName = userRequest.RName,
                RAddress = userRequest.RAddress,
                RPhone = userRequest.RPhone,
                RType = userRequest.RType
            };
            _context.Restros.Add(restros);
            _context.SaveChanges();
            return Ok("User Added");
        }

        // PUT: api/Restro/5
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult Edit(int id, [FromBody] RestrosRequest userRequest)
        {
            Restros restros = GetUserByID(id);
            restros.RName = userRequest.RName;
            restros.RAddress = userRequest.RAddress;
            restros.RPhone = userRequest.RPhone;
            restros.RType = userRequest.RType;
            _context.SaveChanges();
            return Ok("restro updated!");
        }

        // DELETE: api/ApiWithActions/5
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var demo = GetUserByID(id);
            _context.Restros.Remove(demo);
            _context.SaveChanges();
            return Ok(demo);
        }
    }
}

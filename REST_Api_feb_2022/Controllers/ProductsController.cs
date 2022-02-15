using Microsoft.AspNetCore.Mvc;
using REST_Api_feb_2022.Data.Intefases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REST_Api_feb_2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepo _productRepo;

        public ProductsController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_productRepo.GetAll()); // 200
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var res = _productRepo.GetById(id);

            if (res != null)
            {
                return Ok(res);
            }
            return NotFound();
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using REST_Api_feb_2022.Data.Intefases;
using REST_Api_feb_2022.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REST_Api_feb_2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepo _orderRepo;
        public OrdersController(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok( _orderRepo.GetAll() );
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrdersController>
        [HttpPost]
        public ActionResult Post(OrderCreateDto value)
        {
            _orderRepo.Create(value);

            return Ok();
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

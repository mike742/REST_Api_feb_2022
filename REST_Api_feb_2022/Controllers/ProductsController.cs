using Microsoft.AspNetCore.Mvc;
using REST_Api_feb_2022.Data;
using REST_Api_feb_2022.Data.Intefases;
using REST_Api_feb_2022.Models;
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
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepo _productRepo;
        private readonly Mapper _mapper = new Mapper();

        public ProductsController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public ActionResult Get()
        {
            var productsToPresent = _productRepo.GetAll()
                .Select(p => _mapper.Map(p, true));
            return Ok(productsToPresent); // 200
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var res = _productRepo.GetById(id);

            if (res != null)
            {
                return Ok(_mapper.Map(res, true));
            }
            return NotFound();
        }

        // POST api/<ProductsController>
        [HttpPost]
        public ActionResult Post(ProductCreateDto value)
        {
            _productRepo.Create( _mapper.Map(value) );
            return Ok();
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, ProductCreateDto value)
        {
            _productRepo.Update( id, _mapper.Map(value) );
            return Ok();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _productRepo.Delete(id);
            return Ok();
        }
    }
}
